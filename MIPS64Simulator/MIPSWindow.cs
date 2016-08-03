using MIPS64Simulator.Interface;
using MIPS64Simulator.Models;
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
            grdInstructions.AutoGenerateColumns = false;
        }

        private string fileName;
        public string Filename
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public string ExceptionMessage
        {
            set
            {
                MessageBox.Show(value);
            }
        }

        public IEnumerable<Statement> Statements
        {
            get
            {
                return grdInstructions.DataSource as List<Statement>;
            }
            set
            {
                List<Statement> source = value.ToList();
                grdInstructions.DataSource = source;
            }
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select a Text File";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Filename = openFileDialog.FileName;
                this.presenter.LoadProgram();
            }

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.presenter.Run();
        }
    }
}
