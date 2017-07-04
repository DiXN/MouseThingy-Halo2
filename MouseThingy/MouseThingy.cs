using System.Windows.Forms;

namespace MouseThingy
{
    public class MouseThingy
    {      
        public static frmMouseThingy MainForm
        {
            get { return (frmMouseThingy)Application.OpenForms[0]; }
        }

        public const uint FOV_MULTIPLIER_OFFSET = 4315524;
        public const uint FOV_VEHICLE_MULTIPLIER_OFFSET = 4274048;
        public const uint CURRENT_FOV_OFFSET = 4883752;
        public const uint CROSSHAIR_OFFSET_POINTER = 0x47CD54;
        public const uint CROSSHAIR_OFFSET_POINTER_OFFSET = 0x3dc00;

        public static float SensitivityDivisor
        {
            get { return 400; }
        }

        private static uint mpViewOffsetAddress = 0;

        public static uint ViewOffsetAddress
        {
            get { return MouseThingy.mpViewOffsetAddress; }
            set { MouseThingy.mpViewOffsetAddress = value; }
        }

        public enum KeyModifier
        {
            NONE = 0,
            ALT = 1,
            CONTROL = 2,
            SHIFT = 4
        }
    }
}
