using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gagagu_VR_Streamer_Server
{
    /// <summary>
    /// Some drawing tools for drawing cursor or crosshair
    /// </summary>
    class GDIGraphicTools
    {
        /// <summary>
        /// Draws a crosshair to the give graphics on bothe sides with the given size
        /// </summary>
        /// <param name="g">graphics object</param>
        /// <param name="width">size width</param>
        /// <param name="height">size height</param>
        public static void DrawCrosshair(Graphics g, int width, int height)
        {
            try
            {
                Pen myPen = new Pen(Color.Red, 0.5f);
                Point[] pointsl1 = new Point[2];
                Point[] pointsr1 = new Point[2];
                Point[] pointsl2 = new Point[2];
                Point[] pointsr2 = new Point[2];

                // calculate middle
                int middley = height / 2;
                int middlex = width / 4;

                // set points for left side
                pointsl1[0].X = middlex;
                pointsl1[0].Y = middley - 10;
                pointsl1[1].X = middlex;
                pointsl1[1].Y = middley + 10;
                pointsl2[0].X = middlex - 10;
                pointsl2[0].Y = middley;
                pointsl2[1].X = middlex + 10;
                pointsl2[1].Y = middley;
                // set points for right side
                pointsr1[0].X = middlex * 3;
                pointsr1[0].Y = middley - 10;
                pointsr1[1].X = middlex * 3;
                pointsr1[1].Y = middley + 10;
                pointsr2[0].X = middlex * 3 - 10;
                pointsr2[0].Y = middley;
                pointsr2[1].X = middlex * 3 + 10;
                pointsr2[1].Y = middley;
                // draw lines
                g.DrawLines(myPen, pointsl1);
                g.DrawLines(myPen, pointsl2);
                g.DrawLines(myPen, pointsr1);
                g.DrawLines(myPen, pointsr2);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Draw a point cursor with given size on given position with some aditional parameters
        /// </summary>
        /// <param name="gcu">graphics object</param>
        /// <param name="left">capture position left</param>
        /// <param name="top">capture position top</param>
        /// <param name="width">capture position width</param>
        /// <param name="height">capture position height</param>
        /// <param name="CursorPosition">original cursor position</param>
        /// <param name="cbCursorCorrection">calculate cursor correction?</param>
        /// <param name="hScrollAdjWidthValue">width adjustemts</param>
        /// <param name="hScrollAdjHeightValue">height adjustments</param>
        /// <param name="myBrush">cursor brush</param>
        /// <param name="size">cursor size</param>
        public static void DrawCursor(Graphics gcu, 
                                int left, 
                                int top, 
                                int width, 
                                int height, 
                                Point CursorPosition, 
                                bool cbCursorCorrection, 
                                int hScrollAdjWidthValue, 
                                int hScrollAdjHeightValue, 
                                SolidBrush myBrush, 
                                float size)
        {
            try
            {
                int iconX, iconY;

                // is cursor inside the capture window?
                if ((CursorPosition.X > left)
                    && (CursorPosition.Y > top)
                    && (CursorPosition.X < left + width)
                    && (CursorPosition.Y < top + height))
                {
                    // x/y position beginning from capture window
                    iconX = CursorPosition.X - left;
                    iconY = CursorPosition.Y - top;
                    // calculate correction if activated
                    if (cbCursorCorrection)
                    {
                        if (iconX > 0)
                        {
                            iconX = iconX / 2;

                        }

                    }
                    // add width adjustment
                    if (hScrollAdjWidthValue != 0)
                    {
                        iconX += hScrollAdjWidthValue;

                        if (iconX < 0)
                            iconX = 0;

                    }
                    // add height adjustments
                    if (hScrollAdjHeightValue != 0)
                    {
                        iconY += hScrollAdjHeightValue;
                        if (iconY < 0)
                            iconY = 0;

                    }
                    // draw dots
                    gcu.FillEllipse(myBrush, iconX, iconY, size, size);
                    gcu.FillEllipse(myBrush, iconX + (width / 2), iconY, size, size);

                }
  
            }
            catch { }
        } // cursor


        /// <summary>
        /// 
        /// </summary>
        public static void SetCaptureRect(ref Rectangle CaptureRect, User32.Rect GameWindowRect, ProfileData Profil)
        {
            try
            {
                if (Profil.CustomWindow)
                {
                    CaptureRect.Width = Profil.CustomWindowSize.width;
                    CaptureRect.Height = Profil.CustomWindowSize.height;
                    CaptureRect.X = Profil.CustomWindowSize.x;
                    CaptureRect.Y = Profil.CustomWindowSize.y;
                }
                else
                {
                    CaptureRect.Width = GameWindowRect.right - (GameWindowRect.left + Profil.BorderCorrection.left) - Profil.BorderCorrection.right;
                    CaptureRect.Height = GameWindowRect.bottom - (GameWindowRect.top + Profil.BorderCorrection.top) - Profil.BorderCorrection.bottom;
                    CaptureRect.X = GameWindowRect.left + Profil.BorderCorrection.left;
                    CaptureRect.Y = GameWindowRect.top + Profil.BorderCorrection.top;
                }

                if (CaptureRect.Width <= 0)
                    CaptureRect.Width = 1;

                if (CaptureRect.Height <= 0)
                    CaptureRect.Height = 1;

            }
            catch
            {
                CaptureRect = new Rectangle(0, 0, 0, 0);
            }
        }
    }
}
