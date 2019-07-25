#define Default // or Limits

using System;
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
using System.IO;
namespace coeusCapture
{
    public class Startup
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        int isCameraRunning = 0;
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(); // For the wwwroot folder


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
                    image = BitmapConverter.ToBitmap(frame);
                }
                image.Save(string.Format(@"capture.png", Guid.NewGuid()), ImageFormat.Png);
                Console.WriteLine("fingers crossed...");
                await context.Response.WriteAsync("<img src='/capture.png' /> ");
                
            });

        }
   
    }
}
