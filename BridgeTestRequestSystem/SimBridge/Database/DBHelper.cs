using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimBridge.Database
{
    public static class DBHelper
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static string databaseName = "simbridge";
        static string user = "simuser";
        static string host = "localhost";
        static string pass = "goodyear";

        //pull out to config file, and overwrite this var
        static string masterConnectionString = String.Format("server=localhost;port=3306;database={0};uid=root;password={1};",databaseName,pass);
        static string userConnectionString = String.Format("server=localhost;port=3306;database={0};uid={1};password={2};Persist Security Info=True;", databaseName,user, pass);


        /// <summary>
        /// creates the DB if it does not exist
        /// </summary>
        public static bool InitDB()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(masterConnectionString))
                {
                    // Create database if not exists
                    using (SimBridgeDataContext contextDB = new SimBridgeDataContext(connection, false))
                    {
                        contextDB.Database.CreateIfNotExists();
                    }


                    connection.Open();

                    object result = null;

                    using (MySqlCommand Command = new MySqlCommand(String.Format("use mysql;select  User, Host from  user where User like '{0}';",user), connection))
                    {
                        result = Command.ExecuteScalar();
                    }

                    //if null, we dont have user installed,... install user
                    if (result == null)
                    {
                        using (MySqlCommand userCeateCommand = new MySqlCommand(String.Format("CREATE USER '{0}'@'{1}' IDENTIFIED BY '{2}';", user, host, pass), connection))
                        {
                            var r = userCeateCommand.ExecuteScalar();
                            string t = "";
                        }


                        using (MySqlCommand Command = new MySqlCommand(String.Format("GRANT ALL PRIVILEGES ON {0} TO  '{1}'@'{2}'  WITH GRANT OPTION;", databaseName, user, host), connection))
                        {
                            var r = Command.ExecuteNonQuery();
                            string t = "";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Debug(e);
                return false;
            }

            return true;
        }

        /// <summary>
        /// get a list of all current Test requests
        /// </summary>
        /// <returns></returns>
        public static List<TestRequest> GetTestRequests()
        {
            List<TestRequest> result = null;
            using (MySqlConnection connection = new MySqlConnection(userConnectionString))
            {
              //  connection.user
                connection.Open();
                using (SimBridgeDataContext context = new SimBridgeDataContext(connection, false))
                {
                    result = context.TestRequests.ToList();
                }
            }

            return result;
        }

        public static List<Car> GetCars()
        {
            List<Car> result = null;
            using (MySqlConnection connection = new MySqlConnection(userConnectionString))
            {
                //  connection.user
                connection.Open();
                using (SimBridgeDataContext context = new SimBridgeDataContext(connection, false))
                {
                    result = context.Cars.ToList();
                }
            }

            return result;
        }


        /// <summary>
        /// insert test request, use as template for other inserts
        /// </summary>
        /// <param name="testRequest"></param>
        public static void InsertTestRequest(TestRequest testRequest)
        {
            using (MySqlConnection connection = new MySqlConnection(userConnectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // DbConnection that is already opened
                    using (SimBridgeDataContext context = new SimBridgeDataContext(connection, false))
                    {
                        context.Database.UseTransaction(transaction);
                        context.TestRequests.Add(testRequest);
                        context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }   
            }
        }


        public static void InsertCar(Car car)
        {
            using (MySqlConnection connection = new MySqlConnection(userConnectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // DbConnection that is already opened
                    using (SimBridgeDataContext context = new SimBridgeDataContext(connection, false))
                    {
                        context.Database.UseTransaction(transaction);
                        context.Cars.Add(car);
                        context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
