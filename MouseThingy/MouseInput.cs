using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseThingy
{
    static class MouseInput
    {

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;        // Specifies the size, in bytes, of the structure. 
            // The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
            public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
            //    0             The cursor is hidden.
            //    CURSOR_SHOWING    The cursor is showing.
            public IntPtr hCursor;          // Handle to the cursor. 
            public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor. 
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        private const Int32 CURSOR_SHOWING = 0x00000001;

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Vector2 lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X,int Y);

        private static System.Threading.Timer mouseUpdate;

        private static Vector2 oldMousePos;

        private const float MAXIMUM_VERTICAL_VIEW_ANGLE = 1.492256522f;

        public static void Start()
        {
            GetCursorPos(out oldMousePos);
            mouseUpdate = new System.Threading.Timer(new TimerCallback(UpdateMouse), null, 0, 1);
        }

        private static void UpdateMouse(object thing)
        {
            if (!HaloMemoryWriter.IsForegrounded())
                return;

            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out pci);
            if (pci.flags == 1)
                return;

            Vector2 newMousePos;
            GetCursorPos(out newMousePos);
            Vector2 mouseDelta = newMousePos - oldMousePos;

            byte[] currentFovBytes = new byte[4];
            HaloMemoryWriter.ReadFromMemory((uint)HaloMemoryWriter.BaseAddress + MouseThingy.CURRENT_FOV_OFFSET, currentFovBytes);
            float currentFoV = BitConverter.ToSingle(currentFovBytes, 0);
            
            // Update halo view angle here
            uint horizontalAddress;
            if (MouseThingy.MainForm.GetHAddr(out horizontalAddress))
            {
                float horizontalDelta = mouseDelta.X * MouseThingy.MainForm.HMul * currentFoV / MouseThingy.SensitivityDivisor;
                byte[] temp = new byte[4];
                HaloMemoryWriter.ReadFromMemory(horizontalAddress, temp);
                float horizontalPrevious = BitConverter.ToSingle(temp, 0);
                horizontalPrevious -= horizontalDelta;
                horizontalPrevious = horizontalPrevious % (float)(2 * Math.PI);
                temp = BitConverter.GetBytes(horizontalPrevious);
                HaloMemoryWriter.WriteToMemory(horizontalAddress, temp);
            }

            uint verticalAddress;
            if (MouseThingy.MainForm.GetVAddr(out verticalAddress))
            {
                float verticalDelta = mouseDelta.Y * -MouseThingy.MainForm.VMul * currentFoV / MouseThingy.SensitivityDivisor;
                byte[] temp = new byte[4];
                HaloMemoryWriter.ReadFromMemory(verticalAddress, temp);
                float verticalPrevious = BitConverter.ToSingle(temp, 0);
                verticalPrevious += verticalDelta;
                if (verticalPrevious > MAXIMUM_VERTICAL_VIEW_ANGLE)
                {
                    verticalPrevious = MAXIMUM_VERTICAL_VIEW_ANGLE;
                }
                else if (verticalPrevious < -MAXIMUM_VERTICAL_VIEW_ANGLE)
                {
                    verticalPrevious = -MAXIMUM_VERTICAL_VIEW_ANGLE;
                }
                verticalPrevious = (float)(((verticalPrevious + (Math.PI / 2)) % Math.PI) - (Math.PI / 2));
                temp = BitConverter.GetBytes(verticalPrevious);
                HaloMemoryWriter.WriteToMemory(verticalAddress, temp);
            }

            // Center Cursor on same monitor as process
            Screen activeProcessScreen = Screen.FromHandle(HaloMemoryWriter.SelectedProcess.MainWindowHandle);
            oldMousePos = new Vector2((activeProcessScreen.Bounds.Width / 2) + activeProcessScreen.Bounds.X, (activeProcessScreen.Bounds.Height / 2) + activeProcessScreen.Bounds.Y);
            SetCursorPos(oldMousePos.X, oldMousePos.Y);

           // MouseThingy.MainForm.writeFOVToMemory();
            MouseThingy.MainForm.writeCrosshairOffsetToMemory();
        }
    }

    struct Vector2
    {
        public Vector2(int a, int b)
        {
            X = a;
            Y = b;
        }

        public int X;
        public int Y;

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }
    }
}
