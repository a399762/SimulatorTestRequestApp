
using MySql.Data.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;

namespace SimBridge.Database
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SimBridgeDataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<TestRequest> TestRequests { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Tire> Tires { get; set; }


        // Constructor to use on a DbConnection that is already opened
        public SimBridgeDataContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {
            //this drops/recreates the tables every time app runs????
            //System.Data.Entity.Database.SetInitializer<SimBridgeDataContext>(new SimBridgeDBInitializer());
        }
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestRequest>().MapToStoredProcedures();
            modelBuilder.Entity<Run>().MapToStoredProcedures();
            modelBuilder.Entity<Tire>().MapToStoredProcedures();
            modelBuilder.Entity<Car>().MapToStoredProcedures();
        }
    }

    public class TestRequest
    {
        [Key]
        public string TestRequestID { get; set; }

        public string Description { get; set; }

        public Car Car { get; set; }

        public string Status { get; set; }

        public List<Run> Runs { get; set; }
    }
        
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }

        public string Description { get; set; }
    }

    public class Run
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RunID { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public List<Tire> Tires { get; set; }

        [StringLength(300)]
        public string GeneratedRunSendFilePath { get; set; }
    }

    public class Tire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireID { get; set; }

        public int PositionID { get; set; }

        [StringLength(100)]
        public string Construction { get; set; }

        public double Pressure { get; set; }
    }

}