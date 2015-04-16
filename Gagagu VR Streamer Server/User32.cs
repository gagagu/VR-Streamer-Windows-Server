using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gagagu_VR_Streamer_Server
{
    public static class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        //public const Int32 CURSOR_SHOWING = 0x00000001;

        //[StructLayout(LayoutKind.Sequential)]
        //public struct ICONINFO
        //{
        //    public bool fIcon;
        //    public Int32 xHotspot;
        //    public Int32 yHotspot;
        //    public IntPtr hbmMask;
        //    public IntPtr hbmColor;
        //}

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        //[StructLayout(LayoutKind.Sequential)]
        //public struct CURSORINFO
        //{
        //    public Int32 cbSize;
        //    public Int32 flags;
        //    public IntPtr hCursor;
        //    public POINT ptScreenPos;
        //}

        //[DllImport("user32.dll")]
        //public static extern bool GetCursorInfo(out CURSORINFO pci);

        //[DllImport("user32.dll")]
        //public static extern IntPtr CopyIcon(IntPtr hIcon);

        //[DllImport("user32.dll")]
        //public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

        //[DllImport("user32.dll")]
        //public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        //[DllImport("user32.dll", EntryPoint = "LoadCursorFromFileW", CharSet = CharSet.Unicode)]
        //public static extern IntPtr LoadCursorFromFile(String str);

    }
}
