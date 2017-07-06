using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace MouseThingy
{
    public partial class frmMouseThingy : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd,
          int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private Regex regex = new Regex("^[0-9]+,|.[0-9]+?$");

        private JsonHelper<JsonData> jsonHelper;
        private bool isActive = false;

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
            RegisterHotKey(this.Handle, 0, (int)MouseThingy.KeyModifier.CONTROL, (int)Keys.PageUp);
            RegisterHotKey(this.Handle, 0, (int)MouseThingy.KeyModifier.CONTROL, (int)Keys.PageDown);

            RegisterHotKey(this.Handle, 1, (int)MouseThingy.KeyModifier.ALT, (int)Keys.PageUp);
            RegisterHotKey(this.Handle, 1, (int)MouseThingy.KeyModifier.ALT, (int)Keys.PageDown);

            RegisterHotKey(this.Handle, 2, (int)MouseThingy.KeyModifier.SHIFT, (int)Keys.PageUp);
            RegisterHotKey(this.Handle, 2, (int)MouseThingy.KeyModifier.SHIFT, (int)Keys.PageDown);

            jsonHelper = new JsonHelper<JsonData>();
            InitFileds();
        }

        public void InitFileds()
        {
            if (File.Exists("settings.json"))
            {
                JsonData data = jsonHelper.Deserialize(jsonHelper.ReadJsonFile());

                numHorizontal.Value = data.HorizontalSensitivty;
                numVertical.Value = data.VerticalSensitvity;
                numFoV.Value = data.Fov;
                numViewOffset.Value = data.CrosshairOffset;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                MouseThingy.KeyModifier modifier = (MouseThingy.KeyModifier)((int)m.LParam & 0xFFFF);

                switch (key)
                {
                    case Keys.PageUp:
                        if (modifier == MouseThingy.KeyModifier.CONTROL)
                        {
                            if (numFoV.Value < 110)
                                numFoV.Value += 1;
                        }
                        else if (modifier == MouseThingy.KeyModifier.ALT)
                        {
                            if (numViewOffset.Value <= (decimal)0.245)
                                numViewOffset.Value += (decimal)0.005;
                            else
                                numViewOffset.Value = (decimal)0.250;
                        }
                        else if (modifier == MouseThingy.KeyModifier.SHIFT)
                        {
                            if (numHorizontal.Value <= (decimal)9.95)
                                numHorizontal.Value += (decimal)0.005;
                            else
                                numHorizontal.Value = 10;
                        }
                        break;
                    case Keys.PageDown:
                        if (modifier == MouseThingy.KeyModifier.CONTROL)
                        {
                            if (numFoV.Value > 5)
                                numFoV.Value += -1;
                        }
                        else if (modifier == MouseThingy.KeyModifier.ALT)
                        {
                            if (numViewOffset.Value >= (decimal)0.005)
                                numViewOffset.Value -= (decimal)0.005;
                            else
                                numViewOffset.Value = 0;
                        }
                        else if (modifier == MouseThingy.KeyModifier.SHIFT)
                        {
                            if (numHorizontal.Value >= (decimal)0.005)
                                numHorizontal.Value -= (decimal)0.005;
                            else
                                numHorizontal.Value = 0;
                        }
                        break;
                    default:
                        break;
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

        public void elem_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown elem = (NumericUpDown)sender;

            if (elem.Tag.ToString() == "fov")
            {
                writeFOVToMemory();
                DrawHandling("FoV: " + elem.Value.ToString());
            }
            else if (elem.Tag.ToString() == "offset")
            {
                writeCrosshairOffsetToMemory();
                DrawHandling("Crosshair Offset: " + elem.Value.ToString());
            }
            else if (elem.Tag.ToString() == "horizontal")
            {
                DrawHandling("Horizontal Sensitivity: " + elem.Value.ToString());
            }

            jsonHelper.OutputJsonToFile(jsonHelper.Serialize
                (new JsonData(numFoV.Value, numViewOffset.Value, numHorizontal.Value, numVertical.Value)));
        }

        private Task drawTimer;
        private static int drawTimerMaxTick = 3;

        private Action DrawTaskDelegate = () =>
        {
            while (drawTimerMaxTick > 0)
            {
                Thread.Sleep(1000);
                drawTimerMaxTick -= 1;
            }

            Overlay.DestroyAllVisual();
        };

        private void DrawHandling(string drawString)
        {
            if (Process.GetProcessesByName("halo2").Length > 0)
            {
                Overlay.SetParam("process", "halo2.exe");
                Overlay.DestroyAllVisual();

                drawTimerMaxTick = 3;
                if ((Overlay.TextCreate("Arial", 16, false, false, 32, 32, 0x50FF00FF, drawString, true, true)) != -1)
                {
                    if (drawTimer == null)
                    {

                        drawTimer = Task.Factory.StartNew(DrawTaskDelegate);
                    }
                    else
                    {
                        if (drawTimer.Status != TaskStatus.Running)
                        {
                            drawTimer = Task.Factory.StartNew(DrawTaskDelegate);
                        }
                    }
                }
            }
        }

        public float HMul
        {
            get
            {
                if (regex.IsMatch(numHorizontal.Value.ToString()))
                {
                    return (float)numHorizontal.Value;
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
                if (regex.IsMatch(numVertical.Value.ToString()))
                {
                    return (float)numVertical.Value;
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
                statusPanel.BackColor = Color.Green;
                statusLabel.Text = "Halo 2 process detected.";

                if (!isActive)
                {
                    HaloMemoryWriter.TryConnectToProcess();
                    MouseInput.Start();
                    writeFOVToMemory();
                    writeCrosshairOffsetToMemory();
                    isActive = true;

                    jsonHelper.OutputJsonToFile(jsonHelper.Serialize
                        (new JsonData(numFoV.Value, numViewOffset.Value, numHorizontal.Value, numVertical.Value)));

                    Task.Factory.StartNew(() =>
                    {
                        Thread.Sleep(3000);
                        DrawHandling("MouseThingy: Successfully initialized");
                    });
                }
            }
            else
            {
                statusPanel.BackColor = Color.Red;
                statusLabel.Text = "Halo 2 process not detected.";
                isActive = false;
            }
        }
    }
}
