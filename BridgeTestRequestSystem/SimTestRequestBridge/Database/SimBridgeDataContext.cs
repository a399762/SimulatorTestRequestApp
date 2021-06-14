using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace SimBridge.Database
{
    
    public class SimBridgeDataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<TestRequest> TestRequests { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<TireType> TireTypes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimBridgeData.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //add init Tire model Types
            modelBuilder.Entity<TireType>().HasData(new TireType{TireTypeID = 1,Description = "CD Tire"});
            modelBuilder.Entity<TireType>().HasData(new TireType { TireTypeID = 2, Description = "MF Tire" });
            modelBuilder.Entity<TireType>().HasData(new TireType { TireTypeID = 3, Description = "MF Swift" });

            //add init locations
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 1, Description = "3 Lane Highway" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 2, Description = "Virginia International Raceway" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 3, Description = "Nurburgring" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 4, Description = "VDA" });

            modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Race car" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Jeep Grand Cherokee wk18" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Golf 8" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Sedan Car" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Compact Car" });
        }
    }

    public class TestRequest:INotifyPropertyChanged
    {
        ICollection<Run> runs;


        [Key]
        public string TestRequestID { get; set; }

        public string Description { get; set; }

        public Car Car { get; set; }

        public string SendFilePath { get; set; }

        public string Status { get; set; }

        public DateTime RecievedTime { get; set; }

        public DateTime StartedTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<Run> Runs
        {
            get { return runs; }

            set
            {
                runs = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
        
    public class Car : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }

        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Location : INotifyPropertyChanged, IEquatable<Location>
    {
        int locationID;
        string description;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID
        {
            get { return locationID; }

            set
            {
                locationID = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }

            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        //override equal check for combobox binding assistance
        public bool Equals(Location other)
        {
            return other != null && LocationID == other.LocationID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocationID);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Run : INotifyPropertyChanged
    {
        private int runID;
        private int runNumber;
        private int locationID;
        private int tireTypeID;
        private TireType tireModelType;
        private Location runLocation;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RunID
        {
            get { return runID; }

            set
            {
                runID = value;
                OnPropertyChanged();
            }
        }

        public int RunNumber
        {
            get { return runNumber; }

            set
            {
                runNumber = value;
                OnPropertyChanged();
            }
        }

        [StringLength(100)]
        public int LocationID
        {
            get { return locationID; }

            set
            {
                locationID = value;
                OnPropertyChanged();
            }
        }
        public Location RunLocation
        {
            get { return runLocation; }

            set
            {
                runLocation = value;
                OnPropertyChanged();
            }
        }

        [StringLength(100)]
        public string Maneuver { get; set; }

        public int TireTypeID
        {
            get { return tireTypeID; }

            set
            {
                tireTypeID = value;
                OnPropertyChanged();
            }
        }

        public TireType TireModelType {
            get { return tireModelType; }

            set
            {
                tireModelType = value;
                OnPropertyChanged();
            }
        }

        public Tire LFTire { get; set; }

        public Tire RFTire { get; set; }

        public Tire LRTire { get; set; }

        public Tire RRTire { get; set; }

        [Required]
        public string TestRequestID { get; set; }

        [StringLength(300)]
        public string GeneratedRunSendFilePath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Tire : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireID { get; set; }
        
        public string TirePath { get; set; }
       
        [Required]
        [StringLength(100)]
        public string Construction { get; set; }

        public double Pressure { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TireType : INotifyPropertyChanged, IEquatable<TireType>
    {

        int tireTypeID;
        string description;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireTypeID
        {
            get { return tireTypeID; }

            set
            {
                tireTypeID = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }

            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        //override equal check for combobox binding assistance
        public bool Equals(TireType other)
        {
            return other != null && TireTypeID == other.TireTypeID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TireTypeID);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}