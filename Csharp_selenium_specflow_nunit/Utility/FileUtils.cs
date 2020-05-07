using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_selenium_specflow_nunit.Utility
{
    public class FileUtils
    {
        public static void WriteStringToFile(string data, string fileName)
        {
            string folderPath = GetSolutionDirectory() + Path.AltDirectorySeparatorChar + "Resources" + Path.AltDirectorySeparatorChar + "API" + Path.AltDirectorySeparatorChar + "Response" + Path.AltDirectorySeparatorChar;

            CreateDirectoryIfNotExist(folderPath);


            // Create a file to write to.
            File.WriteAllText(folderPath + fileName, data, Encoding.UTF8);

            // Open the file to read from.
            string readText = File.ReadAllText(folderPath + fileName);
            Console.WriteLine(readText);
        }

        public static string ReadJsonArray(string fileName, string JsonPathExpression)
        {
            string result = null;
            string folderPath = GetSolutionDirectory() + Path.AltDirectorySeparatorChar + "Resources" + Path.AltDirectorySeparatorChar + "API" + Path.AltDirectorySeparatorChar + "Response" + Path.AltDirectorySeparatorChar;

            try
            {
                if (!File.Exists(folderPath + fileName))
                    throw new FileNotFoundException();
                else
                {
                    string readText = File.ReadAllText(folderPath + fileName);
                    Console.WriteLine(readText);

                    JArray jsonArray = JArray.Parse(readText);
                    var o = JObject.Parse(jsonArray[0].ToString());

                    result = o.SelectToken(JsonPathExpression).ToString();
                    Console.WriteLine(result);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("Can not get JSON ARRAY expression '" + JsonPathExpression + "' : " + ex);
            }

            return result;
        }

        public static string ReadJsonObject(string fileName, string JsonPathExpression)
        {
            string result = null;
            string folderPath = GetSolutionDirectory() + Path.AltDirectorySeparatorChar + "Resources" + Path.AltDirectorySeparatorChar + "API" + Path.AltDirectorySeparatorChar + "Response" + Path.AltDirectorySeparatorChar;

            try
            {
                if (!File.Exists(folderPath + fileName))
                    throw new FileNotFoundException();
                else
                {
                    string readText = File.ReadAllText(folderPath + fileName);
                    Console.WriteLine(readText);
                    var o = JObject.Parse(readText);

                    result = o.SelectToken(JsonPathExpression).ToString();
                    Console.WriteLine(result);
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("Can not get JSON OBJECT expression '" + JsonPathExpression + "' : " + ex);
            }

            return result;
        }

        public static string GetDebugDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string GetSolutionDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }

        public static void CreateDirectoryIfNotExist(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}