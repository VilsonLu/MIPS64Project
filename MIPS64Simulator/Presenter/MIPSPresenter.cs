using MIPS64Simulator.Implementation;
using MIPS64Simulator.Interface;
using MIPS64Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MIPS64Simulator.Helper;

namespace MIPS64Simulator.Presenter
{
    public class MIPSPresenter : IPresenter
    {

        #region Constants
        private string[] REGISTERS = {"R0","R1","R2","R3","R4","R5","R6","R7","R8","R9","R10",
        "R11","R12","R13","R14","R15","R16","R17","R18","R19","R20",
        "R21","R22","R23","R24","R25","R26","R27","R28","R29","R30","R31"};
        private const int MEMORY_SIZE = 200;
        #endregion
        private IView view;
        private IParser parser;

        public MIPSPresenter(IView view)
        {
            this.view = view;
            this.parser = new Parser();
            InitControls();
        }

        private void InitControls()
        {
            this.view.Registers = InitRegisters();
            this.view.Data = InitMemory();
            this.view.EnableRun = false;
        }

        private List<Register> InitRegisters()
        {
            List<Register> source = new List<Register>();

            for (int i = 0; i < this.REGISTERS.Count(); i++)
            {
                Int64 initValue = 0;
                var register = new Register()
                {
                    Index = i,
                    RegisterName = this.REGISTERS[i],
                    Value = initValue
                };
                source.Add(register);
            }

            return source;
        }

        private List<Data> InitMemory()
        {
            List<Data> source = new List<Data>();
            for (int i = 0; i < MEMORY_SIZE; i++)
            {
                int address = i * 8;

                var data = new Data()
                {
                    Address = address.DecToHex(4),
                    Value = 0
                };

                source.Add(data);
            }

            return source;
        }

        public void Run()
        {
            var x = view.Registers;
            var y = view.Data;
        }

        public void LoadProgram()
        {
            try
            {
                string filename = view.Filename;
                string text = System.IO.File.ReadAllText(filename);
                List<Statement> statements = parser.Parse(text).ToList();
                this.view.Statements = statements;
                this.view.EnableRun = true;
            }
            catch (Exception ex)
            {
                view.ExceptionMessage = ex.Message;
            }

        }
    }
}
