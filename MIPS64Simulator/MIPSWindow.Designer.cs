namespace MIPS64Simulator
{
    partial class MIPSWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCode = new System.Windows.Forms.Label();
            this.grdInstructions = new System.Windows.Forms.DataGridView();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInstruction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRegister = new System.Windows.Forms.Label();
            this.grdRegisters = new System.Windows.Forms.DataGridView();
            this.colRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMemory = new System.Windows.Forms.Label();
            this.grdMemory = new System.Windows.Forms.DataGridView();
            this.colMemAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPipeline = new System.Windows.Forms.Label();
            this.grdPipeline = new System.Windows.Forms.DataGridView();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstructions)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRegisters)).BeginInit();
            this.statusBar.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemory)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPipeline)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblCode);
            this.flowLayoutPanel1.Controls.Add(this.grdInstructions);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(375, 313);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(3, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(51, 20);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code";
            // 
            // grdInstructions
            // 
            this.grdInstructions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInstructions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAddress,
            this.colInstruction,
            this.colOpcode});
            this.grdInstructions.Location = new System.Drawing.Point(3, 23);
            this.grdInstructions.Name = "grdInstructions";
            this.grdInstructions.RowHeadersVisible = false;
            this.grdInstructions.Size = new System.Drawing.Size(371, 285);
            this.grdInstructions.TabIndex = 0;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddress.DataPropertyName = "Line";
            dataGridViewCellStyle1.Format = "X4";
            this.colAddress.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAddress.FillWeight = 103.0928F;
            this.colAddress.HeaderText = "Address";
            this.colAddress.MinimumWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colInstruction
            // 
            this.colInstruction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInstruction.DataPropertyName = "Code";
            this.colInstruction.FillWeight = 96.90722F;
            this.colInstruction.HeaderText = "Instruction";
            this.colInstruction.MinimumWidth = 150;
            this.colInstruction.Name = "colInstruction";
            this.colInstruction.ReadOnly = true;
            // 
            // colOpcode
            // 
            this.colOpcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOpcode.DataPropertyName = "Opcode";
            this.colOpcode.HeaderText = "Opcode";
            this.colOpcode.MinimumWidth = 100;
            this.colOpcode.Name = "colOpcode";
            this.colOpcode.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.executeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.executeToolStripMenuItem.Text = "Execute";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblRegister);
            this.flowLayoutPanel2.Controls.Add(this.grdRegisters);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(393, 27);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(229, 313);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.Location = new System.Drawing.Point(3, 0);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(77, 20);
            this.lblRegister.TabIndex = 1;
            this.lblRegister.Text = "Register";
            // 
            // grdRegisters
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.grdRegisters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRegisters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRegisters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRegister,
            this.colValue});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRegisters.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdRegisters.Location = new System.Drawing.Point(3, 23);
            this.grdRegisters.Name = "grdRegisters";
            this.grdRegisters.RowHeadersVisible = false;
            this.grdRegisters.Size = new System.Drawing.Size(223, 285);
            this.grdRegisters.TabIndex = 0;
            this.grdRegisters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRegisters_CellClick);
            this.grdRegisters.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdRegisters_DataError);
            // 
            // colRegister
            // 
            this.colRegister.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRegister.DataPropertyName = "RegisterName";
            this.colRegister.HeaderText = "Register";
            this.colRegister.MinimumWidth = 40;
            this.colRegister.Name = "colRegister";
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValue.DataPropertyName = "Value";
            dataGridViewCellStyle3.Format = "X16";
            this.colValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValue.HeaderText = "Value";
            this.colValue.MinimumWidth = 150;
            this.colValue.Name = "colValue";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 314);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripValue,
            this.statusStrip});
            this.statusBar.Location = new System.Drawing.Point(0, 545);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(881, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "Pipeline";
            // 
            // toolStripValue
            // 
            this.toolStripValue.Name = "toolStripValue";
            this.toolStripValue.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip
            // 
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(0, 17);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.lblMemory);
            this.flowLayoutPanel4.Controls.Add(this.grdMemory);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(628, 27);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(246, 313);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemory.Location = new System.Drawing.Point(3, 0);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(71, 20);
            this.lblMemory.TabIndex = 0;
            this.lblMemory.Text = "Memory";
            // 
            // grdMemory
            // 
            this.grdMemory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMemory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemAddress,
            this.colMemValue});
            this.grdMemory.Location = new System.Drawing.Point(3, 23);
            this.grdMemory.Name = "grdMemory";
            this.grdMemory.RowHeadersVisible = false;
            this.grdMemory.Size = new System.Drawing.Size(240, 285);
            this.grdMemory.TabIndex = 1;
            // 
            // colMemAddress
            // 
            this.colMemAddress.DataPropertyName = "Address";
            this.colMemAddress.HeaderText = "Address";
            this.colMemAddress.MinimumWidth = 40;
            this.colMemAddress.Name = "colMemAddress";
            // 
            // colMemValue
            // 
            this.colMemValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemValue.DataPropertyName = "Value";
            dataGridViewCellStyle5.Format = "X16";
            this.colMemValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMemValue.HeaderText = "Value";
            this.colMemValue.MinimumWidth = 100;
            this.colMemValue.Name = "colMemValue";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lblPipeline);
            this.flowLayoutPanel5.Controls.Add(this.grdPipeline);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(12, 346);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(862, 162);
            this.flowLayoutPanel5.TabIndex = 6;
            // 
            // lblPipeline
            // 
            this.lblPipeline.AutoSize = true;
            this.lblPipeline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPipeline.Location = new System.Drawing.Point(3, 0);
            this.lblPipeline.Name = "lblPipeline";
            this.lblPipeline.Size = new System.Drawing.Size(72, 20);
            this.lblPipeline.TabIndex = 2;
            this.lblPipeline.Text = "Pipeline";
            // 
            // grdPipeline
            // 
            this.grdPipeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPipeline.Location = new System.Drawing.Point(3, 23);
            this.grdPipeline.Name = "grdPipeline";
            this.grdPipeline.Size = new System.Drawing.Size(854, 139);
            this.grdPipeline.TabIndex = 1;
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // MIPSWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 567);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MIPSWindow";
            this.Text = "MicroMIPS";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstructions)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRegisters)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemory)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPipeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.DataGridView grdInstructions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridView grdRegisters;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripValue;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpcode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.DataGridView grdMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemValue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblPipeline;
        private System.Windows.Forms.DataGridView grdPipeline;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}

