using SimBridge.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimTestRequestBridge.Helpers
{
    static class FileHelper
    {

        public static string GetStagingFolderForTestRequest(string testRequestNumber,string stagingPath)
        {
            String testSessionStagingPath = stagingPath + @"\" + testRequestNumber;
            return testSessionStagingPath;
        }

        public static string GetTiresStagingFolderForTestRequest(string testRequestNumber, string stagingPath)
        {
            String testTiresStagingPath = GetStagingFolderForTestRequest(testRequestNumber, stagingPath) + @"\Tires.cdb";
            return testTiresStagingPath;
        }

        public static string GetSendFilesStagingFolderForTestRequest(string testRequestNumber, string stagingPath)
        {
            String testTiresStagingPath = GetStagingFolderForTestRequest(testRequestNumber, stagingPath) + @"\Send_files";
            return testTiresStagingPath;
        }

        /// <summary>
        /// creates staging folder on hard disk, false if error, true if folder good to go
        /// </summary>
        /// <param name="testRequestID"></param>
        /// <param name="stagingPath"></param>
        /// <returns>false if error, true if folder good to go</returns>
        public static bool CreateStagingFolderIfNotExist(string testRequestNumber, string stagingPath)
        {
            try
            {
                //check to see if stagin folder exists
                if (!Directory.Exists(stagingPath))
                    Directory.CreateDirectory(stagingPath);
                
                //if we made it this far, we have a root staging directory
                //now lets check to ensure that the current
                String testSessionStagingPath = GetStagingFolderForTestRequest(testRequestNumber, stagingPath);
                if (!Directory.Exists(testSessionStagingPath))
                    Directory.CreateDirectory(testSessionStagingPath);
                
                //tire folder next
                String testTireStagingPath = GetTiresStagingFolderForTestRequest(testRequestNumber, stagingPath);
                if (!Directory.Exists(testTireStagingPath))
                    Directory.CreateDirectory(testTireStagingPath);

                //send files folder
                String testSendFilesStagingPath = GetSendFilesStagingFolderForTestRequest(testRequestNumber, stagingPath);
                if (!Directory.Exists(testSendFilesStagingPath))
                    Directory.CreateDirectory(testSendFilesStagingPath);
            }
            catch (Exception err)
            {
                return false;
            }

            return true;
        }

        public static bool CreateVICRTCDBCFGIfNotExist(string testRequestNumber, string stagingPath)
        {
            try
            {
                //the vicrt_cdb.cfg file is required to link the mdis file structure to the local machines folder structure,
                //so that everything outside of the cfg file can be refrenced reletively. and not absolutely.

                //what is the expected local file path/name for the config file?
                string cfgPath = GetSendFilesStagingFolderForTestRequest(testRequestNumber, stagingPath) + @"\vicrt_cdb.cfg";

                if (!File.Exists(cfgPath))
                {
                    string carrealtime_shared = "DATABASE carrealtime_shared /vigrade/vicrt/cdb/carrealtime_shared.cdb";
                    string tracks = "DATABASE tracks /vigrade/vicrt/cdb/tracks.cdb";
                    string car = "DATABASE RaceCar /vigrade/vicrt/GoodyearTestSessions_temp/RaceCar_testRequest/RaceCar.cdb";
                    string Tires = "DATABASE Tires /vigrade/vicrt/GoodyearTestSessions_temp/RaceCar_testRequest/Tires.cdb";

                    List<string> cdbentries = new List<string>();
                    cdbentries.Add(carrealtime_shared);
                    cdbentries.Add(tracks);
                    cdbentries.Add(car);
                    cdbentries.Add(Tires);

                    File.WriteAllLines(cfgPath, cdbentries.ToArray());
                }
            }
            catch(Exception err)
            {
                return false;
            }

            return true;
        }
    }
}
