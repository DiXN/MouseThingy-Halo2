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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lstProcessList = new System.Windows.Forms.ComboBox();
            this.txtHorizontalSensitivity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnActivate = new System.Windows.Forms.Button();
            this.txtHorizontalViewAngleAddress = new System.Windows.Forms.TextBox();
            this.txtVerticalViewAngleAddress = new System.Windows.Forms.TextBox();
            this.txtVerticalSensitivity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numFoV = new System.Windows.Forms.NumericUpDown();
            this.numViewOffset = new System.Windows.Forms.NumericUpDown();
            this.barRummageProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numFoV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update Processes";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.bnUpdate_Click);
            // 
            // lstProcessList
            // 
            this.lstProcessList.FormattingEnabled = true;
            this.lstProcessList.Location = new System.Drawing.Point(128, 12);
            this.lstProcessList.Name = "lstProcessList";
            this.lstProcessList.Size = new System.Drawing.Size(257, 21);
            this.lstProcessList.TabIndex = 1;
            this.lstProcessList.SelectionChangeCommitted += new System.EventHandler(this.processList_SelectionChangeCommitted);
            // 
            // txtHorizontalSensitivity
            // 
            this.txtHorizontalSensitivity.Location = new System.Drawing.Point(12, 105);
            this.txtHorizontalSensitivity.Name = "txtHorizontalSensitivity";
            this.txtHorizontalSensitivity.Size = new System.Drawing.Size(64, 20);
            this.txtHorizontalSensitivity.TabIndex = 10;
            this.txtHorizontalSensitivity.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Horizontal Sensitivity";
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(12, 39);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(373, 23);
            this.btnActivate.TabIndex = 12;
            this.btnActivate.Text = "Activate!";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // txtHorizontalViewAngleAddress
            // 
            this.txtHorizontalViewAngleAddress.Location = new System.Drawing.Point(214, 105);
            this.txtHorizontalViewAngleAddress.Name = "txtHorizontalViewAngleAddress";
            this.txtHorizontalViewAngleAddress.Size = new System.Drawing.Size(70, 20);
            this.txtHorizontalViewAngleAddress.TabIndex = 13;
            this.txtHorizontalViewAngleAddress.Text = "805326032";
            // 
            // txtVerticalViewAngleAddress
            // 
            this.txtVerticalViewAngleAddress.Location = new System.Drawing.Point(214, 131);
            this.txtVerticalViewAngleAddress.Name = "txtVerticalViewAngleAddress";
            this.txtVerticalViewAngleAddress.Size = new System.Drawing.Size(70, 20);
            this.txtVerticalViewAngleAddress.TabIndex = 13;
            this.txtVerticalViewAngleAddress.Text = "805326036";
            // 
            // txtVerticalSensitivity
            // 
            this.txtVerticalSensitivity.Location = new System.Drawing.Point(12, 131);
            this.txtVerticalSensitivity.Name = "txtVerticalSensitivity";
            this.txtVerticalSensitivity.Size = new System.Drawing.Size(64, 20);
            this.txtVerticalSensitivity.TabIndex = 10;
            this.txtVerticalSensitivity.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vertical Sensitivity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "H Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "V Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Field of View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Crosshair Offset";
            // 
            // numFoV
            // 
            this.numFoV.DecimalPlaces = 2;
            this.numFoV.Location = new System.Drawing.Point(12, 183);
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
            this.numFoV.Size = new System.Drawing.Size(120, 20);
            this.numFoV.TabIndex = 23;
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
            this.numViewOffset.Location = new System.Drawing.Point(236, 183);
            this.numViewOffset.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numViewOffset.Name = "numViewOffset";
            this.numViewOffset.Size = new System.Drawing.Size(120, 20);
            this.numViewOffset.TabIndex = 24;
            this.numViewOffset.Value = new decimal(new int[] {
            165,
            0,
            0,
            196608});
            // 
            // barRummageProgress
            // 
            this.barRummageProgress.Location = new System.Drawing.Point(12, 68);
            this.barRummageProgress.Name = "barRummageProgress";
            this.barRummageProgress.Size = new System.Drawing.Size(373, 23);
            this.barRummageProgress.Step = 1;
            this.barRummageProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barRummageProgress.TabIndex = 27;
            // 
            // frmMouseThingy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 214);
            this.Controls.Add(this.barRummageProgress);
            this.Controls.Add(this.numViewOffset);
            this.Controls.Add(this.numFoV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVerticalViewAngleAddress);
            this.Controls.Add(this.txtHorizontalViewAngleAddress);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVerticalSensitivity);
            this.Controls.Add(this.txtHorizontalSensitivity);
            this.Controls.Add(this.lstProcessList);
            this.Controls.Add(this.btnUpdate);
            this.Name = "frmMouseThingy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Halo 2 Fixer Upper";
            ((System.ComponentModel.ISupportInitialize)(this.numFoV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox lstProcessList;
        private System.Windows.Forms.TextBox txtHorizontalSensitivity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.TextBox txtHorizontalViewAngleAddress;
        private System.Windows.Forms.TextBox txtVerticalViewAngleAddress;
        private System.Windows.Forms.TextBox txtVerticalSensitivity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFoV;
        public System.Windows.Forms.ProgressBar barRummageProgress;
        public System.Windows.Forms.NumericUpDown numViewOffset;
    }
}

