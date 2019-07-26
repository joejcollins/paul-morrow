using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using FaceAnalyser.OpenCV;

namespace FaceAnalyser.Azure
{
    public class FaceAPI
    {
        const string subscriptionKey = "84040947493b4fd685ab2c2b5a1d5714";
        const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";

        public static async Task<string> MakeAnalysisRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            byte[] byteData = FaceDetection.IsFace("http://192.168.0.141:5000/api/capture");

            if (byteData != null)
            {
                // request header
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                // request parameters
                string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                    "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                    "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

                // uri for REST API call
                string uri = uriBase + "?" + requestParameters;

                // request body


                // make request
                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // set headers
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    // execute
                    response = await client.PostAsync(uri, content);

                    // get response
                    string contentString = await response.Content.ReadAsStringAsync();

                    return contentString;
                }
            }
            else
            { 

                return "No Face Found";
            }
        }

        private static byte[] GetImageAsByteArray(string imagePath)
        {
            if(imagePath.Contains("http"))
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
