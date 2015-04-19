using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using DirectShowLib;
using Emgu.CV.Util;

namespace Gagagu_VR_Streamer_Server.PositionalTracking
{
    /// <summary>
    /// Class for webcam positional tracking
    /// </summary>
    public class WebcamCapture
    {
        private UdpClient UDPReceiver;
        private UdpClient UDPSender;
        private Capture _capture = null;
        private volatile byte[] TrackingData = new byte[48];
        private Mainwindow Parent;
        private volatile Boolean blStop = false;
        private Task udpTask;


        public WebcamCapture(Mainwindow parent)
        {
            this.Parent = parent;
        }

     

        public void StartCapture()
        {
            try
            {
                blStop = false;

                if (Parent.Profil.WebcamIndex >= 0)
                {
                    if (_capture != null) _capture.Dispose();
                    _capture = new Capture(Parent.Profil.WebcamIndex);
                    double c = _capture.GetCaptureProperty(CapProp.FrameWidth);
                    //_capture.SetCaptureProperty(CapProp.FrameWidth, 640.0);
                    //_capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);
                    //_capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 10);
                    _capture.ImageGrabbed += ProcessFrame;
                    _capture.Start();

                }

                udpTask = new Task(StartUDPServer);
                udpTask.Start();

            }
            catch (Exception ex)
            {
                if(ex.HResult!=-2147467259)
                    MessageBox.Show("StartCapture::Error on capture. \r\n" + ex.Message);
            }
        }

        private void StartUDPServer()
        {
            using (UDPReceiver = new UdpClient(Parent.Profil.UDPReceiveDataPort))
            {
                using (UDPSender = new UdpClient(Parent.Profil.UDPSendIPAddress, Parent.Profil.UDPSendDataPort))
                {

                    var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    while (blStop == false)
                    {
                        byte[] receivedResults = UDPReceiver.Receive(ref remoteEndPoint);
                        Buffer.BlockCopy(receivedResults, 24, TrackingData, 24, 24);
                        UDPSender.Send(TrackingData, 48);
                    }
                }
            }
        }

        public void StopCapture()
        {
            blStop = true;

            if ((_capture != null) && (Parent.Profil.WebcamIndex >= 0))
                _capture.Pause();

            if (UDPSender != null)
            {
               UDPSender.Close();
               UDPSender = null;
            }


            if (UDPReceiver != null)
            {
                UDPReceiver.Close();
                UDPReceiver = null;
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            _capture.Retrieve(frame, 0);
            Mat grayFrame = new Mat();
            CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray);

            //Point p = new Point(0, 0);
            // Size patternSize = new Size(5, 4);
            Size patternSize = new Size(4, 4);
            //Matrix<float> corners = new Matrix<float>(20, 2);
            VectorOfPointF corners = new VectorOfPointF(16);

            bool find = CvInvoke.FindChessboardCorners(grayFrame, patternSize, corners, CalibCbType.AdaptiveThresh | CalibCbType.FilterQuads);
            // CvInvoke.DrawChessboardCorners(grayFrame, patternSize, corners, find);
            if (find)
            {
                //for (int x = 0; x <= 15; x++)
                //{
                //Console.WriteLine(corners[15].X.ToString() + " | " + corners[12].X.ToString() + " | " + (corners[15].X - corners[12].X).ToString());
                //}
                //Console.WriteLine("ende");
                if (TrackingData != null)
                {
                    
                    // Angabe in Prozent umrechnen
                    Double XX = corners[9].X / ((Double)grayFrame.Width / 100.00);
                    Double YY = corners[9].Y / ((Double)grayFrame.Height / 100.00);
                    float max = 0;
                    float min = 99999;
                    for (int f = 0; f < corners.Size; f++)
                    {
                        if (corners[f].X > max)
                            max = corners[f].X;

                        if (corners[f].X < min)
                            min = corners[f].X;
                    }
                    Double ZZ = max - min;

                    //Double ZZ = (corners[15].X - corners[12].X) / (grayFrame.Width / 100);
                   // Double ZZ = corners[15].X  - corners[12].X ;
                   //Double ZZ = (corners[15].X / (grayFrame.Width / 100)) - (corners[12].X / (grayFrame.Width / 100));
                    //Double ZZ = (corners[10].X / (grayFrame.Width / 100)) - (corners[9].X / (grayFrame.Width / 100));

                    byte[] X = BitConverter.GetBytes(XX);
                    byte[] Y = BitConverter.GetBytes(YY);
                    byte[] Z = BitConverter.GetBytes(ZZ);

                    Buffer.BlockCopy(X, 0, TrackingData, 0, 8);
                    Buffer.BlockCopy(Y, 0, TrackingData, 8, 8);
                    Buffer.BlockCopy(Z, 0, TrackingData, 16, 8);



                   //Console.WriteLine(XX.ToString() + " | " + YY.ToString() + " | " + ZZ.ToString());
                   // Console.WriteLine(max.ToString() + " | " + min.ToString() + " | " + (max-min).ToString());
                }
            }

            if (Parent.Profil.WebcamPreview)
            {

                Parent.DisplayImage(grayFrame);
    
               
            }

        }

    
    }
}
