using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace AsePrite_Layers_Exporter
{
    public class Configuration
    {
        public static List<AseFile> GetConfiguredFiles()
        {
            var files = new List<AseFile>();

            var jsonConfiguration = ReadAseFileConfiguration();

            try
            {
                files = JsonConvert.DeserializeObject<List<AseFile>>(jsonConfiguration);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error during JSON Parsing: ");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            

            return files;
        }

        private static string ReadAseFileConfiguration()
        {
            string jsonConfiguration = string.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["AseFileConfigurationFileName"]))
                {
                    jsonConfiguration = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return jsonConfiguration;
        }
    }
}
