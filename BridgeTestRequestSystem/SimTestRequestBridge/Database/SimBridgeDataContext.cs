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
        public DbSet<Step> Steps { get; set; }
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
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 2, Description = "Jeep Grand Cherokee wk18" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 3, Description = "Golf 8" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 4, Description = "Sedan Car" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 5, Description = "Compact Car" });
        }
    }

    public class TestRequest:INotifyPropertyChanged
    {
        ICollection<Step> steps;


        [Key]
        public string TestRequestID { get; set; }

        public string Description { get; set; }

        public Car Car { get; set; }

        public string SendFilePath { get; set; }

        public string Status { get; set; }

        public DateTime RecievedTime { get; set; }

        public DateTime StartedTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<Step> Steps
        {
            get { return steps; }

            set
            {
                steps = value;
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

    public class Step : INotifyPropertyChanged
    {
        private int stepID;
        private int stepNumber;
        private int locationID;
        private int tireTypeID;

        private TireType tireModelType;
        private Location stepLocation;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StepID
        {
            get { return stepID; }

            set
            {
                stepID = value;
                OnPropertyChanged();
            }
        }


        public int StepNumber
        {
            get { return stepNumber; }

            set
            {
                stepNumber = value;
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
        public Location StepLocation
        {
            get { return stepLocation; }

            set
            {
                stepLocation = value;
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
        public string GeneratedStepSendFilePath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Tire : INotifyPropertyChanged
    {
        string tirePath;
        string cDT31TirePath;
        string construction;
        double pressure;




        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireID { get; set; }
        
        public string TirePath
        {
            get { return tirePath; }

            set
            {
                tirePath = value;
                OnPropertyChanged();
            }
        }

        public string CDT31TirePath
        {
            get { return cDT31TirePath; }

            set
            {
                cDT31TirePath = value;
                OnPropertyChanged();
            }

        }
        public string Construction { get; set; }

        public double Pressure { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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