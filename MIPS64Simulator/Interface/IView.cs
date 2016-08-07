using MIPS64Simulator.Models;
using System.Collections.Generic;

namespace MIPS64Simulator.Interface
{
    public interface IView
    {
        string Filename { get; set; }

        string ExceptionMessage { set; }

        bool EnableRun { get; set; }

        IEnumerable<Statement> Statements { get; set; } 

        IEnumerable<Register> Registers { get; set; }

        IEnumerable<Data> Data { get; set; }
    }
}
