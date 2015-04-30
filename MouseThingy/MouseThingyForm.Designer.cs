namespace MouseThingy
{
    partial class frmMouseThingy
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
            this.btnRefreshProcesses = new System.Windows.Forms.Button();
            this.lstProcessList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnActivate = new System.Windows.Forms.Button();
            this.txtHorizontalViewAngleAddress = new System.Windows.Forms.TextBox();
            this.txtVerticalViewAngleAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numFoV = new System.Windows.Forms.NumericUpDown();
            this.numViewOffset = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.barRummageProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.numHorizontalSensitivity = new System.Windows.Forms.NumericUpDown();
            this.numVerticalSensitivity = new System.Windows.Forms.NumericUpDown();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numFoV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewOffset)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizontalSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticalSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshProcesses
            // 
            this.btnRefreshProcesses.Location = new System.Drawing.Point(12, 12);
            this.btnRefreshProcesses.Name = "btnRefreshProcesses";
            this.btnRefreshProcesses.Size = new System.Drawing.Size(110, 23);
            this.btnRefreshProcesses.TabIndex = 0;
            this.btnRefreshProcesses.Text = "Refresh Processes";
            this.ToolTip.SetToolTip(this.btnRefreshProcesses, "Refreshes the list of processes");
            this.btnRefreshProcesses.UseVisualStyleBackColor = true;
            this.btnRefreshProcesses.Click += new System.EventHandler(this.bnUpdate_Click);
            // 
            // lstProcessList
            // 
            this.lstProcessList.FormattingEnabled = true;
            this.lstProcessList.Location = new System.Drawing.Point(128, 12);
            this.lstProcessList.Name = "lstProcessList";
            this.lstProcessList.Size = new System.Drawing.Size(257, 21);
            this.lstProcessList.TabIndex = 1;
            this.ToolTip.SetToolTip(this.lstProcessList, "List of active processes. Look for halo2");
            this.lstProcessList.SelectionChangeCommitted += new System.EventHandler(this.processList_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Horizontal Sensitivity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(12, 39);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(373, 23);
            this.btnActivate.TabIndex = 12;
            this.btnActivate.Text = "&Activate!";
            this.ToolTip.SetToolTip(this.btnActivate, "Run the tool and fix your Halo2");
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // txtHorizontalViewAngleAddress
            // 
            this.txtHorizontalViewAngleAddress.Location = new System.Drawing.Point(315, 77);
            this.txtHorizontalViewAngleAddress.Name = "txtHorizontalViewAngleAddress";
            this.txtHorizontalViewAngleAddress.Size = new System.Drawing.Size(70, 20);
            this.txtHorizontalViewAngleAddress.TabIndex = 13;
            this.txtHorizontalViewAngleAddress.Text = "805326032";
            this.ToolTip.SetToolTip(this.txtHorizontalViewAngleAddress, "The address of the horizontal view angle");
            // 
            // txtVerticalViewAngleAddress
            // 
            this.txtVerticalViewAngleAddress.Location = new System.Drawing.Point(315, 103);
            this.txtVerticalViewAngleAddress.Name = "txtVerticalViewAngleAddress";
            this.txtVerticalViewAngleAddress.Size = new System.Drawing.Size(70, 20);
            this.txtVerticalViewAngleAddress.TabIndex = 13;
            this.txtVerticalViewAngleAddress.Text = "805326036";
            this.ToolTip.SetToolTip(this.txtVerticalViewAngleAddress, "The address of the vertical view angle\r\n");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vertical Sensitivity";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(198, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "H Address";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(198, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "V Address";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Field of View";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(198, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Crosshair Offset";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numFoV
            // 
            this.numFoV.DecimalPlaces = 2;
            this.numFoV.Location = new System.Drawing.Point(128, 130);
            this.numFoV.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numFoV.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFoV.Name = "numFoV";
            this.numFoV.Size = new System.Drawing.Size(64, 20);
            this.numFoV.TabIndex = 23;
            this.ToolTip.SetToolTip(this.numFoV, "The target Field of View in degrees. Default 70");
            this.numFoV.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // numViewOffset
            // 
            this.numViewOffset.DecimalPlaces = 3;
            this.numViewOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numViewOffset.Location = new System.Drawing.Point(315, 129);
            this.numViewOffset.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numViewOffset.Name = "numViewOffset";
            this.numViewOffset.Size = new System.Drawing.Size(70, 20);
            this.numViewOffset.TabIndex = 24;
            this.ToolTip.SetToolTip(this.numViewOffset, "The target crosshair offset. Default 0.165");
            this.numViewOffset.Value = new decimal(new int[] {
            165,
            0,
            0,
            196608});
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.barRummageProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 170);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(402, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(254, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.ToolTipText = "Application status";
            // 
            // barRummageProgress
            // 
            this.barRummageProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.barRummageProgress.Name = "barRummageProgress";
            this.barRummageProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.barRummageProgress.Size = new System.Drawing.Size(100, 16);
            this.barRummageProgress.ToolTipText = "Shows the progress of the current action";
            // 
            // numHorizontalSensitivity
            // 
            this.numHorizontalSensitivity.DecimalPlaces = 2;
            this.numHorizontalSensitivity.Location = new System.Drawing.Point(128, 78);
            this.numHorizontalSensitivity.Name = "numHorizontalSensitivity";
            this.numHorizontalSensitivity.Size = new System.Drawing.Size(64, 20);
            this.numHorizontalSensitivity.TabIndex = 29;
            this.ToolTip.SetToolTip(this.numHorizontalSensitivity, "The horizontal sensitivity for mouse movement");
            this.numHorizontalSensitivity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numVerticalSensitivity
            // 
            this.numVerticalSensitivity.DecimalPlaces = 2;
            this.numVerticalSensitivity.Location = new System.Drawing.Point(128, 104);
            this.numVerticalSensitivity.Name = "numVerticalSensitivity";
            this.numVerticalSensitivity.Size = new System.Drawing.Size(64, 20);
            this.numVerticalSensitivity.TabIndex = 30;
            this.ToolTip.SetToolTip(this.numVerticalSensitivity, "The vertical sensitivity for mouse movement");
            this.numVerticalSensitivity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // frmMouseThingy
            // 
            this.AcceptButton = this.btnActivate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 192);
            this.Controls.Add(this.numVerticalSensitivity);
            this.Controls.Add(this.numHorizontalSensitivity);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.numViewOffset);
            this.Controls.Add(this.txtVerticalViewAngleAddress);
            this.Controls.Add(this.txtHorizontalViewAngleAddress);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.lstProcessList);
            this.Controls.Add(this.btnRefreshProcesses);
            this.Controls.Add(this.numFoV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMouseThingy";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Halo 2 Fixer Upper";
            ((System.ComponentModel.ISupportInitialize)(this.numFoV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewOffset)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizontalSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticalSensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshProcesses;
        private System.Windows.Forms.ComboBox lstProcessList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.TextBox txtHorizontalViewAngleAddress;
        private System.Windows.Forms.TextBox txtVerticalViewAngleAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFoV;
        public System.Windows.Forms.NumericUpDown numViewOffset;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar barRummageProgress;
        private System.Windows.Forms.NumericUpDown numHorizontalSensitivity;
        private System.Windows.Forms.NumericUpDown numVerticalSensitivity;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}

