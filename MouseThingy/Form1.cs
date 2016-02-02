using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;
using System.Reflection;

namespace MouseThingy
{
    public partial class frmMouseThingy : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd,
          int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public frmMouseThingy()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
            MouseThingy.MainForm = this;
            numFoV.ValueChanged += numFoV_ValueChanged;
            numViewOffset.ValueChanged += numViewOffset_ValueChanged;
            //numViewOffset.Enabled = false;
            frmMouseThingy.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 0, (int)0x21);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                if (Process.GetProcessesByName("halo2").Length > 0)
                {
                    HaloMemoryWriter.TryConnectToProcess(Process.GetProcessesByName("halo2").ToString());
                    MouseInput.Start();
                    writeFOVToMemory();
                    writeCrosshairOffsetToMemory();
                }
            }
            base.WndProc(ref m);
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

        private void frmMouseThingy_Load(object sender, EventArgs e)
        {

        }

        private void MemoryWriteTimer_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("halo2").Length > 0)
            {
                ActivateBtn.Enabled = true;
                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "Halo 2 process detected.";
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Halo 2 process not detected..";
                ActivateBtn.Enabled = false;
            }
        }

        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            HaloMemoryWriter.TryConnectToProcess(Process.GetProcessesByName("halo2").ToString());
            MouseInput.Start();
            writeFOVToMemory();
            writeCrosshairOffsetToMemory();
        }
    }
}
