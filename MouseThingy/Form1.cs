using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace MouseThingy
{
    public partial class frmMouseThingy : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd,
          int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private Regex regex = new Regex("^[0-9]+\\.[0-9]+?$");

        private JsonHelper<JsonData> jsonHelper;

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
            frmMouseThingy.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 0, (int)0x21);
            jsonHelper = new JsonHelper<JsonData>();
            InitFileds();
        }

        public void InitFileds()
        {
            if (File.Exists("settings.json"))
            {
                JsonData data = jsonHelper.Deserialize(jsonHelper.ReadJsonFile());

                txtHorizontalSensitivity.Text = data.HorizontalSensitivty;
                txtVerticalSensitivity.Text = data.VerticalSensitvity;
                numFoV.Value = data.Fov;
                numViewOffset.Value = data.CrosshairOffset;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                if (Process.GetProcessesByName("halo2").Length > 0)
                {
                    HaloMemoryWriter.TryConnectToProcess();
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
            HaloMemoryWriter.WriteToMemory(((uint)(BitConverter.ToInt32(crosshairOffsetData, 0)) + MouseThingy.CROSSHAIR_OFFSET_POINTER_OFFSET), BitConverter.GetBytes((float)numViewOffset.Value));
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

            jsonHelper.OutputJsonToFile(jsonHelper.Serialize
                (new JsonData(numFoV.Value, numViewOffset.Value, txtHorizontalSensitivity.Text, txtVerticalSensitivity.Text)));
        }

        void numFoV_ValueChanged(object sender, EventArgs e)
        {
            writeFOVToMemory();

            jsonHelper.OutputJsonToFile(jsonHelper.Serialize
                (new JsonData(numFoV.Value, numViewOffset.Value, txtHorizontalSensitivity.Text, txtVerticalSensitivity.Text)));
        }

        public float HMul
        {
            get
            {
                if (regex.IsMatch(txtHorizontalSensitivity.Text))
                {
                    string text = txtHorizontalSensitivity.Text;
                    return text.Length > 3 ? float.Parse(text) / (float)Math.Pow(10, text.Length - 3) : float.Parse(text);
                }
                else
                {
                    return 2.2F;
                }
            }
        }

        public bool GetHAddr(out uint addr)
        {
            return uint.TryParse(txtHorizontalViewAngleAddress.Text, out addr);
        }

        public float VMul
        {
            get {
                if (regex.IsMatch(txtHorizontalSensitivity.Text))
                {
                    string text = txtVerticalSensitivity.Text;
                    return text.Length > 3 ? float.Parse(text) / (float)Math.Pow(10, text.Length - 3) : float.Parse(text);
                }
                else
                {
                    return 2.2F;
                }
            }
        }

        public bool GetVAddr(out uint addr)
        {
            return uint.TryParse(txtVerticalViewAngleAddress.Text, out addr);
        }

        private void MemoryWriteTimer_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("halo2").Length > 0)
            {
                ActivateBtn.Enabled = true;
                statusPanel.BackColor = Color.Green;
                statusLabel.Text = "Halo 2 process detected.";
                activate();
            }
            else
            {
                statusPanel.BackColor = Color.Red;
                statusLabel.Text = "Halo 2 process not detected.";
                ActivateBtn.Enabled = false;
            }
        }

        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            activate();
        }

        private void activate()
        {
            HaloMemoryWriter.TryConnectToProcess();
            MouseInput.Start();
            writeFOVToMemory();
            writeCrosshairOffsetToMemory();

            jsonHelper.OutputJsonToFile(jsonHelper.Serialize
                (new JsonData(numFoV.Value, numViewOffset.Value, txtHorizontalSensitivity.Text, txtVerticalSensitivity.Text)));
        }
    }
}
