using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using Newtonsoft.Json;

namespace Lab3.Services
{
    public class RetrieveMatrixService
    {
        private const string FileName = "D:\\study\\mmod\\MatModLabs\\Lab3\\matrix.json";

        public IEnumerable<IEnumerable<double>> Matrix()
        {
            return JsonConvert.DeserializeObject<IEnumerable<IEnumerable<double>>>(File.ReadAllText(FileName));
        }
    }
}
