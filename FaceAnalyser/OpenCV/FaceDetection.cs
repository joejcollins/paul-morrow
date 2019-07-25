using OpenCvSharp;
using System.IO;

namespace FaceAnalyser.OpenCV
{
    public class FaceDetection
    {
        public byte[] IsFace(string imagePath)
        {
            var srcImage = new Mat(imagePath);

            Cv2.ImShow("Source", srcImage);
            Cv2.WaitKey(1); // do events

            var grayImage = new Mat();
            Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGRA2GRAY);
            Cv2.EqualizeHist(grayImage, grayImage);

            var cascade = new CascadeClassifier(@"..\..\data\haarcascade_frontalface_alt.xml");
            var nestedCascade = new CascadeClassifier(@"..\..\data\haarcascade_eye_tree_eyeglasses.xml");

            var faces = cascade.DetectMultiScale(
                image: grayImage,
                scaleFactor: 1.1,
                minNeighbors: 2,
                flags: HaarDetectionType.DoRoughSearch | HaarDetectionType.ScaleImage,
                minSize: new Size(30, 30)
                );

            if (faces.Length > 0)
            {
                byte[] byteImage = GetImageAsByteArray(imagePath);
                return byteImage;
            }
            return null;
        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
