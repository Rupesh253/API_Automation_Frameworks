using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.VisualStudio.TestAdapter;
using NUnit.Framework;
using RestSharp.Authenticators;
using RestSharp;
using API_Automation_Framework;
using System.IO;

namespace API_Automation_Framework
{
    [TestFixture]
    public class TryItOut
    {
        //8074829170
        [Test]
        public void Try()
        {
            string body = "{\n" +
                            "\"Name\": \"Rupesh\",\n" +
                            "\"Age\": \"24\",\n" +
                            "\"Sex\": \"Key\"\n" +
                            "}";
            Console.WriteLine("Pre-Modification : "+body);
            string body2=body.Replace("Key", "Male");
            Console.WriteLine("Post-Modification : "+body2);

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string data1directory = baseDirectory.Replace("bin", "TestData").Replace("Debug\\", "json1.json");
            string data2directory = baseDirectory.Replace("bin", "TestData").Replace("Debug\\", "json2.json");

            Console.WriteLine("baseDirectory" + baseDirectory);
            Console.WriteLine("data1directory" + data1directory);
            Console.WriteLine("data2directory" + data2directory);

            string readFromJson1 = File.ReadAllText(data1directory);
            string readFromJson2 = File.ReadAllText(data2directory);

            Console.WriteLine("readFromJson1: \n" + readFromJson1);
            Console.WriteLine("readFromJson2: \n" + readFromJson2);







        }
    }
}

