using OpenCvSharp;
using System.IO;
using System.Net;
using System.Drawing;

namespace FaceAnalyser.OpenCV
{
    public class FaceDetection
    {
        public static byte[] IsFace(string imagePath)
        {
            // get image from url and save to disk
            byte[] imageData = GetImageAsByteArray(imagePath); 
            MemoryStream stream = new MemoryStream(imageData);
            Image img = Image.FromStream(stream);
            img.Save("capture.jpg");
            stream.Close();

            var srcImage = new Mat("capture.jpg");

            Cv2.ImShow("Source", srcImage);
            Cv2.WaitKey(1); // do events

            var grayImage = new Mat();
            Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(grayImage, grayImage);

            var cascade = new CascadeClassifier(@"data\haarcascade_frontalface_alt.xml");
            var nestedCascade = new CascadeClassifier(@"data\haarcascade_eye_tree_eyeglasses.xml");

            var faces = cascade.DetectMultiScale(
                image: grayImage,
                scaleFactor: 1.1,
                minNeighbors: 2,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: new OpenCvSharp.Size(30, 30)
                );

            if (faces.Length > 0)
            {
                byte[] byteImage = GetImageAsByteArray(imagePath);
                return byteImage;
            }
            return null;
        }

        private static byte[] GetImageAsByteArray(string imagePath)
        {
            if (imagePath.Contains("http"))
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadData(imagePath);
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }
    }
}
