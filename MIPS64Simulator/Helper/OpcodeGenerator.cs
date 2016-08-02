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

        public OpcodeGenerator()
        {
            InitializeGenerator();
        }

        private void InitializeGenerator()
        {
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
            this.InstructionSet.Add("J", "000000");
        }

        public string GetOpcode(Statement statement)
        {
            string binaryString = String.Empty;

            Console.WriteLine("Integer: {0}, Binary: {1}", Convert.ToInt32(GetITypeOpcode(statement), 2), GetITypeOpcode(statement));
            Console.WriteLine("Hex: {0}", Convert.ToInt32(GetITypeOpcode(statement), 2).ToString("X4"));
            return String.Empty;
        }

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

        private int GetRegister(string register)
        {
            return int.Parse(register.Replace("R", ""));
        }
    }
}
