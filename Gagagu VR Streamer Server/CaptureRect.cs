using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gagagu_VR_Streamer_Server
{
    /// <summary>
    /// Handling about game window rect 
    /// </summary>
    public class CaptureRect
    {
        private User32.Rect GameWindowRect;
        private Rectangle CRect = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Return the capture rect
        /// </summary>
        /// <returns></returns>
        public Rectangle getRect(){
            return CRect;
        }

        /// <summary>
        /// Init the window rect from process window and calculate the caprure rect
        /// </summary>
        /// <param name="procName">process name</param>
        /// <param name="Profil">active profile</param>
        public void GetGameWindowRect(string procName, ProfileData Profil)
        {
            Process proc;
            try
            {
                if (String.IsNullOrEmpty(procName))
                {
                    CRect = new Rectangle(0, 0, 0, 0);
                    return;
                }

                proc = Process.GetProcessesByName(procName)[0];
                if (proc == null)
                {
                    CRect = new Rectangle(0, 0, 0, 0);
                    return;
                }

                GameWindowRect = new User32.Rect();
                IntPtr error = User32.GetWindowRect(proc.MainWindowHandle, ref GameWindowRect);

                while (error == (IntPtr)0)
                {
                    error = User32.GetWindowRect(proc.MainWindowHandle, ref GameWindowRect);
                }


                SetCaptureRect(Profil);

            }
            catch
            {
                CRect = new Rectangle(0, 0, 0, 0);
            }
        }


        /// <summary>
        /// calculate the capture rect (with corrections or custom)
        /// </summary>
        /// <param name="Profil">active profile</param>
        public void SetCaptureRect(ProfileData Profil)
        {
            try
            {
                if (Profil.CustomWindow)
                {
                    CRect.Width = Profil.CustomWindowSize.width;
                    CRect.Height = Profil.CustomWindowSize.height;
                    CRect.X = Profil.CustomWindowSize.x;
                    CRect.Y = Profil.CustomWindowSize.y;
                }
                else
                {
                    CRect.Width = GameWindowRect.right - (GameWindowRect.left + Profil.BorderCorrection.left) - Profil.BorderCorrection.right;
                    CRect.Height = GameWindowRect.bottom - (GameWindowRect.top + Profil.BorderCorrection.top) - Profil.BorderCorrection.bottom;
                    CRect.X = GameWindowRect.left + Profil.BorderCorrection.left;
                    CRect.Y = GameWindowRect.top + Profil.BorderCorrection.top;
                }

                if (CRect.Width <= 0)
                    CRect.Width = 1;

                if (CRect.Height <= 0)
                    CRect.Height = 1;

            }
            catch
            {
                CRect = new Rectangle(0, 0, 0, 0);
            }
        }
    }
}
