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
            string code = "OR R1, R0, R2";
            List<Statement> statements = parser.Parse(code).ToList();

            OpcodeGenerator opcodeGenerator = new OpcodeGenerator();
            Console.WriteLine("Binary: {0}",opcodeGenerator.GetOpcode(statements[0]).HexToBin());
            Console.WriteLine("Hex: {0}", opcodeGenerator.GetOpcode(statements[0]));
            opcodeGenerator.GetOpcode
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MIPSWindow());
        }
    }
}
