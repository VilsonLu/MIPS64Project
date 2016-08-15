using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Models.Pipeline
{
    public class MEM
    {
        public Int64 LMD { get; set; }

        public Int64 ALUOutput { get; set; }

        public string IR { get; set; }
        public int NPC { get; set; }
    }
}
