using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace SimBridge.Database
{
    
    public class SimBridgeDataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<TestRequest> TestRequests { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<TireType> TireTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimBridgeData.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TireType>().HasData(new TireType{TireTypeID = 1,Description = "CD Tire"});
            modelBuilder.Entity<TireType>().HasData(new TireType { TireTypeID = 2, Description = "MF Tire" });
            modelBuilder.Entity<TireType>().HasData(new TireType { TireTypeID = 3, Description = "MF Swift" });
        }
    }

    public class TestRequest
    {
        [Key]
        public string TestRequestID { get; set; }

        public string Description { get; set; }

        public virtual Car Car { get; set; }

        public string SendFilePath { get; set; }

        public string Status { get; set; }

        public DateTime RecievedTime { get; set; }

        public DateTime StartedTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual List<Run> Runs { get; set; }
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

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(100)]
        public string Maneuver { get; set; }

        public virtual int TireTypeID { get; set; }
        public virtual TireType TireModelType { get; set; }

        public virtual Tire LFTire { get; set; }
     
        public virtual Tire RFTire { get; set; }
      
        public virtual Tire LRTire { get; set; }
      
        public virtual Tire RRTire { get; set; }

        public string TestRequestID { get; set; }

        [StringLength(300)]
        public string GeneratedRunSendFilePath { get; set; }

    }

    public class Tire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireID { get; set; }
        
        public string TirePath { get; set; }

        [StringLength(100)]
        public string Construction { get; set; }

        public double Pressure { get; set; }
    }

    public class TireType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireTypeID { get; set; }

        public string Description { get; set; }
    }
}