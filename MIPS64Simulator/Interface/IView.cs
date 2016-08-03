﻿using MIPS64Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Interface
{
    public interface IView
    {
        string Filename { get; set; }

        string ExceptionMessage { set; }

        IEnumerable<Statement> Statements { get; set; } 
    }
}
