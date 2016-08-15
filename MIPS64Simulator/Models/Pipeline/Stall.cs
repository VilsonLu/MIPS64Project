using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Models.Pipeline
{
    public class Stall
    {
        public bool IsStall { get; set; }
        public int Address { get; set; }
    }
}
