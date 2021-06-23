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

        public static string GetStagingFolderForTestRequest(string testRequestID,string stagingPath)
        {
            String testSessionStagingPath = stagingPath + @"\" + testRequestID;
            return testSessionStagingPath;
        }

        public static string GetTiresStagingFolderForTestRequest(string testRequestID, string stagingPath)
        {
            String testTiresStagingPath = GetStagingFolderForTestRequest(testRequestID,stagingPath) + @"\Tires.cdb";
            return testTiresStagingPath;
        }

        public static string GetSendFilesStagingFolderForTestRequest(string testRequestID, string stagingPath)
        {
            String testTiresStagingPath = GetStagingFolderForTestRequest(testRequestID, stagingPath) + @"\Send_files";
            return testTiresStagingPath;
        }

        /// <summary>
        /// creates staging folder on hard disk, false if error, true if folder good to go
        /// </summary>
        /// <param name="testRequestID"></param>
        /// <param name="stagingPath"></param>
        /// <returns>false if error, true if folder good to go</returns>
        public static bool CreateStagingFolderIfNotExist(string testRequestID,string stagingPath)
        {
            try
            {
                //check to see if stagin folder exists
                if (!Directory.Exists(stagingPath))
                    Directory.CreateDirectory(stagingPath);
                
                //if we made it this far, we have a root staging directory
                //now lets check to ensure that the current
                String testSessionStagingPath = GetStagingFolderForTestRequest(testRequestID, stagingPath);
                if (!Directory.Exists(testSessionStagingPath))
                    Directory.CreateDirectory(testSessionStagingPath);
                
                //tire folder next
                String testTireStagingPath = GetTiresStagingFolderForTestRequest(testRequestID, stagingPath);
                if (!Directory.Exists(testTireStagingPath))
                    Directory.CreateDirectory(testTireStagingPath);

                //send files folder
                String testSendFilesStagingPath = GetSendFilesStagingFolderForTestRequest(testRequestID, stagingPath);
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
