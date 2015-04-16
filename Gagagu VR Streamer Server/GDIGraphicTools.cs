using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gagagu_VR_Streamer_Server
{
    class GDIGraphicTools
    {
        public static void DrawCrosshair(Graphics g, int width, int height)
        {
            try
            {
                Pen myPen = new Pen(Color.Red, 0.5f);
                Point[] pointsl1 = new Point[2];
                Point[] pointsr1 = new Point[2];
                Point[] pointsl2 = new Point[2];
                Point[] pointsr2 = new Point[2];
                int middley = height / 2;
                int middlex = width / 4;

                pointsl1[0].X = middlex;
                pointsl1[0].Y = middley - 10;
                pointsl1[1].X = middlex;
                pointsl1[1].Y = middley + 10;
                pointsl2[0].X = middlex - 10;
                pointsl2[0].Y = middley;
                pointsl2[1].X = middlex + 10;
                pointsl2[1].Y = middley;

                pointsr1[0].X = middlex * 3;
                pointsr1[0].Y = middley - 10;
                pointsr1[1].X = middlex * 3;
                pointsr1[1].Y = middley + 10;
                pointsr2[0].X = middlex * 3 - 10;
                pointsr2[0].Y = middley;
                pointsr2[1].X = middlex * 3 + 10;
                pointsr2[1].Y = middley;

                g.DrawLines(myPen, pointsl1);
                g.DrawLines(myPen, pointsl2);
                g.DrawLines(myPen, pointsr1);
                g.DrawLines(myPen, pointsr2);
            }
            catch
            {
            }
        }

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


                if ((CursorPosition.X > left)
                    && (CursorPosition.Y > top)
                    && (CursorPosition.X < left + width)
                    && (CursorPosition.Y < top + height))
                {
                    iconX = CursorPosition.X - left;
                    iconY = CursorPosition.Y - top;

                    if (cbCursorCorrection)
                    {
                        if (iconX > 0)
                        {
                            iconX = iconX / 2;

                        }

                    }

                    if (hScrollAdjWidthValue != 0)
                    {
                        iconX += hScrollAdjWidthValue;

                        if (iconX < 0)
                            iconX = 0;

                    }

                    if (hScrollAdjHeightValue != 0)
                    {
                        iconY += hScrollAdjHeightValue;
                        if (iconY < 0)
                            iconY = 0;

                    }

                    gcu.FillEllipse(myBrush, iconX, iconY, size, size);
                    gcu.FillEllipse(myBrush, iconX + (width / 2), iconY, size, size);

                    //gcu.DrawIcon(cursor, iconX, iconY);
                    //gcu.DrawIcon(cursor, iconX + (width/2), iconY);
                    // User32.DrawIcon(gcu.GetHdc(), iconX, iconY, cursor.Handle);
                    //gcu.ReleaseHdc();
                    // User32.DrawIcon(gcu.GetHdc(), iconX + (width / 2), iconY, cursor.Handle);
                    //gcu.ReleaseHdc();
                }
                //Graphics gcu = System.Drawing.Graphics.FromImage(bmp);

                //User32.CURSORINFO cursorInfo;
                //cursorInfo.cbSize = Marshal.SizeOf(typeof(User32.CURSORINFO));


                //if (User32.GetCursorInfo(out cursorInfo))
                //{
                //    // if the cursor is showing draw it on the screen shot
                //    if (cursorInfo.flags == User32.CURSOR_SHOWING)
                //    {
                //        // we need to get hotspot so we can draw the cursor in the correct position
                //        var iconPointer = User32.CopyIcon(cursorInfo.hCursor);
                //        User32.ICONINFO iconInfo;
                //        int iconX, iconY;

                //        if (User32.GetIconInfo(iconPointer, out iconInfo))
                //        {
                //            // calculate the correct position of the cursor
                //            iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                //            iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);

                //            if ((iconX > left) && (iconY > top) && (iconX < left+width) && (iconY < top+height))
                //            {
                //                iconX -= left;
                //                iconY -= top;

                //                if (cbCursorCorrection.Checked)
                //                {
                //                    if(iconX>0)
                //                        iconX = iconX / 2;
                //                }


                //                //User32.DrawIcon(gcu.GetHdc(), iconX, iconY, cu.Handle);
                //                if (cbCustomCursor.Checked) {
                //                    if (cursor != null)
                //                    {
                //                        //User32.DrawIcon(gcu.GetHdc(), iconX, iconY, customCursorHandle);
                //                        // release the handle created by call to g.GetHdc()
                //                        //Icon ic = Icon.ExtractAssociatedIcon("");
                //                        gcu.DrawIcon(cursor, iconX, iconY);
                //                        gcu.ReleaseHdc();
                //                    }
                //                }
                //                else
                //                {

                //                    User32.DrawIcon(gcu.GetHdc(), iconX, iconY, cursorInfo.hCursor);
                //                    // release the handle created by call to g.GetHdc()
                //                    gcu.ReleaseHdc();
                //                }
                //            }


                //        }
                //    }
                //}
                //gcu.Dispose();
            }
            catch { }
        } // cursor
    }
}
