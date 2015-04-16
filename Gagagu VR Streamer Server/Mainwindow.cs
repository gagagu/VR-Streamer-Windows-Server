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

namespace Gagagu_VR_Streamer_Server
{
    public partial class Mainwindow : Form
    {

        [XmlElement("ProfileData")]
        public List<ProfileData> Profiles = new List<ProfileData>();
        private BindingSource bs;
        private MemoryStream ms = new MemoryStream();
        private ImageFormat iFormat = ImageFormat.Png;
        private Socket Server;
        private Boolean blStop = false;
        private ProfileData Profil;
        private Bitmap bm = null;
        private long lenght = 0;
        private byte[] lenbyte = null;
        private SolidBrush myBrush = new SolidBrush(Color.White);


        public Mainwindow()
        {
            InitializeComponent();
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {
            try {
               IEnumerable<IPAddress> liste = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
               foreach (IPAddress ip in liste)
               {
                   cbIPAdresses.Items.Add(ip.ToString());
               }
               if (cbIPAdresses.Items.Count > 0)
                   cbIPAdresses.SelectedIndex = 0;

                SetCursorColors();
                SetProcessList();
                LoadProfileData();
                RefreshProfileData();

                frmAbout about = new frmAbout();
                about.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mainwindow_Load::Error on change profile data. \r\n" + ex.Message);
            }
        }


        private void SetCursorColors()
        {
            this.cbCursorColors.Items.Clear();
            try
            {

                foreach (Color color in new ColorConverter().GetStandardValues())
                {
                    cbCursorColors.Items.Add(color);
                }

              if (cbCursorColors.Items.Count > 0)
                  cbCursorColors.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetCursorColors::" + ex.Message);
            }
        }

        private void SetProcessList()
        {

            cbProcessList.Items.Clear();
            try
            {
                Process[] prozesse = Process.GetProcesses();
                foreach (Process pr in prozesse)
                {
                    cbProcessList.Items.Add(pr.ProcessName + " | " + pr.Id);
                }
                if (cbProcessList.Items.Count > 0)
                {
                    cbProcessList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetProcessList::" + ex.Message);
            }
        }

        private void btReloadProcessList_Click(object sender, EventArgs e)
        {
            try {
                SetProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btReloadProcessList_Click::Error on reload process list. \r\n" + ex.Message);
            }
        }

        private void btTakeProcess_Click(object sender, EventArgs e)
        {
            try{
                tbProcess.Text = cbProcessList.Text.Split('|').ElementAt(0).TrimEnd(' ');
            }
            catch (Exception ex)
            {
                MessageBox.Show("btTakeProcess_Click::" + ex.Message);
            }
        }

        private void hScrollTop_ValueChanged(object sender, EventArgs e)
        {
            try{
                tbScrollTop.Text = hScrollTop.Value.ToString();
                this.Profil= FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollTop_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollBottom_ValueChanged(object sender, EventArgs e)
        {
            try{
                tbScrollBottom.Text = hScrollBottom.Value.ToString();
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollTop_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollLeft_ValueChanged(object sender, EventArgs e)
        {
            try {
                tbScrollLeft.Text = hScrollLeft.Value.ToString();
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollLeft_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollRight_ValueChanged(object sender, EventArgs e)
        {
            try{
                tbScrollRight.Text = hScrollRight.Value.ToString();
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollRight_ValueChanged::" + ex.Message);
            }       
         }

        private void btNewProfile_Click(object sender, EventArgs e)
        {
            try{
                wndAskForProfileName askwnd = new wndAskForProfileName();
                askwnd.ShowDialog();
                if ((!askwnd.Cancel) && (!String.IsNullOrEmpty(askwnd.ProfileName)))
                {
                    ProfileData newProfile = new ProfileData();
                    newProfile.Name = askwnd.ProfileName;
                
                    int port=0;
                    if (int.TryParse(tbServerPort.Text, out port))
                    {
                        newProfile.DataPort = port;
                    }
                    else
                    {
                        newProfile.DataPort = 0;
                    }

                    newProfile.ProcessName = tbProcess.Text;
                    newProfile.Simulate3D = cbSimulate3D.Checked;
                    newProfile.ShowCursor = cbShowCursor.Checked;
                    newProfile.CursorCorrection = cbCursorCorrection.Checked;
                    newProfile.BorderCorrection.top = hScrollTop.Value;
                    newProfile.BorderCorrection.bottom = hScrollBottom.Value;
                    newProfile.BorderCorrection.left = hScrollLeft.Value;
                    newProfile.BorderCorrection.right = hScrollRight.Value;
                    newProfile.ShowCrosshair = cbCrosshair.Checked;
                    newProfile.CorsorColorName = cbCursorColors.SelectedItem.ToString();
                    newProfile.CursorSize = hScrollCursorSize.Value;
                    newProfile.CursorCorrectionAdjWidth = hScrollAdjWidth.Value;
                    newProfile.CursorCorrectionAdjHeight = hScrollAdjHeight.Value;

                    Profiles.Add(newProfile);

                    RefreshProfileData();
                    //cbProfiles.SelectedIndex=cbProfiles.Items.Count - 1;
                    cbProfiles.SelectedItem = newProfile;

                    SaveProfileData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btNewProfile_Click::Error on creating new profile data. \r\n" + ex.Message);
            }
        }

        private void btSaveProfile_Click(object sender, EventArgs e)
        {
            try {
                ProfileData data = (ProfileData)cbProfiles.SelectedItem;
                data = FillProfileWithData(data);
                if (data != null)
                {
                    SaveProfileData();
                    this.tbStatus.Text = "Status: saved...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btSaveProfile_Click::Error on saving profile data. \r\n" + ex.Message);
            }
        }

        private ProfileData FillProfileWithData(ProfileData data)
        {
            try
            {
                if (data == null)
                    data = new ProfileData();

                if (data != null)
                {
                    int port = 0;
                    if (int.TryParse(tbServerPort.Text, out port))
                    {
                        data.DataPort = port;
                    }
                    else
                    {
                        data.DataPort = 0;
                    }

                    data.ProcessName = tbProcess.Text;
                    data.Simulate3D = cbSimulate3D.Checked;
                    data.ShowCursor = cbShowCursor.Checked;
                    data.CursorCorrection = cbCursorCorrection.Checked;
                    data.BorderCorrection.top = hScrollTop.Value;
                    data.BorderCorrection.bottom = hScrollBottom.Value;
                    data.BorderCorrection.left = hScrollLeft.Value;
                    data.BorderCorrection.right = hScrollRight.Value;
                    data.ShowCrosshair = cbCrosshair.Checked;
                    data.CorsorColorName = this.cbCursorColors.SelectedItem.ToString();
                    data.CursorSize = hScrollCursorSize.Value;
                    data.CursorCorrectionAdjWidth = hScrollAdjWidth.Value;
                    data.CursorCorrectionAdjHeight = hScrollAdjHeight.Value;
                }
            }
            catch {
                data = new ProfileData();
            }

            return data;
        }

        private void btDeleteProfile_Click(object sender, EventArgs e)
        {
            try {
                ProfileData data = (ProfileData)cbProfiles.SelectedItem;
                if (data != null)
                {
                    Profiles.Remove(data);
                    SaveProfileData();
                    RefreshProfileData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btDeleteProfile_Click::Error on deleting profile. \r\n" + ex.Message);
            }
        }

        private void LoadProfileData()
        {
            try{
                Profiles = new List<ProfileData>();

                if (File.Exists(Path.Combine(Application.StartupPath, @"profiles.xml")))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<ProfileData>));
                    TextReader reader = new StreamReader(Path.Combine(Application.StartupPath, @"profiles.xml"));
                    object obj = deserializer.Deserialize(reader);
                    Profiles = (List<ProfileData>)obj;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Profiles = new List<ProfileData>();
                MessageBox.Show("LoadProfileData::Error on loading profile data. \r\n" + ex.Message);
            }
        }

        private void SaveProfileData()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ProfileData>));
                using (TextWriter writer = new StreamWriter(Path.Combine(Application.StartupPath, @"profiles.xml")))
                {
                    serializer.Serialize(writer, Profiles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveProfileData::Error on saving profile data. \r\n" + ex.Message);
            }
        }

        private void RefreshProfileData()
        {
            try{
                bs = new BindingSource();
                bs.DataSource = Profiles;

                cbProfiles.DataSource = bs;
                cbProfiles.DisplayMember = "Name";
                cbProfiles.ValueMember = "Name";
                cbProfiles.Refresh();

                if (Profiles.Count == 0)
                {
                    DefaultProfileData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshProfileData::Error refresh profile data. \r\n" + ex.Message);
            }
        }

        void DefaultProfileData()
        {
            try {
                tbServerPort.Text = "6666";
                tbProcess.Text = "";
                cbSimulate3D.Checked = false;
                cbShowCursor.Checked = false;
                cbCursorCorrection.Checked = false;          
                hScrollTop.Value = 0;
                hScrollBottom.Value = 0;
                hScrollLeft.Value = 0;
                hScrollRight.Value = 0;

                cbCursorColors.SelectedItem = Color.White;
                hScrollCursorSize.Value=5;
                hScrollAdjWidth.Value=0;
                hScrollAdjHeight.Value=0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshProfileData::Error refresh profile data. \r\n" + ex.Message);
            }
        }

        private void cbProfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                ProfileData data = (ProfileData)cbProfiles.SelectedItem;
                if (data != null)
                {
                    tbServerPort.Text = data.DataPort.ToString();
                    tbProcess.Text = data.ProcessName;
                    cbSimulate3D.Checked = data.Simulate3D;
                    cbShowCursor.Checked = data.ShowCursor;
                    cbCursorCorrection.Checked = data.CursorCorrection;
                    hScrollTop.Value = data.BorderCorrection.top;
                    hScrollBottom.Value = data.BorderCorrection.bottom;
                    hScrollLeft.Value = data.BorderCorrection.left;
                    hScrollRight.Value = data.BorderCorrection.right;
                    cbCrosshair.Checked = data.ShowCrosshair;

                    foreach (Color cl in cbCursorColors.Items)
                    {
                        if (cl.ToString() == data.CorsorColorName)
                        {
                            cbCursorColors.SelectedItem = cl;
                            break;
                        }
                    }

                    

                    hScrollCursorSize.Value = data.CursorSize;
                    hScrollAdjWidth.Value = data.CursorCorrectionAdjWidth;
                    hScrollAdjHeight.Value= data.CursorCorrectionAdjHeight;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbProfiles_SelectedValueChanged::Error on change profile data. \r\n" + ex.Message);
            }
        }


        private void btStartServer_Click(object sender, EventArgs e)
        {
            try{
                this.tbStatus.Text = "Status: Starting Server...";
                DisableInterface();

                this.Profil = FillProfileWithData(null);
                if (this.Profil != null)
                {
                    if (!this.StartServer())
                    {
                        this.EnableInterface();
                    }
                }
                else {
                    MessageBox.Show("Error on reading profile data. \r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btStartServer_Click::Error on change profile data. \r\n" + ex.Message);
            }
        }

        public Boolean StartServer()
        {
            try
            {
                blStop = false;
                //testserver();

                if (Profil == null)
                {
                    MessageBox.Show("Invalid profile data.");
                    return false;
                }

                if (String.IsNullOrEmpty(Profil.ProcessName))
                {
                    MessageBox.Show("Invalid process name.");
                    return false;
                }

                if ((Profil.DataPort <= 0) || (Profil.DataPort >= 65535))
                {
                    MessageBox.Show("Invalid data port");
                    return false;
                }

                ms = new MemoryStream();
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                Server.Bind(new IPEndPoint(IPAddress.Any, Profil.DataPort));
                Server.Listen(1);

                Server.BeginAccept(new AsyncCallback(this.acceptCallback), Server);


                this.tbStatus.Text = "Status: Server startet";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("StartServer::Error on starting Server. \r\n" + ex.Message);
                this.tbStatus.Text = "Status: Error starting Server...";
                return false;
            }
        }


        public Bitmap CaptureSpecificWindow(string procName)
        {
            Process proc;
            iFormat = ImageFormat.Jpeg;
            Bitmap bmp = null;
            try
            {

                try
                {
                    proc = Process.GetProcessesByName(procName)[0];
                }
                catch
                {
                    return null;
                }

                User32.Rect rect = new User32.Rect();
                IntPtr error = User32.GetWindowRect(proc.MainWindowHandle, ref rect);

                // sometimes it gives error.
                while (error == (IntPtr)0)
                {
                    error = User32.GetWindowRect(proc.MainWindowHandle, ref rect);
                }

                int width = rect.right - (rect.left + hScrollLeft.Value) - hScrollRight.Value;
                int height = rect.bottom - (rect.top + hScrollTop.Value) - hScrollBottom.Value;
                int left = rect.left + hScrollLeft.Value;
                int top = rect.top + hScrollTop.Value;

                bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                if (cbSimulate3D.Checked == true)
                {
                    Bitmap x = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                    Graphics.FromImage(x).CopyFromScreen(left, top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);


                    Graphics g = System.Drawing.Graphics.FromImage(bmp);
                    g.Clear(System.Drawing.Color.Black);
                    g.DrawImage(x, new System.Drawing.Rectangle(0, 0, x.Width / 2, x.Height));
                    g.DrawImage(x, new System.Drawing.Rectangle(width / 2, 0, x.Width / 2, x.Height));

                    if (cbCrosshair.Checked)
                    {
                        GDIGraphicTools.DrawCrosshair(g, width, height);
                    }

                    if((cbShowCursor.Enabled) && (cbShowCursor.Checked))
                    {
                        GDIGraphicTools.DrawCursor(g, 
                                                    left, 
                                                    top, 
                                                    width, 
                                                    height, 
                                                    Cursor.Position, 
                                                    cbCursorCorrection.Checked, 
                                                    hScrollAdjWidth.Value, 
                                                    hScrollAdjHeight.Value,
                                                    myBrush,
                                                    this.hScrollCursorSize.Value);
                    } // cursor

                    g.Dispose();
                    x.Dispose();
                }
                else
                {

                    Graphics g = System.Drawing.Graphics.FromImage(bmp);
                    g.CopyFromScreen(left, top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

                    if (cbCrosshair.Checked)
                    {
                        GDIGraphicTools.DrawCrosshair(g, width, height);
                    }

                    if (cbShowCursor.Checked)
                    {
                        GDIGraphicTools.DrawCursor(g, 
                                                left, 
                                                top, 
                                                width, 
                                                height, 
                                                Cursor.Position, 
                                                cbCursorCorrection.Checked, 
                                                hScrollAdjWidth.Value, 
                                                hScrollAdjHeight.Value,
                                                myBrush, 
                                                this.hScrollCursorSize.Value);
                    } // cursor

                   g.Dispose();
                }

                return bmp;
            }
            catch
            {
                return null;
            }
        }

     
        
    

        public void acceptCallback(IAsyncResult ar)
        {
            Socket listener = null;
            Socket handler = null;

            try
            {
                if (this.Profil != null) 
                {

                   
                    listener = (Socket)ar.AsyncState;

                    try
                    {
                        handler = listener.EndAccept(ar);
                    }
                    catch {
                        if (Server != null)
                        {
                            Server.Close();
                            Server = null;
                        }
                        return;
                    }


                    NetworkStream ns = new NetworkStream(handler, true);

                    while ((handler.Connected) && (blStop == false))
                    {
                        try
                        {
                            ms.SetLength(0);
                            bm = CaptureSpecificWindow(this.tbProcess.Text); 
                            if (bm != null)
                            {
                                bm.Save(ms, iFormat);
                            }
                        }
                        catch
                        {
                            ms.SetLength(0);
                        }

                        // send data
                        try
                        {
                            if ((ms != null) && (ms.Length > 0))
                            {
                                byte[] mybyt = ms.ToArray();
                                if (mybyt.Length > 0)
                                {
                                    lenght = mybyt.Length;
                                    lenbyte = BitConverter.GetBytes(lenght);
                                    ns.Write(lenbyte, 0, lenbyte.Length);

                                    ns.Flush();

                                    ns.Write(mybyt, 0, mybyt.Length);
                                    ns.Flush();
                                }
                            }
                        }
                        catch
                        {
                            blStop = true;
                        }
                    }

                    Invoke((MethodInvoker)delegate { ServerStopped(); });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on starting Server (Callback). \r\n" + ex.Message);
                blStop = true;
            }
            finally
            {
                if (ms != null)
                {
                    try
                    {
                        ms.Close();
                        ms = null;
                    }
                    catch { }
                }

                if ((handler != null) && (handler.Connected))
                {
                    try
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Disconnect(false);
                    }
                    catch { }
                }

                if (Server != null)
                {
                    try
                    {
                        Server.Close();
                        Server = null;
                    }
                    catch { }
                }


            }

        } // acceptCallback

        private void btStopServer_Click(object sender, EventArgs e)
        {
            try{
                ServerStopped();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btStopServer_Click::" + ex.Message);
            }
        }

        private void ServerStopped()
        {
            try
            {
                blStop = true;

                if (Server != null)
                {
                    if (!Server.Connected)
                    {
                        Server.Listen(0);
                        Server.Close();
                        Server = null;
                    }
                }

                this.tbStatus.Text = "Status: Server stopped";
                this.btStartServer.Enabled = true;
                this.btStopServer.Enabled = false;
                EnableInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ServerStopped::" + ex.Message);
            }
        }

        private void DisableInterface()
        {
            try{
                this.tbServerPort.Enabled = false;
                this.tbProcess.Enabled = false;
                this.btTakeProcess.Enabled = false;
                this.cbProcessList.Enabled = false;
                this.btReloadProcessList.Enabled = false;
                this.cbProfiles.Enabled = false;
                this.btNewProfile.Enabled = false;
                this.btDeleteProfile.Enabled = false;
                this.btStartServer.Enabled = false;
                this.btStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DisableInterface::" + ex.Message);
            }
        }

        private void EnableInterface()
        {
            try{
                this.tbServerPort.Enabled = true;
                this.tbProcess.Enabled = true;
                this.btTakeProcess.Enabled = true;
                this.cbProcessList.Enabled = true;
                this.btReloadProcessList.Enabled = true;
                this.cbProfiles.Enabled = true;
                this.btNewProfile.Enabled = true;
                this.btDeleteProfile.Enabled = true;
                this.btStartServer.Enabled = true;
                this.btStopServer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EnableInterface::" + ex.Message);
            }
        }

        private void cbSimulate3D_CheckedChanged(object sender, EventArgs e)
        {
            try{
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbSimulate3D_CheckedChanged::" + ex.Message);
            }
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            try{
                frmAbout about = new frmAbout();
                about.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btAbout_Click::" + ex.Message);
            }
        }

        private void cbShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            try{
                this.Profil = FillProfileWithData(null);
                if (cbShowCursor.Checked)
                {
                    cbCursorCorrection.Enabled = true;
                    cbCursorColors.Enabled = true;
                    hScrollAdjHeight.Enabled = true;
                    hScrollAdjWidth.Enabled = true;
                    hScrollCursorSize.Enabled = true;
                }
                else
                {
                    cbCursorCorrection.Checked = false;
                    cbCursorCorrection.Enabled = false;
                    cbCursorColors.Enabled = false;
                    hScrollAdjHeight.Enabled = false;
                    hScrollAdjWidth.Enabled = false;
                    hScrollCursorSize.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbShowCursor_CheckedChanged::" + ex.Message);
            }
        }

        private void cbCursorCorrection_CheckedChanged(object sender, EventArgs e)
        {
            try{
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbCursorCorrection_CheckedChanged::" + ex.Message);
            }
        }

 

        private void cbCursors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Color myCl =(Color) this.cbCursorColors.SelectedItem;
                if (myCl != null)
                {
                    myBrush = new SolidBrush(myCl);
                    this.Profil = FillProfileWithData(null);
                }
            }
            catch {
                myBrush = new SolidBrush(Color.White);
                this.Profil = FillProfileWithData(null);
            }
            
        }

        private void hScrollAdjHeight_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbScrollAdjHeight.Text = hScrollAdjHeight.Value.ToString();
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollAdjHeight_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollAdjWidth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbScrollAdjWidth.Text = hScrollAdjWidth.Value.ToString();
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollAdjHeight_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollCursorSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbScrollCursorSize.Text = hScrollCursorSize.Value.ToString();
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollCursorSize_ValueChanged::" + ex.Message);
            }
        }







    }
}
