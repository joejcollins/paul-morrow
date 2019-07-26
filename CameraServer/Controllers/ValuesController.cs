using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace CameraServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {


            Mat frame;
            Bitmap image = null;
            Thread camera;
            int isCameraRunning = 0;

             VideoCapture capture = new VideoCapture(0);
             frame = new Mat();
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

        Byte[] b = System.IO.File.ReadAllBytes(@"capture.png");   // You can use your own method over here.         
            return File(b, "image/jpeg");
        }
    }
}
