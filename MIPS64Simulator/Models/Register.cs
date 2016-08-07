using System;

namespace MIPS64Simulator.Models
{
    public class Register
    {
        public int Index { get; set; }
        public string RegisterName { get; set; }
        public Int64 Value { get; set; } 
    }
}