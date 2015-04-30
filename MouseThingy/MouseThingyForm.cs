using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseThingy
{
    public partial class frmMouseThingy : Form
    {

        public frmMouseThingy()
        {
            SuspendLayout();
            InitializeComponent();
            UpdateProcesses();
            MouseThingy.MainForm = this;
            numFoV.ValueChanged += numFoV_ValueChanged;
            numViewOffset.ValueChanged += numViewOffset_ValueChanged;
            ResumeLayout();
        }

        /// <summary>
        /// Actually performs the write to crosshair offset memory.
        /// </summary>
        public void writeCrosshairOffsetToMemory()
        {
            // Read the address the pointer is pointing to
            uint crosshairOffsetAddress = (uint)HaloMemoryWriter.BaseAddress.ToInt32() + MouseThingy.CROSSHAIR_OFFSET_POINTER;
            byte[] crosshairOffsetData = new byte[4];
            // Offset that address by the crosshair offset
            HaloMemoryWriter.ReadFromMemory(crosshairOffsetAddress, crosshairOffsetData);
            // Write the current crosshair offset to that memory address
            HaloMemoryWriter.WriteToMemory((uint)((uint)(BitConverter.ToInt32(crosshairOffsetData, 0)) + MouseThingy.CROSSHAIR_OFFSET_POINTER_OFFSET), BitConverter.GetBytes((float)numViewOffset.Value));
        }

        /// <summary>
        /// Actually performs the write to fov memory.
        /// </summary>
        public void writeFOVToMemory()
        {
            // Find the proper value from degrees
            float targetRadians = (float)((double)numFoV.Value * Math.PI / 180);

            // Write the value to the vehicle and player FOV's
            HaloMemoryWriter.WriteToMemory((uint)HaloMemoryWriter.BaseAddress + MouseThingy.FOV_MULTIPLIER_OFFSET, BitConverter.GetBytes(targetRadians / MouseThingy.DEFAULT_RADIANS));
            HaloMemoryWriter.WriteToMemory((uint)HaloMemoryWriter.BaseAddress + MouseThingy.FOV_VEHICLE_MULTIPLIER_OFFSET, BitConverter.GetBytes(targetRadians / MouseThingy.DEFAULT_RADIANS));
        }

        void numViewOffset_ValueChanged(object sender, EventArgs e)
        {
            writeCrosshairOffsetToMemory();
        }

        void numFoV_ValueChanged(object sender, EventArgs e)
        {
            writeFOVToMemory();
        }

        private void bnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        /// <summary>
        /// Gets all the processes and adds them to the dropdown list
        /// </summary>
        private void UpdateProcesses()
        {
            lstProcessList.SuspendLayout();
            lstProcessList.Items.Clear();
            List<string> processNames = HaloMemoryWriter.GetProcessNames();
            for (int i = 0; i < processNames.Count; i++ )
            {
                lstProcessList.Items.Add(processNames[i]);
                if (processNames[i] == "halo2")
                {
                    if (HaloMemoryWriter.TryConnectToProcess(processNames[i]))
                    {
                        lstProcessList.SelectedIndex = i;
                    }
                }
            }
            lstProcessList.ResumeLayout();
        }

        private void processList_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (lstProcessList.SelectedItem != null)
                HaloMemoryWriter.TryConnectToProcess(lstProcessList.SelectedItem.ToString());
        }

        public float GetHMul()
        {
            return (float)numHorizontalSensitivity.Value;
        }

        public bool GetHAddr(out uint addr)
        {
            return uint.TryParse(txtHorizontalViewAngleAddress.Text, out addr);
        }

        public float GetVMul()
        {
            return (float)numVerticalSensitivity.Value;
        }

        public bool GetVAddr(out uint addr)
        {
            return uint.TryParse(txtVerticalViewAngleAddress.Text, out addr);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            MouseInput.Start();
            writeFOVToMemory();
            writeCrosshairOffsetToMemory();
            barRummageProgress.Value = barRummageProgress.Maximum;
            lblStatus.Text = "Activated";
        }
    }
}
