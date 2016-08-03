using MIPS64Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Helper
{
    public class OpcodeGenerator
    {
        private Dictionary<string, string> InstructionSet;
        private Dictionary<string, string> FuncSet;

        public OpcodeGenerator()
        {
            InitializeGenerator();
        }

        private void InitializeGenerator()
        {
            #region Opcode
            this.InstructionSet = new Dictionary<string, string>();
            // I-Type
            this.InstructionSet.Add("DADDIU", "011001");
            this.InstructionSet.Add("BNE", "000101");
            this.InstructionSet.Add("LD", "110111");
            this.InstructionSet.Add("SD", "111111");
            // R-Type
            this.InstructionSet.Add("OR", "000000");
            this.InstructionSet.Add("DSRLV", "000000");
            this.InstructionSet.Add("SLT", "000000");
            this.InstructionSet.Add("NOP", "000000");
            // J-Type
            this.InstructionSet.Add("J", "000010");
            #endregion
            #region Func
            this.FuncSet = new Dictionary<string, string>();
            this.FuncSet.Add("OR", "100101");
            this.FuncSet.Add("DSRLV", "010110");
            this.FuncSet.Add("SLT", "101010");
            this.FuncSet.Add("NOP", "0000000");
            #endregion
        }

        /// <summary>
        /// This returns the opcode of an instruction (Hex).
        /// </summary>
        /// <param name="statement"></param>
        /// <returns>Returns the opcode in hex.</returns>
        public string GetOpcode(Statement statement)
        {
            switch (statement.InstructionType)
            {
                case InstructionType.IType: return GetITypeOpcode(statement).BinToHex();
                case InstructionType.RType: return GetRTypeOpcode(statement).BinToHex();
                default: return String.Empty;
            }            
        }

        #region Opcode Generators
        /// <summary>
        /// Builds the opcode for I-Type instructions
        /// </summary>
        /// <param name="statement"></param>
        /// <returns>string</returns>
        private string GetITypeOpcode(Statement statement)
        {
            StringBuilder binaryString = new StringBuilder();

            string opcode = this.InstructionSet[statement.Instruction];

            if (statement.Instruction.ToUpperInvariant() == "DADDIU")
            {
                // opcode
                binaryString.Append(opcode);
                // rs
                string rs = Convert.ToString(GetRegister(statement.RS), 2).PadLeft(5, '0');
                binaryString.Append(rs);
                // rt
                string rt = Convert.ToString(GetRegister(statement.RT), 2).PadLeft(5, '0');
                binaryString.Append(rt);
                // immediate
                for (int i = 0; i < statement.Immediate.Count(); i++)
                {
                    string num = Convert.ToString(int.Parse(statement.Immediate[i].ToString()), 2).PadLeft(4, '0');
                    binaryString.Append(num);
                }
            }
            else if (statement.Instruction.ToUpperInvariant() == "SD"
                      || statement.Instruction.ToUpperInvariant() == "LD")
            {
                // opcode
                binaryString.Append(opcode);

                // base
                string baseRegister = Convert.ToString(GetRegister(statement.Base), 2).PadLeft(5, '0');
                binaryString.Append(baseRegister);

                // rt
                string rt = Convert.ToString(GetRegister(statement.RT), 2).PadLeft(5, '0');
                binaryString.Append(rt);
                // offset
                for (int i = 0; i < statement.Offset.Count(); i++)
                {
                    string num = Convert.ToString(int.Parse(statement.Offset[i].ToString()), 2).PadLeft(4, '0');
                    binaryString.Append(num);
                }
            }
            else if (statement.Instruction.ToUpperInvariant() == "BNE")
            {
                // opcode
                binaryString.Append(opcode);
                // rs
                string rs = Convert.ToString(GetRegister(statement.RS), 2).PadLeft(5, '0');
                binaryString.Append(rs);
                // rt
                string rt = Convert.ToString(GetRegister(statement.RT), 2).PadLeft(5, '0');
                binaryString.Append(rt);
                // offset
                // offset
                for (int i = 0; i < statement.Offset.Count(); i++)
                {
                    string num = Convert.ToString(int.Parse(statement.Offset[i].ToString()), 2).PadLeft(4, '0');
                    binaryString.Append(num);
                }

            }

            return binaryString.ToString();
        }

        /// <summary>
        /// Builds the opcode for R-Type instructions
        /// </summary>
        /// <param name="statement"></param>
        /// <returns>string</returns>
        private string GetRTypeOpcode(Statement statement)
        {
            StringBuilder binaryString = new StringBuilder();

            binaryString.Append("000000");

            if(statement.Instruction.ToUpperInvariant() == "NOP")
            {
                binaryString.Insert(5, "0", 26);
            } else
            {
                // rs
                string rs = Convert.ToString(GetRegister(statement.RS), 2).PadLeft(5, '0');
                binaryString.Append(rs);
                // rt 
                string rt = Convert.ToString(GetRegister(statement.RT), 2).PadLeft(5, '0');
                binaryString.Append(rt);
                // rd
                string rd = Convert.ToString(GetRegister(statement.RD), 2).PadLeft(5, '0');
                binaryString.Append(rd);
                // op(5)
                binaryString.Append("00000");
                // func
                binaryString.Append(this.FuncSet[statement.Instruction]);
            }
            return binaryString.ToString();
        }

        /// <summary>
        /// Builds the opcode for J-Type instructions
        /// </summary>
        /// <param name="statement"></param>
        /// <returns>string</returns>
        private string GetJTypeOpcode(Statement statement)
        {
            StringBuilder binaryString = new StringBuilder();
            
            if(statement.Instruction.ToUpperInvariant() == "J")
            {
                binaryString.Append(this.InstructionSet[statement.Instruction]);
            }

            return string.Empty;
        }
        #endregion

        #region Helper Methods
        private int GetRegister(string register)
        {
            return int.Parse(register.Replace("R", ""));
        }
        #endregion
    }
}
