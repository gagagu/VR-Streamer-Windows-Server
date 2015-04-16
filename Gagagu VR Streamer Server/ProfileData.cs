using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gagagu_VR_Streamer_Server
{
    /// <summary>
    /// Class defines the profile data
    /// </summary>
    public class ProfileData
    {
        // saveable properties
        public String Name { get; set; }
        public int DataPort { get; set; }
        public int UDPReceiveDataPort { get; set; }
        public int UDPSendDataPort { get; set; }
        public String UDPSendIPAddress { get; set; }
        public Boolean WebcamPreview { get; set; }
        public int WebcamIndex { get; set; }
        public String ProcessName { get; set; }
        public Boolean Simulate3D { get; set; }
        public Boolean ShowCursor { get; set; }
        public Boolean CursorCorrection { get; set; }
        public Boolean ShowCrosshair { get; set; }
        public String CorsorColorName { get; set; }
        public int CursorSize { get; set; }
        public int CursorCorrectionAdjWidth { get; set; }
        public int CursorCorrectionAdjHeight { get; set; }
        public Boolean UseDirectX { get; set; }
        public int ImageQuality { get; set; }
        public Boolean CustomWindow { get; set; }
        public Boolean ActivateHeadTracking { get; set; }

        // Subclass for border correction
        [XmlElement("BorderCorrection")] 
        public BorderCorrectionData BorderCorrection { get; set; }

        public class BorderCorrectionData {
            public int top { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
            public int right { get; set; }
            //default values
            public BorderCorrectionData()
            {
                this.top = 0;
                this.bottom = 0;
                this.left = 0;
                this.right = 0;
            }
        }


        [XmlElement("CustomWindowSize")]
        public CustomWindowData CustomWindowSize { get; set; }

        public class CustomWindowData
        {
            public int x { get; set; }
            public int y { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            //default values
            public CustomWindowData()
            {
                this.x = 0;
                this.y = 0;
                this.width = 100;
                this.height = 100;
            }
        }

        /// <summary>
        /// Constructor for default values
        /// </summary>
        public ProfileData()
        {
            this.Name = "noname";
            this.DataPort = 6666;
            this.UDPReceiveDataPort = 5252;
            this.UDPSendDataPort = 4242;
            this.UDPSendIPAddress = "127.0.0.1";
            this.ProcessName = "";
            this.Simulate3D = false;
            this.ShowCursor = false;
            this.CursorCorrection = false; 
            this.BorderCorrection = new BorderCorrectionData();
            this.ShowCrosshair = false;
            this.WebcamPreview = false;
            this.CorsorColorName="";
            this.CursorSize=5;
            this.CursorCorrectionAdjWidth = 0;
            this.CursorCorrectionAdjHeight = 0;
            this.UseDirectX = false;
            this.ImageQuality = 50;
            this.CustomWindow = false;
            this.CustomWindowSize = new CustomWindowData();
            this.ActivateHeadTracking = false;
        }
    }
}
