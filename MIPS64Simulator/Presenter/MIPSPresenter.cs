using MIPS64Simulator.Implementation;
using MIPS64Simulator.Interface;
using MIPS64Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Presenter
{
    public class MIPSPresenter : IPresenter
    {
        private IView view;
        private IParser parser;
        
        public MIPSPresenter(IView view)
        {
            this.view = view;
            this.parser = new Parser();
        } 

        public void Run()
        {
            var x = view.Filename;
        }

        public void LoadProgram()
        {
            try
            {
                string filename = view.Filename;
                string text = System.IO.File.ReadAllText(filename);
                List<Statement> statements = parser.Parse(text).ToList();
                view.Statements = statements;
            } catch(Exception ex)
            {
                view.ExceptionMessage = ex.Message;
            }
           
        }
    }
}
