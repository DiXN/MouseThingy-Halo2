﻿namespace MouseThingy
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
            this.txtHorizontalSensitivity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.MemoryWriteTimer = new System.Windows.Forms.Timer(this.components);
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.statusPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFoV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewOffset)).BeginInit();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHorizontalSensitivity
            // 
            this.txtHorizontalSensitivity.BackColor = System.Drawing.SystemColors.Control;
            this.txtHorizontalSensitivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHorizontalSensitivity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHorizontalSensitivity.Location = new System.Drawing.Point(13, 62);
            this.txtHorizontalSensitivity.Name = "txtHorizontalSensitivity";
            this.txtHorizontalSensitivity.Size = new System.Drawing.Size(64, 20);
            this.txtHorizontalSensitivity.TabIndex = 10;
            this.txtHorizontalSensitivity.Text = "2.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(83, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Horizontal Sensitivity";
            // 
            // txtHorizontalViewAngleAddress
            // 
            this.txtHorizontalViewAngleAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtHorizontalViewAngleAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHorizontalViewAngleAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtHorizontalViewAngleAddress.Location = new System.Drawing.Point(191, 62);
            this.txtHorizontalViewAngleAddress.Name = "txtHorizontalViewAngleAddress";
            this.txtHorizontalViewAngleAddress.Size = new System.Drawing.Size(70, 20);
            this.txtHorizontalViewAngleAddress.TabIndex = 13;
            this.txtHorizontalViewAngleAddress.Text = "805326032";
            // 
            // txtVerticalViewAngleAddress
            // 
            this.txtVerticalViewAngleAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtVerticalViewAngleAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVerticalViewAngleAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVerticalViewAngleAddress.Location = new System.Drawing.Point(191, 88);
            this.txtVerticalViewAngleAddress.Name = "txtVerticalViewAngleAddress";
            this.txtVerticalViewAngleAddress.Size = new System.Drawing.Size(70, 20);
            this.txtVerticalViewAngleAddress.TabIndex = 13;
            this.txtVerticalViewAngleAddress.Text = "805326036";
            // 
            // txtVerticalSensitivity
            // 
            this.txtVerticalSensitivity.BackColor = System.Drawing.SystemColors.Control;
            this.txtVerticalSensitivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVerticalSensitivity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtVerticalSensitivity.Location = new System.Drawing.Point(13, 88);
            this.txtVerticalSensitivity.Name = "txtVerticalSensitivity";
            this.txtVerticalSensitivity.Size = new System.Drawing.Size(64, 20);
            this.txtVerticalSensitivity.TabIndex = 10;
            this.txtVerticalSensitivity.Text = "2.2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(83, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vertical Sensitivity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(267, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "H Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(267, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "V Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(10, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Field of View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(217, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Crosshair Offset";
            // 
            // numFoV
            // 
            this.numFoV.BackColor = System.Drawing.SystemColors.Control;
            this.numFoV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numFoV.DecimalPlaces = 2;
            this.numFoV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numFoV.Location = new System.Drawing.Point(13, 139);
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
            90,
            0,
            0,
            0});
            // 
            // numViewOffset
            // 
            this.numViewOffset.BackColor = System.Drawing.SystemColors.Control;
            this.numViewOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numViewOffset.DecimalPlaces = 3;
            this.numViewOffset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numViewOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numViewOffset.Location = new System.Drawing.Point(202, 139);
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
            // MemoryWriteTimer
            // 
            this.MemoryWriteTimer.Enabled = true;
            this.MemoryWriteTimer.Interval = 1000;
            this.MemoryWriteTimer.Tick += new System.EventHandler(this.MemoryWriteTimer_Tick);
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Enabled = false;
            this.ActivateBtn.Location = new System.Drawing.Point(220, 33);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(102, 23);
            this.ActivateBtn.TabIndex = 27;
            this.ActivateBtn.Text = "Activate(PGUP)";
            this.ActivateBtn.UseVisualStyleBackColor = true;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click);
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.Red;
            this.statusPanel.ColumnCount = 1;
            this.statusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.statusPanel.Controls.Add(this.statusLabel, 0, 0);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusPanel.Location = new System.Drawing.Point(0, 0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.RowCount = 1;
            this.statusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statusPanel.Size = new System.Drawing.Size(331, 29);
            this.statusPanel.TabIndex = 28;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(3, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(325, 29);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMouseThingy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(331, 176);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.numViewOffset);
            this.Controls.Add(this.numFoV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVerticalViewAngleAddress);
            this.Controls.Add(this.txtHorizontalViewAngleAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVerticalSensitivity);
            this.Controls.Add(this.txtHorizontalSensitivity);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMouseThingy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Halo 2 MouseThingy";
            ((System.ComponentModel.ISupportInitialize)(this.numFoV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViewOffset)).EndInit();
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHorizontalSensitivity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHorizontalViewAngleAddress;
        private System.Windows.Forms.TextBox txtVerticalViewAngleAddress;
        private System.Windows.Forms.TextBox txtVerticalSensitivity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFoV;
        public System.Windows.Forms.NumericUpDown numViewOffset;
        private System.Windows.Forms.Timer MemoryWriteTimer;
        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.TableLayoutPanel statusPanel;
        private System.Windows.Forms.Label statusLabel;
    }
}

