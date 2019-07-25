#define Default // or Limits

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using OpenCvSharp;
using OpenCvSharp.Extensions;
namespace coeusCapture
{
    public class Startup
    {
        VideoCapture capture;
        Mat frame;
        Bitmap bitmapImage;
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                VideoCapture capture = new VideoCapture(0);
                Mat frame = new Mat();
                if (!capture.IsOpened())
                {
                    Console.WriteLine("Camera hasn't started yet");
                }
                else {
                    Console.WriteLine("Camera has started");
                    capture.Read(frame);
                    bitmapImage = BitmapConverter.ToBitmap(frame);
                }
                bitmapImage.Save( string.Format("capture.png"), ImageFormat.Png);
                Console.WriteLine("fingers crossed...");

                await context.Response.WriteAsync("<img src='capture.png' /> ");
                



            });

        }
   
    }
}
