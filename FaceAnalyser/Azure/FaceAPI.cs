using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FaceAnalyser.Azure
{
    public class FaceAPI
    {
        const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";

        public static async Task<string> MakeAnalysisRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            // request header
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _azureAPIkey);

            // request parameters
            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            // uri for REST API call
            string uri = uriBase + "?" + requestParameters;

            // request body
            byte[] byteData = GetImageAsByteArray(@"C:\Projects\Museum of the Future\Coeus\coeus\FaceAnalyser\Images\sample-image.jpg");

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

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =  new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
