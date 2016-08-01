using MIPS64Simulator.Interface;
using MIPS64Simulator.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS64Simulator
{
    public partial class MIPSWindow : Form, IView
    {
        private IPresenter presenter;
        public MIPSWindow()
        {
            InitializeComponent();
            this.presenter = new MIPSPresenter(this);
        }

        private string fileName;
        public string Filename
        {
            get
            {
                return fileName;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select a Text File";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.fileName = openFileDialog.FileName;
            }

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.presenter.Run();
        }
    }
}
