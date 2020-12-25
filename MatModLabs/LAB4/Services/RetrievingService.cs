using System.IO;
using Newtonsoft.Json;

namespace LAB4.Services
{
    public class RetrievingService
    {
        private string initFilePath = "D:\\study\\mmod\\MatModLabs\\LAB4\\init.json";

        public GraphInitializationModel Retrieve()
        {
            var data = File.ReadAllText(initFilePath);

            return JsonConvert.DeserializeObject<GraphInitializationModel>(data);
        }
    }
}
