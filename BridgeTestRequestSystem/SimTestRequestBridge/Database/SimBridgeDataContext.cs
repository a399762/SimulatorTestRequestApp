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
        public DbSet<Maneuver> Maneuvers { get; set; }
        public DbSet<StartingLocation> StartingLocations { get; set; }

        public DbSet<SpeedUnit> SpeedUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimBridgeData.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add init Tire model Types
            modelBuilder.Entity<TireType>().HasData(new TireType{TireTypeID = 1,Description = "CD Tire", RequiresCDTFile = true});
            modelBuilder.Entity<TireType>().HasData(new TireType { TireTypeID = 2, Description = "MF Tire", RequiresCDTFile = false });
            modelBuilder.Entity<TireType>().HasData(new TireType { TireTypeID = 3, Description = "MF Swift", RequiresCDTFile = false });

            //add init locations
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 1, Description = "3 Lane Highway" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 2, Description = "Virginia International Raceway" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 3, Description = "Nurburgring" });
            modelBuilder.Entity<Location>().HasData(new Location { LocationID = 4, Description = "VDA" });

            //cars
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Race car" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 2, Description = "Jeep Grand Cherokee wk18" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 3, Description = "Golf 8" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 4, Description = "Sedan Car" });
            modelBuilder.Entity<Car>().HasData(new Car { CarID = 5, Description = "Compact Car" });

            //Maneuvers...
            modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 1, Description = "Slalom" });
            modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 2, Description = "On-Center" });
            modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 3, Description = "Double Lane Change" });
            modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 4, Description = "Performance" });

            // how fastsss
            modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 1, Description = "m/s", ConversionFactor = 1});
            modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 2, Description = "km/h", ConversionFactor = 0.27778 });
            modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 3, Description = "mph", ConversionFactor = 0.44704 });
            modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 4, Description = "knot", ConversionFactor = 0.514444 });
        }
    }

    [Index(nameof(TestNumber))]
    public class TestRequest:INotifyPropertyChanged
    {
        private string comment;
        private string sendFilePath;
        private string description;
        private string testNumber;

        ICollection<Step> steps;
        private Car car;
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestRequestID { get; set; }

        public string TestNumber {
            get { return testNumber; }

            set
            {
                testNumber = value;
                OnPropertyChanged();
            }
        }
        //TestNmber
        public string Description
        {
            get { return description; }

            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public Car Car
        {
            get { return car; }

            set
            {
                car = value;
                OnPropertyChanged();
            }
        }
        public string SendFilePath {
            get { return sendFilePath; }

            set
            {
                sendFilePath = value;
                OnPropertyChanged();
            }
        }

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

        public string Comment
        {
            get { return comment; }

            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Maneuver : INotifyPropertyChanged, IEquatable<Maneuver>
    {
        int maneuverID;
        string description;
        string gTTDKey;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManeuverID
        {
            get { return maneuverID; }

            set
            {
                maneuverID = value;
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

        public string GTTDKey
        {
            get { return gTTDKey; }

            set
            {
                gTTDKey = value;
                OnPropertyChanged();
            }
        }

        //override equal check for combobox binding assistance
        public bool Equals(Maneuver other)
        {
            return other != null && ManeuverID == other.ManeuverID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(maneuverID);
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

    public class StartingLocation : INotifyPropertyChanged
    {
        private int initPositionX;
        private int initPositionY;
        private int initPositionZ;

        private int initPositionRX;
        private int initPositionRY;
        private int initPositionRZ;

        private int initSpeedMS;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StartingLocationID { get; set; }

        public string Description { get; set; }

        public int InitPositionX
        {
            get { return initPositionX; }

            set
            {
                initPositionX = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionY
        {
            get { return initPositionY; }

            set
            {
                initPositionY = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionZ
        {
            get { return initPositionZ; }

            set
            {
                initPositionZ = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionRX
        {
            get { return initPositionRX; }

            set
            {
                initPositionRX = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionRY
        {
            get { return initPositionRY; }

            set
            {
                initPositionRY = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionRZ
        {
            get { return initPositionRZ; }

            set
            {
                initPositionRZ = value;
                OnPropertyChanged();
            }
        }

        public int InitSpeedMS
        {
            get { return initSpeedMS; }

            set
            {
                initSpeedMS = value;
                OnPropertyChanged();
            }
        }

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
        private int tireTypeID;//tiremodeltype
        private int maneuverID;
        private string comment;
        private string generatedSentFilePath;

        private int initPositionX;
        private int initPositionY;
        private int initPositionZ;

        private int initPositionRX;
        private int initPositionRY;
        private int initPositionRZ;

        private int initGear;
        private int initSpeed;
        private int initSpeedUnitsID;

        private SpeedUnit initSpeedUnit;
        private TireType tireModelType;
        private Location stepLocation;
        private Maneuver stepManeuver;

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

        public int InitPositionX
        {
            get { return initPositionX; }

            set
            {
                initPositionX = value;
                OnPropertyChanged();
            }
        }

        public int InitPositionY
        {
            get { return initPositionY; }

            set
            {
                initPositionY = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionZ
        {
            get { return initPositionZ; }

            set
            {
                initPositionZ = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionRX
        {
            get { return initPositionRX; }

            set
            {
                initPositionRX = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionRY
        {
            get { return initPositionRY; }

            set
            {
                initPositionRY = value;
                OnPropertyChanged();
            }
        }
        public int InitPositionRZ
        {
            get { return initPositionRZ; }

            set
            {
                initPositionRZ = value;
                OnPropertyChanged();
            }
        }


        public int InitSpeed
        {
            get { return initSpeed; }

            set
            {
                initSpeed = value;
                OnPropertyChanged();
            }
        }
        public int InitSpeedUnitsID
        {
            get { return initSpeedUnitsID; }

            set
            {
                initSpeedUnitsID = value;
                OnPropertyChanged();
            }
        }

        public int InitGear
        {
            get { return initGear; }

            set
            {
                initGear = value;
                OnPropertyChanged();
            }
        }
        
        public SpeedUnit InitSpeedUnit
        {
            get { return initSpeedUnit; }

            set
            {
                initSpeedUnit = value;
                OnPropertyChanged();
            }
        }

        
        public string Comment
        {
            get { return comment; }

            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }

        public string GeneratedSentFilePath
        {
            get { return generatedSentFilePath; }

            set
            {
                generatedSentFilePath = value;
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

        
        public int ManeuverID
        {
            get { return maneuverID; }

            set
            {
                maneuverID = value;
                OnPropertyChanged();
            }
        }


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
        public Maneuver StepManeuver
        {
            get { return stepManeuver; }

            set
            {
                stepManeuver = value;
                OnPropertyChanged();
            }
        }

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

        public Tire FLTire { get; set; }

        public Tire FRTire { get; set; }

        public Tire RLTire { get; set; }

        public Tire RRTire { get; set; }

        [Required]
        public int TestRequestID { get; set; }

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
        private string tirePath;
        private string cDT31TirePath;
        private string construction;
        private double pressure;

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
        public string Construction
        {
            get { return construction; }

            set
            {
                construction = value;
                OnPropertyChanged();
            }
        }

        public double Pressure
        {
            get { return pressure; }

            set
            {
                pressure = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TireType : INotifyPropertyChanged, IEquatable<TireType>
    {
        int tireTypeID;
        bool requiresCDTFile;
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

        public bool RequiresCDTFile
        {
            get { return requiresCDTFile; }

            set
            {
                requiresCDTFile = value;
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

    public class SpeedUnit : INotifyPropertyChanged, IEquatable<SpeedUnit>
    {
        int speedUnitID;
        string description;
        double conversionFactor;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeedUnitID
        {
            get { return speedUnitID; }

            set
            {
                speedUnitID = value;
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
        //1 mph = 0.44704 m/s
        //.44704 is the conversion facotor to get mph to m/s that the sim software takes
        public double ConversionFactor
        {
            get { return conversionFactor; }

            set
            {
                conversionFactor = value;
                OnPropertyChanged();
            }
        }

        //override equal check for combobox binding assistance
        public bool Equals(SpeedUnit other)
        {
            return other != null && SpeedUnitID == other.SpeedUnitID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SpeedUnitID);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}