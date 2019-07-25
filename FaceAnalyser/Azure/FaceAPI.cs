using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace FaceAnalyser.Azure
{
    public class FaceAPI
    {
        public static async void MakeAnalysisRequest(string subscriptionKey, string uriBase)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            // request header
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // request parameters
            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            // uri for REST API call
            string uri = uriBase + "?" + requestParameters;

            // request body
            byte[] byteData = GetImageAsByteArray("imagePathGoesHere");

            // make request
            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // set headers
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json");

                // execute
                response = await client.PostAsync(uri, content);

                // get response
                string contentString = await response.Content.ReadAsStringAsync();


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
