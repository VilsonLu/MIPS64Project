using MIPS64Simulator.Interface;
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
        
        public MIPSPresenter(IView view)
        {
            this.view = view;
        } 

        public void Run()
        {
            var x = view.Filename;
        }
    }
}
