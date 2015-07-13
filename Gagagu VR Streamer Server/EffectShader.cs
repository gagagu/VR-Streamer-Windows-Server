using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Threading;

namespace Gagagu_VR_Streamer_Server
{


    public class EffectShader
    {
        private Double WPF_DPI_X = 96.0;
        private Double WPF_DPI_Y = 96.0;
        private Int32 scale = 1;
        private PixelShader pShader = null;
        private LenseCorrectionShader lcShader;
        private Image img = null;
        private Viewbox viewbox = null;
        //PngBitmapEncoder encoder = new PngBitmapEncoder();
        private JpegBitmapEncoder encoder = new JpegBitmapEncoder();

        public EffectShader(int scale, String FilenamePS)
        {

            this.scale = scale;

            pShader = new PixelShader();
            pShader.UriSource = new Uri(FilenamePS);
            lcShader = new LenseCorrectionShader(pShader);

            img = new Image();
            img.Stretch = Stretch.None;
            img.Effect = lcShader;
                    
            viewbox = new Viewbox();
            viewbox.Stretch = Stretch.Fill;

            viewbox.Child = img;
        }

        public System.Drawing.Bitmap ApplyShader(System.Drawing.Bitmap Source)
        {
            System.Drawing.Bitmap returnBitmap = null;

             try
                {

                    returnBitmap = Source;

                    img.BeginInit();
                    img.Width = Source.Width;
                    img.Height = Source.Height;

                    img.Source = BitmapToBitmapSource.ToBitmapSource(Source); ;
                    img.EndInit();

                    viewbox.Measure(new Size(img.Width * scale, img.Height * scale));
                    viewbox.Arrange(new Rect(0, 0, img.Width * scale, img.Height * scale));
                    viewbox.UpdateLayout();

                    MemoryStream outStream = new MemoryStream();

                    RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.HighQuality);
                    RenderTargetBitmap rtBitmap = new RenderTargetBitmap(Convert.ToInt32(img.Width * scale), Convert.ToInt32(img.Height * scale), Convert.ToInt32(WPF_DPI_X), Convert.ToInt32(WPF_DPI_Y), PixelFormats.Pbgra32);
                    rtBitmap.Render(viewbox);


                    BitmapFrame frame = BitmapFrame.Create(rtBitmap);
                    encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(frame);
                    encoder.Save(outStream);
                    returnBitmap = new System.Drawing.Bitmap(outStream);

                    encoder = null;
                    rtBitmap = null;
                    frame = null;

                }
                catch (Exception ex)
                {
                    returnBitmap = null;
                }

            return returnBitmap;
        }

        ~EffectShader() {
            viewbox = null;
            img = null;
            lcShader = null;
            pShader = null;
        }

        #region "compile shader"
        public static Boolean CompileFXShaderToPS(String PathToFXC, String FilenameFX)
        {
            try
            {
                // check if file exists
                if (!File.Exists(FilenameFX))
                    return false;

                // check if ps file exists and delete it
                FileInfo fsInfo = new FileInfo(FilenameFX);

                String FilenamePS = Path.Combine(fsInfo.Directory.FullName, fsInfo.Name.Replace(fsInfo.Extension, ".ps"));
                if (!File.Exists(FilenamePS))
                    File.Delete(FilenamePS);

                if (!File.Exists(PathToFXC))
                    return false;

                //prepare to call fxc.exe
                ProcessStartInfo psi = new ProcessStartInfo(PathToFXC);
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;

                psi.RedirectStandardError = true;

                //This tells fxc to do .. something with the provided .fx file. it creates a .ps file
                psi.Arguments = string.Format("/T ps_2_0 /E main /Fo\"{0}.ps\" \"{0}.fx\"", fsInfo.Directory);
                string lastError = string.Empty;

                using (Process p = Process.Start(psi))
                {
                    StreamReader sr = p.StandardError;
                    lastError = sr.ReadToEnd();

                    p.WaitForExit();
                }

                return true;
            }
            catch
            {
                return false;
            }
        } // CompileFXShaderToPS
        #endregion
    }
}
