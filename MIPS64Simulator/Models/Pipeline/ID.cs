using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Models.Pipeline
{
    public class ID
    {
        public Int64 A { get; set; }

        public Int64 B { get; set; }

        public Int32 Imm { get; set; }

        public string IR { get; set; }
        public int NPC { get; set; }

    }
}
