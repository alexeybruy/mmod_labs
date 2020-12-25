using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Lab3.Services
{
    public class RetrieveMatrixService
    {
        private const string FileName = "D:\\Repo\\mmod\\MatModLabs\\Lab3\\matrix.json";

        public IEnumerable<IEnumerable<double>> Matrix()
        {
            return JsonConvert.DeserializeObject<IEnumerable<IEnumerable<double>>>(File.ReadAllText(FileName));
        }
    }
}
