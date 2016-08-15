using MIPS64Simulator.Models;
using MIPS64Simulator.Models.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MIPS64Simulator.Helper
{
    public class CycleManager
    {
        private List<Statement> statements;
        private List<Register> registers;
        private List<Data> memory;
        private int cycle;

        private bool IsLastCycle = false;
        
        private Dictionary<int, int> RegisterInUse;

        private IF fetch;
        private ID decode;
        private EX execute;
        private MEM mem;
        private WB wb;
        private Stall stall;



        public CycleManager(List<Statement> statements, List<Register> registers, List<Data> memory)
        {
            this.statements = statements;
            this.registers = registers;
            this.memory = memory;
            this.cycle = 1;
            this.RegisterInUse = new Dictionary<int, int>();

            this.fetch = new IF();
            this.fetch.NPC = 0;
            this.decode = new ID();
            this.execute = new EX();
            this.mem = new MEM();
            this.wb = new WB();
            this.stall = new Stall();
        }

        public DataTable Execute()
        {
            DataTable pipeline = new DataTable();

            pipeline.Columns.Add(new DataColumn("Instructions", typeof(string)));
            pipeline.Columns.Add(new DataColumn("Address", typeof(int)));
            foreach (Statement statement in statements)
            {
                pipeline.Rows.Add(statement.Code, statement.Line);
            }

            do
            {
                pipeline.Columns.Add(new DataColumn(cycle.ToString(), typeof(string)));
                // WB
                this.wb.IR = this.mem.IR;
                this.wb.NPC = this.mem.NPC;
                if (!string.IsNullOrEmpty(this.mem.IR))
                {
                    if (CheckStallStatus(this.wb.NPC))
                    {
                        GetWB(this.wb.IR);
                        RemoveRegisterInUse(this.wb.IR);
                        AddToPipeline(pipeline, this.wb.NPC, cycle, "WB");

                    } else
                    {
                        this.wb.IR = this.mem.IR;
                        this.wb.NPC = this.mem.NPC;
                        AddToPipeline(pipeline, this.wb.NPC, cycle, "*");
                    }

                    if (this.stall.Address == this.mem.NPC)
                    {
                        this.stall.IsStall = false;
                        
                    }

                }

                // MEM
                this.mem.IR = this.execute.IR;
                this.mem.NPC = this.execute.NPC;
                if (!string.IsNullOrEmpty(this.execute.IR))
                {
                    if (CheckStallStatus(this.execute.NPC))
                    {
                        
                        GetMem(this.mem.IR);
                        AddToPipeline(pipeline, this.mem.NPC, cycle, "MEM");
                    } else
                    {
                        this.execute.IR = this.execute.IR;
                        this.execute.NPC = this.execute.NPC;
                        AddToPipeline(pipeline, this.mem.NPC, cycle, "*");
                    }
                   
                }

                // EX
                this.execute.IR = this.decode.IR;
                this.execute.NPC = this.decode.NPC;
                if (!String.IsNullOrEmpty(this.decode.IR))
                {
                    if (CheckStallStatus(this.decode.NPC))
                    {
                        GetEx(this.execute.IR);
                        AddToPipeline(pipeline, this.execute.NPC, cycle, "EX");
                    } else
                    {
                        this.execute.IR = this.decode.IR;
                        this.execute.NPC = this.decode.NPC;
                        AddToPipeline(pipeline, this.execute.NPC, cycle, "*");
                    }
                   
                }

                // ID
                this.decode.IR = this.fetch.IR;
                if (!String.IsNullOrEmpty(this.fetch.IR))
                {
                    this.decode.NPC = this.fetch.PC;
                    if (CheckStallStatus(this.decode.NPC))
                    {
                        
                        this.decode.A = GetA(this.decode.IR);
                        this.decode.B = GetB(this.decode.IR);
                        this.decode.Imm = GetImm(this.decode.IR);
                        AddToPipeline(pipeline, this.decode.NPC, cycle, "ID");
                    } else
                    {
                        this.decode.IR = this.fetch.IR;
                        this.decode.NPC = this.fetch.PC;
                        AddToPipeline(pipeline, this.decode.NPC, cycle, "*");
                    }
                }

                // IF

                if (!this.stall.IsStall)
                {
                    this.fetch.IR = GetInstruction(this.fetch.NPC);

                    if (!String.IsNullOrEmpty(this.fetch.IR))
                    {
                        GetUsedRegisters(this.fetch.IR, this.fetch.NPC);
                    }

                    if(HasDependency(this.fetch.IR, this.fetch.NPC))
                    {
                        this.stall.IsStall = true;
                        this.stall.Address = this.fetch.NPC;
                    }

                    AddToPipeline(pipeline, this.fetch.NPC, cycle, "IF");
                    this.fetch.PC = this.fetch.NPC;

                  
                        this.fetch.NPC += 4;
                       
                    
                   
                }
              
                cycle++;
            } while (!IsLastCycle);



            return pipeline;
        }

        #region Helper 
        private void GetUsedRegisters(string instruction, int address)
        {
            if (String.IsNullOrEmpty(instruction))
                return;

            int register = 0;
            string opcode = instruction.HexToBin().Substring(0, 6);
            try
            {
                switch (opcode)
                {
                    case "000000":
                        register = instruction.HexToBin().Substring(16, 5).BinToDec();
                        this.RegisterInUse.Add(register, address);
                        break;
                    default:
                        register = instruction.HexToBin().Substring(11, 5).BinToDec();
                        this.RegisterInUse.Add(register, address);
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool HasDependency(string instruction, int address)
        {
            if (String.IsNullOrEmpty(instruction))
                return false;

            int rs = 0;
            int rt = 0;
            bool flag = false;
            string opcode = instruction.HexToBin().Substring(0, 6);
            switch (opcode)
            {
                case "000000":
                    rs = instruction.HexToBin().Substring(6, 5).BinToDec();
                    rt = instruction.HexToBin().Substring(11, 5).BinToDec();
                    flag = this.RegisterInUse.Any(x => x.Key == rs && x.Value != address) 
                            || this.RegisterInUse.Any(x => x.Key == rt && x.Value != address);
                    break;
                default:
                    rs = instruction.HexToBin().Substring(6, 5).BinToDec();
                    flag = this.RegisterInUse.Any(x => x.Key == rs && x.Value != address);
                    break;
            }

            return flag;
        }

        private void RemoveRegisterInUse(string instruction)
        {
            if (String.IsNullOrEmpty(instruction))
                return;

            int register = 0;
            string opcode = instruction.HexToBin().Substring(0, 6);
            switch (opcode)
            {
                case "000000":
                    register = instruction.HexToBin().Substring(16, 5).BinToDec();
                    break;
                default:
                    register = instruction.HexToBin().Substring(11, 5).BinToDec();
                    break;
            }

            this.RegisterInUse.Remove(register);
        }

        private string GetInstruction(int address)
        {
            foreach (var statement in statements)
            {
                if (statement.Line == address)
                {
                    return statement.Opcode;
                }
            }

            return String.Empty;
        }

        private Int64 GetA(string instruction)
        {

            string binaryString = instruction.HexToBin();
            string binA = binaryString.Substring(6, 5);

            int register = binA.BinToDec();

            Register selectedRegister = this.registers.Find(x => x.Index == register);
            return selectedRegister.Value;
        }

        private Int64 GetB(string instruction)
        {

            string binaryString = instruction.HexToBin();
            string binA = binaryString.Substring(11, 5);

            int register = binA.BinToDec();

            Register selectedRegister = this.registers.Find(x => x.Index == register);
            return selectedRegister.Value;
        }

        private Int32 GetImm(string instruction)
        {
            string binaryString = instruction.HexToBin();
            string binImm = binaryString.Substring(16, 16);

            int immediate = binImm.BinToDec();
            return immediate;
        }

        private void GetEx(string instruction)
        {
            bool IsRType = false;

            string opcode = instruction.HexToBin().Substring(0, 6);

            switch (opcode)
            {
                case "000000": IsRType = true; break;
                case "011001": // DADDIU
                    this.execute.ALUOutput = this.decode.A + this.decode.Imm;
                    this.execute.Cond = 0;
                    this.execute.NPC = this.decode.NPC;
                    break;
                case "110111": // LD
                case "111111": // SD
                    this.execute.ALUOutput = this.decode.A * 8 + this.decode.Imm;
                    this.execute.Cond = 0;
                    this.execute.B = this.decode.B;
                    this.execute.NPC = this.decode.NPC;
                    break;
                default:
                    this.execute.IR = String.Empty;
                    break;
            }

            if (IsRType)
            {
                string func = instruction.HexToBin().Substring(26, 6);
                switch (func)
                {
                    case "100101":
                        this.execute.ALUOutput = this.decode.A | this.decode.B;
                        this.execute.Cond = 0;
                        break;
                    case "101010":
                        this.execute.ALUOutput = this.decode.A < this.decode.B ? 1 : 0;
                        this.execute.Cond = 0;
                        break;
                    case "010110":
                        this.execute.ALUOutput = this.decode.A << (int)this.decode.B;
                        this.execute.Cond = 0;
                        break;
                }
            }

        }

        private void GetMem(string instruction)
        {
            string opcode = instruction.HexToBin().Substring(0, 6);
            bool IsRType = false;
            switch (opcode)
            {
                case "110111": // LD
                    this.mem.LMD = this.memory.Find(x => x.Address.HexToBin().BinToDec() == this.execute.ALUOutput).Value;
                    break;
                case "111111": // SD
                    this.memory.Find(x => x.Address.HexToBin().BinToDec() == this.execute.ALUOutput).Value = this.execute.B;
                    break;
                case "011001": // DADDIU
                    this.mem.ALUOutput = this.execute.ALUOutput;
                    break;
                case "000000": // R-Type
                    IsRType = true;
                    break;
                default:
                    this.execute.IR = String.Empty;
                    break;
            }

            if (IsRType)
            {
                string func = instruction.HexToBin().Substring(26, 6);
                switch (func)
                {
                    case "100101": // OR
                    case "101010": // SLT
                    case "010110": // Shift Right
                        this.mem.ALUOutput = this.execute.ALUOutput;
                        this.execute.Cond = 0;
                        break;
                }
            }
        }

        private void GetWB(string instruction)
        {
            string opcode = instruction.HexToBin().Substring(0, 6);
            int register = 0;
            switch (opcode)
            {
                case "011001": // DADDIU
                    register = instruction.HexToBin().Substring(11, 5).BinToDec();
                    this.registers.Find(x => x.Index == register).Value = this.mem.ALUOutput;
                    break;
                case "110111": // LD
                    register = instruction.HexToBin().Substring(11, 5).BinToDec();
                    this.registers.Find(x => x.Index == register).Value = this.mem.LMD;
                    break;
                case "000000": //R-Type
                    register = instruction.HexToBin().Substring(16, 5).BinToDec();
                    this.registers.Find(x => x.Index == register).Value = this.mem.ALUOutput;
                    break;
                default:
                    break;
            }

            if (IsLastInstruction(instruction))
            {
                IsLastCycle = true;
            }
        }

        private bool CheckStallStatus(int address)
        {

            // if instruction is previous, allow them to pass
            if(address < this.fetch.PC)
            {
                return true;
            }

            return !this.stall.IsStall;
        }


        private bool IsLastInstruction(string instruction)
        {
            if (this.statements.Last().Opcode == instruction)
            {
                return true;
            }

            return false;
        }


        private void AddToPipeline(DataTable pipeline, int instruction, int cycle, string stage)
        {
            for (int i = 0; i < pipeline.Rows.Count; i++)
            {
                int currentRow = (int)pipeline.Rows[i][1];
                if (currentRow == instruction)
                {
                    pipeline.Rows[i][cycle + 1] = stage;
                }
            }

        }
        #endregion
    }
}
