using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseThingy
{
    /// <summary>
    /// Stores the static information used throughout the application
    /// </summary>
    public class MouseThingy
    {
        public const uint FOV_MULTIPLIER_OFFSET = 0x41D984;
        public const uint FOV_VEHICLE_MULTIPLIER_OFFSET = 0x413780;
        public const uint CURRENT_FOV_OFFSET = 0x4A8528;
        public const uint CROSSHAIR_OFFSET_POINTER = 0x47CD54;
        public const uint CROSSHAIR_OFFSET_POINTER_OFFSET = 0x3DC00;
        public const float MAXIMUM_VERTICAL_VIEW_ANGLE = 1.492256522f;

        // Define default radians based on the expected initial value (70 degrees)
        public static readonly float DEFAULT_RADIANS = (float)(70 * Math.PI / 180);

        // References the main MouseThingy form
        // This is set on initialization
        private static frmMouseThingy mainForm = null;
        public static frmMouseThingy MainForm
        {
            get { return mainForm; }
            set { mainForm = value; }
        }

        // Used as a straight division for the sensitivity
        private static float sensitivityDivisor = 4000;
        public static float SensitivityDivisor
        {
            get { return MouseThingy.sensitivityDivisor; }
        }

    }
}
