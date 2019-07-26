using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zengenti.Contensis.Management;
using Zengenti.Contensis.Management.Workflow.Basic;

namespace FaceAnalyser.Zengenti
{
    public class ZengentiProvider
    {
        private static ManagementClient _managementClient;
        private static Project _project;
        private static readonly string contensisUri = "https://cms-coeus-data.cloud.contensis.com";
        private static readonly string projectId = "website";
        private static readonly string clientId = "2ea56c7c-6d63-4b1b-82b7-627b8b67193b";
        private static readonly string sharedSecret = "e0d91081c4ab4ea5b4e63eee07013576-07bd427f04d147a7a5da4b5cf1660e02-68c8f43521374a469fc21390fdd60599";
        
        public static async Task SaveToContensis(string json)
        {
            // Initialise Contensis Management Client
            ManagementClientConfiguration defaultConfiguration = new ManagementClientConfiguration(
                rootUrl: contensisUri,
                clientId: clientId,
                sharedSecret: sharedSecret
            );
            ManagementClient.Configure(defaultConfiguration);
            _managementClient = ManagementClient.Create();
            _project = _managementClient.Projects.Get(projectId);
            bool hasSaved = await Set(json);
        }

        private static async Task<bool>Set(string j)
        {
            //dynamic data = JArray.Parse(j);
            Guid entryId = Guid.NewGuid(); ;
            // Generate entry guid from internalId
            Entry entry = _project.Entries.Get(entryId);
            try
            {
                if (entry == null)
                {
                    // Create Module entry if it doesn't exist
                    entry = _project.Entries.New("face", "en-GB", entryId);
                }
                entry.Set("faceId", entryId);
                entry.Set("faceData", j);

                string prevVersion = entry.Version?.VersionNo;
                await entry.SaveAsync();
                if (entry.Version.VersionNo != prevVersion)
                {
                    // Publish the entry
                    await entry.Workflow.PublishAsync();
                    return true;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
