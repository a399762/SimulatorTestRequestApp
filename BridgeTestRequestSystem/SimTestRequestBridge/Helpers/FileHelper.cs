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


    }
}
