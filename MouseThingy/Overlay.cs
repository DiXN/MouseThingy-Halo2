using System;
using System.Runtime.InteropServices;

namespace MouseThingy
{
    class Overlay
    {
        private const String PATH = "dx9_overlay.dll";

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextCreate(string font, int fontSize, bool bBold, bool bItalic, int x, int y, uint color, string text, bool bShadow, bool bShow);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextDestroy(int id);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetShadow(int id, bool b);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetShown(int id, bool b);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetColor(int id, uint color);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetPos(int id, int x, int y);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetString(int id, string str);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextUpdate(int id, string font, int fontSize, bool bBold, bool bItalic);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DestroyAllVisual();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ShowAllVisual();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HideAllVisual();

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFrameRate();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenSpecs(out int width, out int height);

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetParam(string _szParamName, string _szParamValue);
    }
}
