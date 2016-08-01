using MIPS64Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Interface
{
    public interface IParser
    {
        IEnumerable<Statement> Parse(string text);
    }
}
