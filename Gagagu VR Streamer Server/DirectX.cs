using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using Device = SharpDX.Direct3D11.Device;
using MapFlags = SharpDX.Direct3D11.MapFlags;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;


namespace Gagagu_VR_Streamer_Server
{
    /// <summary>
    /// Class for Directx capture
    /// </summary>
    public class DirectX
    {
        const int numAdapter = 0;
        const int numOutput = 0;

        private Factory1 factory = null;
        private Adapter1 adapter = null;
        private Device device = null;
        private Output output = null;
        private Output1 output1 = null;

        private Texture2DDescription textureDesc;
        private Texture2D screenTexture;
        private OutputDuplication duplicatedOutput;
        private System.Drawing.Bitmap bitmap = null;
        //System.Drawing.Rectangle boundsRect;

        private SharpDX.DXGI.Resource screenResource;
        private OutputDuplicateFrameInformation duplicateFrameInformation;
        private DataBox mapSource;
        private BitmapData mapDest;
        private IntPtr sourcePtr;
        private IntPtr destPtr;
        private System.Drawing.Rectangle captureRect;
        private int offsetX = 0;
        private int pWidth = 0;
        private bool isInCapture = false;

        /// <summary>
        /// Init some variables one times to spend execution time.
        /// </summary>
        public DirectX()
        {

            try
            {
                factory = new Factory1();
                adapter = factory.GetAdapter1(numAdapter);
                device = new Device(adapter);
                output = adapter.GetOutput(numOutput);
                output1 = output.QueryInterface<Output1>();
                // get screen wize

                textureDesc = new Texture2DDescription
                {
                    CpuAccessFlags = CpuAccessFlags.Read,
                    BindFlags = BindFlags.None,
                    Format = Format.B8G8R8A8_UNorm,
                    Width = ((SharpDX.Mathematics.Interop.RawRectangle)output.Description.DesktopBounds).Right - ((SharpDX.Mathematics.Interop.RawRectangle)output.Description.DesktopBounds).Left,
                    Height = ((SharpDX.Mathematics.Interop.RawRectangle)output.Description.DesktopBounds).Bottom - ((SharpDX.Mathematics.Interop.RawRectangle)output.Description.DesktopBounds).Top,
                    OptionFlags = ResourceOptionFlags.None,
                    MipLevels = 1,
                    ArraySize = 1,
                    SampleDescription = { Count = 1, Quality = 0 },
                    Usage = ResourceUsage.Staging
                };

                screenTexture = new Texture2D(device, textureDesc);
                duplicatedOutput = output1.DuplicateOutput(device);

           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose all
        /// </summary>
        public void close()
        {
            duplicatedOutput.Dispose();
            screenTexture.Dispose();
            output1.Dispose();
            output.Dispose();
            device.Dispose();
            adapter.Dispose();
            factory.Dispose();
        }

        /// <summary>
        /// Sets the window rect and calc the needed buffert offsets.
        /// Is called by changes 
        /// </summary>
        /// <param name="CaptureRect"></param>
        public void SetRect(System.Drawing.Rectangle CaptureRect)
        {

            while(isInCapture){
                System.Threading.Thread.Sleep(1);
            }
            this.captureRect = CaptureRect;
            
            //calc buffer offsets
            offsetX = (captureRect.X * 4);
            pWidth = (captureRect.Width * 4);
        }


        /// <summary>
        /// Creates a screenshot over directx and returns the specified rect as bitmap
        /// </summary>
        /// <param name="CaptureRect">rect to capture from screen</param>
        /// <returns></returns>
        [STAThread]
        public System.Drawing.Bitmap Capture()
        {
            isInCapture = true;
            
            try
            {

                // init
                bool captureDone = false;
                bitmap = new System.Drawing.Bitmap(captureRect.Width, captureRect.Height, PixelFormat.Format32bppArgb);

                // the capture needs some time
                for (int i = 0; !captureDone; i++)
                {
                    try
                    {
                        //capture
                        duplicatedOutput.AcquireNextFrame(-1, out duplicateFrameInformation, out screenResource);
                        // only for wait
                        if (i > 0)
                        {
                            using (var screenTexture2D = screenResource.QueryInterface<Texture2D>())
                                device.ImmediateContext.CopyResource(screenTexture2D, screenTexture);

                            mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, MapFlags.None);
                            mapDest = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, captureRect.Width, captureRect.Height),
                                                                  ImageLockMode.WriteOnly, bitmap.PixelFormat);

                            sourcePtr = mapSource.DataPointer;
                            destPtr = mapDest.Scan0;

                            // set x position offset to rect.x
                            int rowPitch = mapSource.RowPitch - offsetX;
                            // set pointer to y position
                            sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch * captureRect.Y);

                            for (int y = 0; y < captureRect.Height; y++) // needs to speed up!!
                            {
                                // set pointer to x position
                                sourcePtr = IntPtr.Add(sourcePtr, offsetX);
                                
                                // copy pixel to bmp
                                Utilities.CopyMemory(destPtr, sourcePtr, pWidth);

                                // incement pointert to next line
                                sourcePtr = IntPtr.Add(sourcePtr, rowPitch);
                                destPtr = IntPtr.Add(destPtr, mapDest.Stride);
                            }

                            bitmap.UnlockBits(mapDest);
                            device.ImmediateContext.UnmapSubresource(screenTexture, 0);

                            captureDone = true;
                        }

                        screenResource.Dispose();
                        duplicatedOutput.ReleaseFrame();

                    }
                    catch//(Exception ex)  //                    catch (SharpDXException e)
                    {
                        //if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.WaitTimeout.Result.Code)
                        //{
                        //   // throw e;
                        //}

                        return new Bitmap(captureRect.Width, captureRect.Height, PixelFormat.Format32bppArgb);
                    }
                }

            }
            catch 
            {
                return new Bitmap(captureRect.Width, captureRect.Height, PixelFormat.Format32bppArgb);
            }

            isInCapture = false;
            return bitmap;
        }


  


       
    }
}
