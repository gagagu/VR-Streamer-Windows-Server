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
    /// <summary>
    /// Main Class
    /// </summary>
    public partial class Mainwindow : Form
    {

        [XmlElement("ProfileData")]
        public List<ProfileData> Profiles = new List<ProfileData>();        // List of all profiles
        private BindingSource bs;
        private MemoryStream ms = new MemoryStream();
        private ImageFormat iFormat = ImageFormat.Jpeg;
        private Socket TCPServer;
        private Boolean blStop = false;
        internal ProfileData Profil;
        private Bitmap bm = null;
        private long lenght = 0;
        private byte[] lenbyte = null;
        private SolidBrush myBrush = new SolidBrush(Color.White);
        private DirectX dx = null;
        private EffectShader LensCorrection = null;
        private EncoderParameters myEncoderParameters = new EncoderParameters(1);
        private System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        private ImageCodecInfo jgpEncoder;
        
        private CaptureRect cptRect =  new CaptureRect();

        //private String ShaderFilename = Path.Combine(Path.Combine(Application.StartupPath,"shader"),"Shader2.ps");

        public Mainwindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window load main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mainwindow_Load(object sender, EventArgs e)
        {
            try {
                // Show all local ip adresses in a drop down box
                ShowIPAddresses();
                // list all possible colors in a dropdown
                SetCursorColors();
                // list all shader files in shader directory
                ShowShaderFiles();
                // list all running processes in a drop down
                SetProcessList();
                // load all profiles and put them into a class
                LoadProfileData();
                // display all profile names into a drop down
                RefreshProfileData();
                // init about dialog
                frmAbout about = new frmAbout();
                about.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mainwindow_Load::Error on change profile data. \r\n" + ex.Message);
            }
        }

        #region "Init"

        private void ShowShaderFiles() {
            try {
                cbShader.Items.Clear();

                string shaderpath = Path.Combine(Application.StartupPath, "shader");
                DirectoryInfo dirInfo = new DirectoryInfo(shaderpath);
                if (dirInfo == null)
                    return;

                FileInfo[] fInfo = dirInfo.GetFiles("*.ps");
                foreach (FileInfo file in fInfo)
                {
                    cbShader.Items.Add(file.Name);
                }

                if (cbShader.Items.Count > 0)
                    cbShader.SelectedIndex = 0;
            }
            catch (Exception ex) {
                MessageBox.Show("ShowShaderFiles::Error on showing shader files. \r\n" + ex.Message);
            }
        }

        private void ShowIPAddresses() {
            try{
                // get all local ip addresses and fill it into a dropdown box 
                IEnumerable<IPAddress> liste = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                foreach (IPAddress ip in liste)
                {
                    cbIPAdresses.Items.Add(ip.ToString());
                }
                if (cbIPAdresses.Items.Count > 0)
                    cbIPAdresses.SelectedIndex = 0;
                        }
            catch (Exception ex)
            {
                MessageBox.Show("ShowIPAddresses::Error on showing ip adresses. \r\n" + ex.Message);
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
        #endregion

        #region "Profile handling"
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

                    newProfile.ProcessName = this.tbProcess.Text;
                    newProfile.ShowCursor = this.cbShowCursor.Checked;
                    newProfile.CursorCorrection = this.cbCursorCorrection.Checked;
                    newProfile.BorderCorrection.top = this.hScrollTop.Value;
                    newProfile.BorderCorrection.bottom = this.hScrollBottom.Value;
                    newProfile.BorderCorrection.left = this.hScrollLeft.Value;
                    newProfile.BorderCorrection.right = this.hScrollRight.Value;
                    newProfile.ShowCrosshair = this.cbCrosshair.Checked;
                    newProfile.CorsorColorName = this.cbCursorColors.SelectedItem.ToString();
                    newProfile.CursorSize = this.hScrollCursorSize.Value;
                    newProfile.CursorCorrectionAdjWidth = this.hScrollAdjWidth.Value;
                    newProfile.CursorCorrectionAdjHeight = this.hScrollAdjHeight.Value;
                    newProfile.UseGDICapture = this.cbUseGDI.Checked;
                    newProfile.ImageQuality = this.hScrollImageQuality.Value;
                    newProfile.CustomWindow = this.cbCustomWindow.Checked;
                    newProfile.CustomWindowSize.x = (int) this.nCustomWindowX.Value;
                    newProfile.CustomWindowSize.y = (int)this.nCustomWindowY.Value;
                    newProfile.CustomWindowSize.width = (int)this.nCustomWindowWidth.Value;
                    newProfile.CustomWindowSize.height = (int)this.nCustomWindowHeight.Value;
                    newProfile.UseShader = this.cbUseShader.Checked;
                    newProfile.ShaderName = this.cbShader.SelectedItem.ToString();
                    
                    // save
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

                    data.ProcessName = this.tbProcess.Text;
                    data.ShowCursor = this.cbShowCursor.Checked;
                    data.CursorCorrection = this.cbCursorCorrection.Checked;
                    data.BorderCorrection.top = this.hScrollTop.Value;
                    data.BorderCorrection.bottom = this.hScrollBottom.Value;
                    data.BorderCorrection.left = this.hScrollLeft.Value;
                    data.BorderCorrection.right = this.hScrollRight.Value;
                    data.ShowCrosshair = this.cbCrosshair.Checked;
                    data.CorsorColorName = this.cbCursorColors.SelectedItem.ToString();
                    data.CursorSize = this.hScrollCursorSize.Value;
                    data.CursorCorrectionAdjWidth = this.hScrollAdjWidth.Value;
                    data.CursorCorrectionAdjHeight = this.hScrollAdjHeight.Value;
                    data.UseGDICapture = this.cbUseGDI.Checked;
                    data.ImageQuality = this.hScrollImageQuality.Value;
                    data.CustomWindow = this.cbCustomWindow.Checked;
                    data.CustomWindowSize.x = (int)this.nCustomWindowX.Value;
                    data.CustomWindowSize.y = (int)this.nCustomWindowY.Value;
                    data.CustomWindowSize.width = (int)this.nCustomWindowWidth.Value;
                    data.CustomWindowSize.height = (int)this.nCustomWindowHeight.Value;

                    data.UseShader = this.cbUseShader.Checked;
                    data.ShaderName = this.cbShader.SelectedItem.ToString();
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
                this.tbServerPort.Text = "6666";
                this.tbProcess.Text = "";
                this.cbShowCursor.Checked = false;
                this.cbCursorCorrection.Checked = false;
                this.hScrollTop.Value = 0;
                this.hScrollBottom.Value = 0;
                this.hScrollLeft.Value = 0;
                this.hScrollRight.Value = 0;

                this.cbCursorColors.SelectedItem = Color.White;
                this.hScrollCursorSize.Value = 5;
                this.hScrollAdjWidth.Value = 0;
                this.hScrollAdjHeight.Value = 0;
                this.cbUseGDI.Checked = false;
                this.hScrollImageQuality.Value = 50;
                this.cbCustomWindow.Checked = false;
                this.nCustomWindowX.Value = 0;
                this.nCustomWindowY.Value = 0;
                this.nCustomWindowWidth.Value = 100;
                this.nCustomWindowHeight.Value = 100;
                this.cbUseShader.Checked = false;
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
                    this.tbServerPort.Text = data.DataPort.ToString();
                    this.tbProcess.Text = data.ProcessName;
                    this.cbShowCursor.Checked = data.ShowCursor;
                    this.cbCursorCorrection.Checked = data.CursorCorrection;
                    this.hScrollTop.Value = data.BorderCorrection.top;
                    this.hScrollBottom.Value = data.BorderCorrection.bottom;
                    this.hScrollLeft.Value = data.BorderCorrection.left;
                    this.hScrollRight.Value = data.BorderCorrection.right;
                    this.cbCrosshair.Checked = data.ShowCrosshair;

                    foreach (Color cl in cbCursorColors.Items)
                    {
                        if (cl.ToString() == data.CorsorColorName)
                        {
                            this.cbCursorColors.SelectedItem = cl;
                            break;
                        }
                    }



                    this.hScrollCursorSize.Value = data.CursorSize;
                    this.hScrollAdjWidth.Value = data.CursorCorrectionAdjWidth;
                    this.hScrollAdjHeight.Value = data.CursorCorrectionAdjHeight;
                    this.cbUseGDI.Checked = data.UseGDICapture;
                    this.hScrollImageQuality.Value = data.ImageQuality;
                    this.cbCustomWindow.Checked = data.CustomWindow;
                    this.nCustomWindowX.Value = data.CustomWindowSize.x;
                    this.nCustomWindowY.Value = data.CustomWindowSize.y;
                    this.nCustomWindowWidth.Value = data.CustomWindowSize.width;
                    this.nCustomWindowHeight.Value = data.CustomWindowSize.height;

                    this.cbUseShader.Checked = data.UseShader;
                    foreach (string sh in cbShader.Items)
                    {
                        if (sh == data.ShaderName)
                        {
                            this.cbShader.SelectedItem = sh;
                            break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbProfiles_SelectedValueChanged::Error on change profile data. \r\n" + ex.Message);
            }
        }
        #endregion

        #region "Server"
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

                // Image server
                ms = new MemoryStream();
                TCPServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TCPServer.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                TCPServer.Bind(new IPEndPoint(IPAddress.Any, Profil.DataPort));
                TCPServer.Listen(1);

                TCPServer.BeginAccept(new AsyncCallback(this.acceptCallback), TCPServer);



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

     
        public void acceptCallback(IAsyncResult ar)
        {
            Socket listener = null;
            Socket handler = null;

            String ShaderFileName = "";

            if ((cbUseShader.Checked) && (cbShader.Items.Count>0))
                ShaderFileName = Path.Combine(Path.Combine(Application.StartupPath, "shader"), Profil.ShaderName);


            Thread STAThread = new Thread(() =>
            {
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
                            if (TCPServer != null)
                            {
                                TCPServer.Close();
                                TCPServer = null;
                            }
                            return;
                        }

                        NetworkStream ns = new NetworkStream(handler, true);
                        jgpEncoder = GDIGraphicTools.GetEncoder(ImageFormat.Jpeg);
                        myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, this.hScrollImageQuality.Value);
                        cptRect.GetGameWindowRect(this.tbProcess.Text, Profil);
                    
                        if ((cbUseShader.Checked) && (cbShader.Items.Count>0))
                            LensCorrection = new EffectShader(1, ShaderFileName);   

                        // to split it will speed up the loop; keep it simple stupid
                        if (cbUseGDI.Checked)
                        {
                            // gdi loop
                            while ((handler.Connected) && (blStop == false))
                            {
                                try
                                {
                                    ms.SetLength(0);
                                    bm = CaptureSpecificWindow(cptRect.getRect());
 
                                    if ((Profil.ShowCrosshair) || (Profil.ShowCursor))
                                        bm = GDIGraphicTools.DrawExtras(bm, cptRect.getRect(), Profil, Cursor.Position, myBrush);
                                
                                    if ((cbUseShader.Checked) && (LensCorrection!=null))
                                        bm = LensCorrection.ApplyShader(bm);

                                    bm.Save(ms, jgpEncoder, myEncoderParameters);
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

                                        // may be put it on separate method
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
                            } // while
                        } else {

                                    dx = new DirectX();
                                    dx.SetRect(cptRect.getRect());

                                    while ((handler.Connected) && (blStop == false))
                                    {
                                        try
                                        {
                                            ms.SetLength(0);
                                            bm = dx.Capture();
                                           
                                            if ((Profil.ShowCrosshair) || (Profil.ShowCursor))
                                                bm = GDIGraphicTools.DrawExtras(bm, cptRect.getRect(), Profil, Cursor.Position, myBrush); // needs to speed up

                                            if ((cbUseShader.Checked) && (LensCorrection != null))
                                                bm = LensCorrection.ApplyShader(bm);
                         
                                            bm.Save(ms, jgpEncoder, myEncoderParameters);

                                        }
                                        catch(Exception ex)
                                        {
                                            ms.SetLength(0);
                                        }

                                        // send data
                                        try
                                        {
                                            if ((ms != null) && (ms.Length > 0))
                                            {
                                                // may be put it on separate method
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
                                    } // while

                                    dx.close();
                                    dx = null;
                                    LensCorrection = null;

                        } // gdi or directx

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

                    if (TCPServer != null)
                    {
                        try
                        {
                            TCPServer.Close();
                            TCPServer = null;
                        }
                        catch { }
                    }


                }

            });
            STAThread.SetApartmentState(ApartmentState.STA); // is needed for shader
            STAThread.Start();
            STAThread.Join();

            STAThread = null;
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

                if (TCPServer != null)
                {
                    if (!TCPServer.Connected)
                    {
                        TCPServer.Listen(0);
                        TCPServer.Close();
                        TCPServer = null;
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

        #endregion

        #region "GDI Capture"
        /// <summary>
        /// Capture screen over gdi
        /// If i will put this method into a class then it will be much slower
        /// </summary>
        /// <param name="wRect">rect to capture</param>
        /// <returns></returns>
        public Bitmap CaptureSpecificWindow(Rectangle wRect)
        {
            try
            {
                //checks
                if ((wRect.Width == 0) || (wRect.Height == 0))
                    return null;

                // make screenshot
                Bitmap bmp = new Bitmap(wRect.Width, wRect.Height, PixelFormat.Format32bppArgb);
                Graphics.FromImage(bmp).CopyFromScreen(wRect.X, wRect.Y, 0, 0, new Size(wRect.Width, wRect.Height), CopyPixelOperation.SourceCopy);

                return bmp;
            }
            catch
            {
                return new Bitmap(wRect.Width, wRect.Height, PixelFormat.Format32bppArgb);
            }
        }
        #endregion

        #region "interface handling"
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
                this.cbUseGDI.Enabled = false;
                this.btStopServer.Enabled = true;
                this.cbShader.Enabled = false;
                this.cbUseShader.Enabled = false;
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
                this.cbUseGDI.Enabled = true;
                this.cbShader.Enabled = true;
                this.cbUseShader.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EnableInterface::" + ex.Message);
            }
        }
        #endregion

        #region "Control Events"

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
                this.Profil = FillProfileWithData(null);
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

        private void hScrollImageQuality_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbScrollImageQuality.Text = hScrollImageQuality.Value.ToString();
                this.Profil = FillProfileWithData(null);
                myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, this.hScrollImageQuality.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollImageQuality_ValueChanged::" + ex.Message);
            }
        }

        private void btReloadWindowPositionAndSize_Click(object sender, EventArgs e)
        {
            cptRect.GetGameWindowRect(this.tbProcess.Text, Profil);
            if ((!cbUseGDI.Checked)&& (dx != null))
            {
                dx.SetRect(cptRect.getRect());
            }
        }

        private void cbCustomWindow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbCustomWindow.Checked)
                {
                    this.nCustomWindowX.Enabled = true;
                    this.nCustomWindowY.Enabled = true;
                    this.nCustomWindowWidth.Enabled = true;
                    this.nCustomWindowHeight.Enabled = true;
                }
                else
                {
                    this.nCustomWindowX.Enabled = false;
                    this.nCustomWindowY.Enabled = false;
                    this.nCustomWindowWidth.Enabled = false;
                    this.nCustomWindowHeight.Enabled = false;
                }
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbCustomWindow::" + ex.Message);
            }
        }

        private void cbCrosshair_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbCrosshair_CheckedChanged::" + ex.Message);
            }
        }

        private void cbDirectX_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbDirectX_CheckedChanged::" + ex.Message);
            }
        }



        private void nCustomWindowX_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nCustomWindowX_ValueChanged::" + ex.Message);
            }
        }

        private void nCustomWindowY_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nCustomWindowY_ValueChanged::" + ex.Message);
            }
        }

        private void nCustomWindowWidth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nCustomWindowWidth_ValueChanged::" + ex.Message);
            }
        }

        private void nCustomWindowHeight_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("nCustomWindowHeight_ValueChanged::" + ex.Message);
            }
        }

       private void cbCameraSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbCameraSelection_SelectedIndexChanged::" + ex.Message);
            }
        }

        private void btReloadProcessList_Click(object sender, EventArgs e)
        {
            try
            {
                SetProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btReloadProcessList_Click::Error on reload process list. \r\n" + ex.Message);
            }
        }

        private void btTakeProcess_Click(object sender, EventArgs e)
        {
            try
            {
                tbProcess.Text = cbProcessList.Text.Split('|').ElementAt(0).TrimEnd(' ');
            }
            catch (Exception ex)
            {
                MessageBox.Show("btTakeProcess_Click::" + ex.Message);
            }
        }

        private void hScrollTop_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbScrollTop.Text = hScrollTop.Value.ToString();
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollTop_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollBottom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbScrollBottom.Text = hScrollBottom.Value.ToString();
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();

            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollTop_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollLeft_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbScrollLeft.Text = hScrollLeft.Value.ToString();
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();

            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollLeft_ValueChanged::" + ex.Message);
            }
        }

        private void hScrollRight_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbScrollRight.Text = hScrollRight.Value.ToString();
                this.Profil = FillProfileWithData(null);
                cptRect.SetCaptureRect(Profil);
                SetDxRect();

            }
            catch (Exception ex)
            {
                MessageBox.Show("hScrollRight_ValueChanged::" + ex.Message);
            }
        }

        private void cbUseShader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbUseShader.Checked)
                {
                    this.cbShader.Enabled = true;
                }
                else
                {
                    this.cbShader.Enabled = false;
                }
                this.Profil = FillProfileWithData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cbUseShader_CheckedChanged::" + ex.Message);
            }
        }

        #endregion

        #region "tools"
        private void SetDxRect()
        {
            if ((!cbUseGDI.Checked) && (dx != null))
            {
                dx.SetRect(cptRect.getRect());
            }
        }

        #endregion


    }
}
