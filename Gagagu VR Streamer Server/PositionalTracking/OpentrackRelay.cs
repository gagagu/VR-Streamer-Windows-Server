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

namespace Gagagu_VR_Streamer_Server.PositionalTracking
{


    class OpentrackRelay
    {
        private UdpClient UDPIphoneReceiver;
        private UdpClient UDPArucoReceiver;
        private UdpClient UDPOpentrackSender;
        private volatile byte[] TrackingData = new byte[48];
        private Mainwindow Parent;
        private volatile Boolean blStop = false;
        private Task iPhoneTask;
        private Task ArucoTask;

        public OpentrackRelay(Mainwindow parent)
        {
            this.Parent = parent;
        }


        public void Start()
        {
            try{
                for (int x = 0; x < 48; x++)
                {
                    TrackingData[x] = 0;
                }

                blStop = false;

                iPhoneTask = new Task(StartUDPIPhoneServer);
                iPhoneTask.Start();

                ArucoTask = new Task(StartUDPArucoServer);
                ArucoTask.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Relay Server::Error on Start. \r\n" + ex.Message);
            }
        }

        private void StartUDPIPhoneServer()
        {

            using (UDPIphoneReceiver = new UdpClient(5252))
            {
                using (UDPOpentrackSender = new UdpClient("127.0.0.1",4242))
                {
                    var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    while (blStop == false)
                    {
                        try
                        {
                            byte[] receivedResults = UDPIphoneReceiver.Receive(ref remoteEndPoint);
                            Buffer.BlockCopy(receivedResults, 24, TrackingData, 24, 24);
                            UDPOpentrackSender.Send(TrackingData, 48);
                        }
                        catch { }
                    }
                }
            }
        }

        private void StartUDPArucoServer()
        {

            using (UDPArucoReceiver = new UdpClient(6262))
            {

                var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (blStop == false)
                {
                    try
                    {
                        byte[] receivedResults = UDPArucoReceiver.Receive(ref remoteEndPoint);
                        Buffer.BlockCopy(receivedResults, 0, TrackingData, 0, 24);
                    }
                    catch { }
                }
            }
        }

        public void Stop(){
            try{
                blStop = true;

                if (UDPOpentrackSender != null)
                {
                    UDPOpentrackSender.Close();
                    UDPOpentrackSender = null;
                }


                if (UDPArucoReceiver != null)
                {
                    UDPArucoReceiver.Close();
                    UDPArucoReceiver = null;
                }

                if (UDPIphoneReceiver != null)
                {
                    UDPIphoneReceiver.Close();
                    UDPIphoneReceiver = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Relay Server::Error on stop server. \r\n" + ex.Message);
            }
        }

    }
}
