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
            result = context.TestRequests.Include(i => i.Car).ToList();
            return result;
        }

        internal static TestRequest GetTestRequest(SimBridgeDataContext context,int testRequestID)
        {
            TestRequest result = context.TestRequests.Include(i => i.Steps).ThenInclude(i => i.StepManeuver)
                                                    .Include(i => i.Steps).ThenInclude(i => i.StepLocation)
                                                    .Include(i => i.Steps).ThenInclude(i => i.TireModelType)
                                                    .Include(i => i.Steps).ThenInclude(i => i.StepManeuver)
                                                    .Include(i => i.Steps).ThenInclude(i => i.FLTire)
                                                    .Include(i => i.Steps).ThenInclude(i => i.FRTire)
                                                    .Include(i => i.Steps).ThenInclude(i => i.RLTire)
                                                    .Include(i => i.Steps).ThenInclude(i => i.RRTire)
                                                    .Include(i => i.Steps).ThenInclude(i => i.InitStepStartingCondition)
                                                    .Include(i => i.Car).FirstOrDefault(i => i.TestRequestID == testRequestID);
            return result;
        }

        public static List<Car> GetCars(SimBridgeDataContext context)
        {
            List<Car> result = null;
            result = context.Cars.ToList();
            return result;
        }
    }
}