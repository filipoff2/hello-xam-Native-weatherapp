using System.Diagnostics;
using GalaSoft.MvvmLight.Views;


namespace WeatherApp.Tests
{
    using System;
    using System.IO;
    using System.Reflection;
    using GalaSoft.MvvmLight.Ioc;
    using Moq;
    using System.Collections.Generic;
    using NUnit.Framework.Internal;

    public static class TestHelper
    {
        public static void ResetIoC() {
            SimpleIoc.Default.Reset();
        }
        
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        

        public static string GetTestDataDirectory()
        {
            var path = System.IO.Directory.GetParent(AssemblyDirectory).Parent.Parent.FullName + "\\TEST_DATA";
            if (System.IO.Directory.Exists(path))
            {
                return path;
            }
            else
            {
                return System.IO.Directory.GetParent(AssemblyDirectory).Parent.FullName + "\\TEST_DATA";
            }
        }

        public static string GetLogDirectory()
        {
            var dir = new DirectoryInfo(AssemblyDirectory);
            return Path.Combine(dir.Parent.Parent.Parent.FullName, "TestLogs");
        }

        public static string GetLogFilePath(string fileName)
        {
            var directory = GetLogDirectory();

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return Path.Combine(directory, fileName.Replace(" ", "-"));
        }

        public static string GetPath(string name)
        {
            //works via local resharper 
            string path = Path.GetDirectoryName(AssemblyDirectory);
            path = Path.Combine(Directory.GetParent(path).FullName, "TestData", name);

            if (File.Exists(path) == false)
            {
                //works via jenkins
                path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                path = Path.Combine(Directory.GetParent(path).Parent.FullName, "TestData", name);
            }
            return path;
        }

        public static List<string[]> GetCsvFile(string csvFileName)
        {
            List<string[]> ret = new List<string[]>();
            string path = GetPath(csvFileName);

            try
            {
                using (var reader = new System.IO.StreamReader(path))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line) == false)
                        {
                            var array = line.Split('|');
                            ret.Add(array);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // ignored
                Debug.WriteLine("Problems "+ path  + e.Message);
            }

            return ret;
        }
    }
}