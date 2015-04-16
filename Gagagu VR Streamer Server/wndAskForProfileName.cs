using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gagagu_VR_Streamer_Server
{
    public partial class wndAskForProfileName : Form
    {
        public Boolean Cancel = false;
        public String ProfileName = "";

        public wndAskForProfileName()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Cancel = false;
            ProfileName = this.tbProfileName.Text;
            this.Close();
        }

        private void wndAskForProfileName_Load(object sender, EventArgs e)
        {
            Cancel = false;
            ProfileName = "";
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            ProfileName = "";
            Cancel = true;
            this.Close();
        }

        private void tbProfileName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            { 
                if(String.IsNullOrEmpty(this.tbProfileName.Text))
                {
                    ProfileName = "";
                    Cancel = true;        
                }else{
                    Cancel = false;
                    ProfileName = this.tbProfileName.Text;
                }
                this.Close();
            }
        }
    }
}
