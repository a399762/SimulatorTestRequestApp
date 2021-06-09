using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimBridge.Database
{
    public static class DBHelper
    {

        /// <summary>
        /// creates the DB if it does not exist
        /// </summary>
        public static bool InitDB()
        {
            // Create database if not exists
            using (SimBridgeDataContext contextDB = new SimBridgeDataContext())
            {
                contextDB.Database.EnsureCreated();
            }
            
            return true;
        }

        /// <summary>
        /// get a list of all current Test requests
        /// </summary>
        /// <returns></returns>
        public static List<TestRequest> GetTestRequests(SimBridgeDataContext context)
        {
            List<TestRequest> result = null;
            result = context.TestRequests.ToList();
            return result;
        }

        public static List<Car> GetCars(SimBridgeDataContext context)
        {
            List<Car> result = null;
            result = context.Cars.ToList();
            return result;
        }


        /// <summary>
        /// insert test request, use as template for other inserts
        /// </summary>
        /// <param name="testRequest"></param>
        public static void InsertTestRequest(TestRequest testRequest, SimBridgeDataContext context)
        {
            context.TestRequests.Add(testRequest);
        }


        public static void InsertCar(Car car, SimBridgeDataContext context)
        {
            context.Cars.Add(car);
        }

        public static List<Run> GetTestRequestRuns(string testRequestID, SimBridgeDataContext context)
        {
           return context.Runs.Include(i =>i.LFTire).Include(i => i.LRTire).Include(i => i.RRTire).Include(i => i.RFTire).Where(i => i.TestRequestID == testRequestID).ToList();
        }
    }
}
