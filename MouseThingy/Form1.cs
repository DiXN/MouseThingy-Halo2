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
            InitializeComponent();
            UpdateProcesses();
            MouseThingy.MainForm = this;
            numFoV.ValueChanged += numFoV_ValueChanged;
            numViewOffset.ValueChanged += numViewOffset_ValueChanged;
            //numViewOffset.Enabled = false;
        }

        public void writeCrosshairOffsetToMemory()
        {
            uint crosshairOffsetAddress = (uint)HaloMemoryWriter.BaseAddress.ToInt32() + MouseThingy.CROSSHAIR_OFFSET_POINTER;
            byte[] crosshairOffsetData = new byte[4];
            HaloMemoryWriter.ReadFromMemory(crosshairOffsetAddress, crosshairOffsetData);
            HaloMemoryWriter.WriteToMemory((uint)((uint)(BitConverter.ToInt32(crosshairOffsetData, 0)) + MouseThingy.CROSSHAIR_OFFSET_POINTER_OFFSET), BitConverter.GetBytes((float)numViewOffset.Value));
        }

        public void writeFOVToMemory()
        {
            float defaultRadians = (float)(70 * Math.PI / 180);
            float targetRadians = (float)((double)numFoV.Value * Math.PI / 180);

            HaloMemoryWriter.WriteToMemory((uint)HaloMemoryWriter.BaseAddress + MouseThingy.FOV_MULTIPLIER_OFFSET, BitConverter.GetBytes(targetRadians / defaultRadians));
            HaloMemoryWriter.WriteToMemory((uint)HaloMemoryWriter.BaseAddress + MouseThingy.FOV_VEHICLE_MULTIPLIER_OFFSET, BitConverter.GetBytes(targetRadians / defaultRadians));
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

        private void UpdateProcesses()
        {
            lstProcessList.Items.Clear();

            HaloMemoryWriter.GetProcessNames().ForEach((string name) => lstProcessList.Items.Add(name));
        }

        private void processList_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (lstProcessList.SelectedItem != null)
                HaloMemoryWriter.TryConnectToProcess(lstProcessList.SelectedItem.ToString());
        }

        public bool GetHMul(out float hmul)
        {
            return float.TryParse(txtHorizontalSensitivity.Text, out hmul);
        }

        public bool GetHAddr(out uint addr)
        {
            return uint.TryParse(txtHorizontalViewAngleAddress.Text, out addr);
        }

        public bool GetVMul(out float hmul)
        {
            return float.TryParse(txtVerticalSensitivity.Text, out hmul);
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
            //numViewOffset.Enabled = true;
            
           /* uint viewOffsetAddress = 0;
            * if (HaloMemoryWriter.Rummage(0x20000000, 0x50000000, "CD CC 4C 3F 00 00 00 40 00 00 80 3F 66 66 66 3F", out viewOffsetAddress))
            {
                MouseThingy.ViewOffsetAddress = viewOffsetAddress-8;
                HaloMemoryWriter.WriteToMemory(MouseThingy.ViewOffsetAddress, BitConverter.GetBytes((float)numViewOffset.Value ));
                numViewOffset.Enabled = true;
            }
            else 
            {
                numViewOffset.Enabled = false;
            } */
        }
    }
}
