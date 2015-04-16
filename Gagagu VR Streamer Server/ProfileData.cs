using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gagagu_VR_Streamer_Server
{

    public class ProfileData
    {
        public String Name { get; set; }
        public int DataPort { get; set; }
        public String ProcessName { get; set; }
        public Boolean Simulate3D { get; set; }
        public Boolean ShowCursor { get; set; }
        public Boolean CursorCorrection { get; set; }
        public Boolean ShowCrosshair { get; set; }

        public String CorsorColorName { get; set; }
        public int CursorSize { get; set; }
        public int CursorCorrectionAdjWidth { get; set; }
        public int CursorCorrectionAdjHeight { get; set; }

        [XmlElement("BorderCorrection")] 
        public BorderCorrectionData BorderCorrection { get; set; }

        public class BorderCorrectionData {
            public int top { get; set; }
            public int bottom { get; set; }
            public int left { get; set; }
            public int right { get; set; }

            public BorderCorrectionData()
            {
                this.top = 0;
                this.bottom = 0;
                this.left = 0;
                this.right = 0;
            }
        }

        public ProfileData()
        {
            this.Name = "noname";
            this.DataPort = 6666;
            this.ProcessName = "";
            this.Simulate3D = false;
            this.ShowCursor = false;
            this.CursorCorrection = false; 
            this.BorderCorrection = new BorderCorrectionData();
            this.ShowCrosshair = false; 

            this.CorsorColorName="";
            this.CursorSize=5;
            this.CursorCorrectionAdjWidth = 0;
            this.CursorCorrectionAdjHeight = 0;
          }
    }
}
