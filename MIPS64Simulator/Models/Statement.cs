using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Models
{
    public class Statement
    {
        public int Line { get; set; }

        public string Label { get; set; }

        public string Instruction { get; set; }

        public string RS { get; set; }

        public string RD { get; set; }

        public string RT { get; set; }

        public string Immediate { get; set; }

        public string Base { get; set; }

        public string Offset { get; set; }

        public string InstructionIndex { get; set; }

        public InstructionType InstructionType { get; set; }

        public Int32 Opcode { get; set; }

      
    }
}
