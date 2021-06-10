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
                {
                    //if it does not, try to create it.
                    Directory.CreateDirectory(stagingPath);
                }

                //if we made it this far, we have a root staging directory
                //now lets check to ensure that the current
                String testSessionStagingPath = stagingPath + testRequestID + @"\";

                if (!Directory.Exists(testSessionStagingPath))
                {
                    //if it does not, try to create it.
                    Directory.CreateDirectory(testSessionStagingPath);
                }
            }
            catch (Exception err)
            {
                return false;
            }

            return true;
        }


    }
}
