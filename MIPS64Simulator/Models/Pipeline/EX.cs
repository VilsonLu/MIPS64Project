using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Models.Pipeline
{
    public class EX
    {
        public Int64 ALUOutput { get; set; }

        public int Cond { get; set; }

        public Int64 B { get; set; }

        public string IR { get; set; }

        public Int32 NPC { get; set; }

    }
}
