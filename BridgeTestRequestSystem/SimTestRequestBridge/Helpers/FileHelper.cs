using System;
using System.Collections.Generic;
using System.IO;

namespace SimTestRequestBridge.Helpers
{
    static class FileHelper
    {
        //may pass this in later from settings....
        private static string realTimeRootPathString = @"/vigrade/vicrt/GoodyearTestSessions";



        public static DirectoryInfo GetStagingFolderForTestRequest(string testRequestNumber,string stagingPath)
        {
            DirectoryInfo directory = new DirectoryInfo(stagingPath + @"\" + testRequestNumber);
            
            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);

            return directory;
        }

        public static DirectoryInfo GetTiresStagingFolderForTestRequest(string testRequestNumber, int step, TireLocationsCodes tirePosition, string stagingPath)
        {
            string tireSubDir = @"Tires.cdb\Step_" + step + @"\" + tirePosition;
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(GetStagingFolderForTestRequest(testRequestNumber, stagingPath).FullName, tireSubDir));

            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);

            return directory;
        }

        public static DirectoryInfo GetSendFilesStagingFolderForTestRequest(string testRequestNumber, string stagingPath)
        {
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(GetStagingFolderForTestRequest(testRequestNumber, stagingPath).FullName, "Send_files"));

            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);

            return directory;
        }

        public static DirectoryInfo GetOriginalSendFilesStagingFolderForTestRequest(string testRequestNumber, string stagingPath)
        {
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(GetSendFilesStagingFolderForTestRequest(testRequestNumber, stagingPath).FullName, "Original"));

            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);

            return directory;
        }

        public static DirectoryInfo GetVDFStagingFolderForTestRequest(string testRequestNumber, string stagingPath)
        {
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(GetSendFilesStagingFolderForTestRequest(testRequestNumber, stagingPath).FullName, "User_VDFs"));

            if (!Directory.Exists(directory.FullName))
                Directory.CreateDirectory(directory.FullName);

            return directory;
        }

        public static string GetRealTimeTestRequestRootPath()
        {
            return realTimeRootPathString;
        }
        public static string GetRealTimeTestRequestPath(string requestNumber)
        {
            string directory = GetRealTimeTestRequestRootPath() + @"/" + requestNumber;
            return directory;
        }

        public static bool CreateVICRTCDBCFG(string carCDBFileName, string testRequestNumber, string stagingPath)
        {
            try
            {
                //the vicrt_cdb.cfg file is required to link the mdis file structure to the local machines folder structure,
                //so that everything outside of the cfg file can be refrenced reletively. and not absolutely.

                //what is the expected local file path/name for the config file?
                string cfgPath = GetSendFilesStagingFolderForTestRequest(testRequestNumber, stagingPath) + @"\vicrt_cdb.cfg";

                //these two are fixed, users need to know not to move these.
                string carrealtime_shared = "DATABASE carrealtime_shared /vigrade/vicrt/cdb/carrealtime_shared.cdb";
                string tracks = "DATABASE tracks /vigrade/vicrt/cdb/tracks.cdb";

                //based on selected car name, 
                //string car = "DATABASE RaceCar /vigrade/vicrt/GoodyearTestSessions/RaceCar_testRequest/RaceCar.cdb";
                //0 = car name without .cdb;1 = realtime test request path;  2 = Car name with cdb
                string carNameShort = Path.GetFileNameWithoutExtension(carCDBFileName);
                string reaTimeTestRequestPath = GetRealTimeTestRequestPath(testRequestNumber);
                string car = string.Format("DATABASE {0} {1}/{2}", carNameShort, reaTimeTestRequestPath, carCDBFileName);
                string Tires = string.Format("DATABASE Tires {0}/Tires.cdb", reaTimeTestRequestPath, "");

                List<string> cdbentries = new List<string>();
                cdbentries.Add(carrealtime_shared);
                cdbentries.Add(tracks);
                cdbentries.Add(car);
                cdbentries.Add(Tires);

                File.WriteAllLines(cfgPath, cdbentries.ToArray());
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

     
    }
}
