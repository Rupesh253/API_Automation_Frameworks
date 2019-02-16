using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_Framework.TestAuxiliaries
{
    public class Helpers
    {
        public class JSON
        {
            public void Generate(string responseContent, string fileNameSubstring = null)
            {
                string baseDirectoy = AppDomain.CurrentDomain.BaseDirectory;
                string temp = baseDirectoy.Replace("bin", "TestReporter").Replace("Debug", "ResponseJsons");
                string filePath = temp + "Response_" + fileNameSubstring + "_" + DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss") + ".json";

                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(responseContent);
                }
            }
        }
    }
}
