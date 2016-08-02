using MIPS64Simulator.Helper;
using MIPS64Simulator.Implementation;
using MIPS64Simulator.Interface;
using MIPS64Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS64Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IParser parser = new Parser();
            string code = "SD R2,1234(R31)";
            List<Statement> statements = parser.Parse(code).ToList();

            OpcodeGenerator opcodeGenerator = new OpcodeGenerator();
            opcodeGenerator.GetOpcode(statements[0]);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MIPSWindow());
        }
    }
}
