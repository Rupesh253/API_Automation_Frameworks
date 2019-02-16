using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Framework2.TestAuxiliaries
{
    public class JsonOperations
    {       
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string Read(string fileNameSubstring)
        {
            string baseDirectoy = AppDomain.CurrentDomain.BaseDirectory;
            string temp = baseDirectoy.Replace("bin", "TestReporter").Replace("Debug", "ResponseJsons");
            string fileName = temp + fileNameSubstring + ".json";
            string jsonString = null;
            using (StreamReader sr= new StreamReader(fileName))
            {
                jsonString = sr.ReadToEnd();
            }

            return string.IsNullOrEmpty(jsonString) ? null : jsonString;

        }
        public void Store(string responseContent, string fileNameSubstring = null)
        {
            string baseDirectoy = AppDomain.CurrentDomain.BaseDirectory;
            string temp = baseDirectoy.Replace("bin", "TestReporter").Replace("Debug", "ResponseJsons");
            string filePath = temp + "Response_" + fileNameSubstring + "_" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".json";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(responseContent);
                log.Debug($"Response stored in a json file at {filePath}.");
            }
        }
    }
}
}
