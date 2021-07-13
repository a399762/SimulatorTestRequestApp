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
        public DbSet<TireModelType> TireTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Maneuver> Maneuvers { get; set; }
        public DbSet<StepStartingCondition> StepStartingConditions { get; set; }
        public DbSet<SpeedUnit> SpeedUnits { get; set; }
        public DbSet<LocationLapTimeConfigurationDRD> LocationLapTimeConfigurationDRDs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimBridgeData.db");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add init Tire model Types
            try
            {
                modelBuilder.Entity<TireModelType>().HasData(new TireModelType { TireModelTypeID = 1, Description = "CD Tire", RequiresCDTFile = true, FileExtensionList=".tir,.cdt31" });
                modelBuilder.Entity<TireModelType>().HasData(new TireModelType { TireModelTypeID = 2, Description = "MF Tire", RequiresCDTFile = false, FileExtensionList = ".tir" });
                modelBuilder.Entity<TireModelType>().HasData(new TireModelType { TireModelTypeID = 3, Description = "MF Swift", RequiresCDTFile = false, FileExtensionList = ".tir" });

                //add init locations
                modelBuilder.Entity<Location>().HasData(new Location { LocationID = 1, Description = "3 Lane Highway" });
                modelBuilder.Entity<Location>().HasData(new Location { LocationID = 2, Description = "Virginia International Raceway" });
                modelBuilder.Entity<Location>().HasData(new Location { LocationID = 3, Description = "Nurburgring" });
                modelBuilder.Entity<Location>().HasData(new Location { LocationID = 4, Description = "VDA" });

                //cars
                modelBuilder.Entity<Car>().HasData(new Car { CarID = 1, Description = "Race car" });
                modelBuilder.Entity<Car>().HasData(new Car { CarID = 2, Description = "Jeep Grand Cherokee wk18" });
                modelBuilder.Entity<Car>().HasData(new Car { CarID = 3, Description = "VW GOLF 8" });
                modelBuilder.Entity<Car>().HasData(new Car { CarID = 4, Description = "Sedan Car" });
                modelBuilder.Entity<Car>().HasData(new Car { CarID = 5, Description = "Compact Car" });

                //Maneuvers...
                modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 1, Description = "Slalom" });
                modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 2, Description = "On-Center" });
                modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 3, Description = "Double Lane Change" });
                modelBuilder.Entity<Maneuver>().HasData(new Maneuver { ManeuverID = 4, Description = "Performance" });

                // how fastsss
                modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 1, Description = "m/s", ConversionFactor = 1 });
                modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 2, Description = "km/h", ConversionFactor = 0.27778 });
                modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 3, Description = "mph", ConversionFactor = 0.44704 });
                modelBuilder.Entity<SpeedUnit>().HasData(new SpeedUnit { SpeedUnitID = 4, Description = "knot", ConversionFactor = 0.514444 });

                //default init conidtions
                modelBuilder.Entity<StepStartingCondition>().HasData(new StepStartingCondition {Name = "Default", SetStartingConditionID = 1, InitSpeedUnitID = 1 });
                modelBuilder.Entity<StepStartingCondition>().HasData(new StepStartingCondition { Name = "Not Zero", InitPositionX = 1,InitPositionY = 1, SetStartingConditionID = 2, InitSpeedUnitID = 2 });

                //course configurations/drd links
                modelBuilder.Entity<LocationLapTimeConfigurationDRD>().HasData(new LocationLapTimeConfigurationDRD { Description = "Generic",LocationLapTimeConfigurationDRDID = 1 });
            }
            catch (Exception)
            {
                throw;
            }  
        }
    }

    [Index(nameof(TestNumber))]
    public class TestRequest:INotifyPropertyChanged
    {
        private string comment;
        private string sendFilePath;
        private string description;
        private string testNumber;
        private string cdbFilePath;
        private string preferDriver;
        private string machineName;
        

        private ICollection<Step> steps;
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
        public string MachineName
        {
            get { return machineName; }

            set
            {
                machineName = value;
                OnPropertyChanged();
            }
        }
        
        public string PreferDriver
        {
            get { return preferDriver; }

            set
            {
                preferDriver = value;
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
        public string CDBFilePath
        {
            get { return cdbFilePath; }

            set
            {
                cdbFilePath = value;
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
    public class StepStartingCondition : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SetStartingConditionID { get; set; }

        public string Name { get; set; }

        private int initPositionX;
        private int initPositionY;
        private int initPositionZ;

        private int initPositionRX;
        private int initPositionRY;
        private int initPositionRZ;

        private int initGear;
        private int initSpeed;
        private int initSpeedUnitID;

        private SpeedUnit initSpeedUnit;

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
        public int InitSpeedUnitID
        {
            get { return initSpeedUnitID; }

            set
            {
                initSpeedUnitID = value;
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
        

        public int InitGear
        {
            get { return initGear; }

            set
            {
                initGear = value;
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
        private int tireModelTypeID;
        private int maneuverID;
        private int initStepStartingConditionID;
        private string comment;
        private string generatedSendFilePath;
        private string sendFileUserVDFPath;
        private bool validated;

        private bool overrideStartingCondition;
        private bool enableAutomaticLapTimer;

        private int initPositionX;
        private int initPositionY;
        private int initPositionZ;

        private int initPositionRX;
        private int initPositionRY;
        private int initPositionRZ;

        private int initGear;
        private int initSpeed;

        private int initSpeedUnitID;
      //  private int locationLapTimeConfigurationDRDID;

        private Tire lfTire;
        private Tire lRTire;
        private Tire rfTire;
        private Tire rrTire;
        private SpeedUnit initSpeedUnit;
        private StepStartingCondition initStepStartingCondition;
        private TireModelType tireModelType;
        private Location stepLocation;
        private Maneuver stepManeuver;
        private LocationLapTimeConfigurationDRD steplocationLapTimeConfigurationDRD;

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
        
        public bool EnableAutomaticLapTimer
        {
            get { return enableAutomaticLapTimer; }

            set
            {
                enableAutomaticLapTimer = value;
                OnPropertyChanged();
            }
        }

        public bool OverrideStartingCondition
        {
            get { return overrideStartingCondition; }

            set
            {
                overrideStartingCondition = value;
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
        public int InitSpeedUnitID
        {
            get { return initSpeedUnitID; }

            set
            {
                initSpeedUnitID = value;
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

        public StepStartingCondition InitStepStartingCondition
        {
            get { return initStepStartingCondition; }

            set
            {
                initStepStartingCondition = value;
                OnPropertyChanged();
            }
        }

        public int InitStepStartingConditionID
        {
            get { return initStepStartingConditionID; }

            set
            {
                initStepStartingConditionID = value;
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
        public string SendFileUserVDFPath
        {
            get { return sendFileUserVDFPath; }

            set
            {
                sendFileUserVDFPath = value;
                OnPropertyChanged();
            }
        }
        

        public string GeneratedSendFilePath
        {
            get { return generatedSendFilePath; }

            set
            {
                generatedSendFilePath = value;
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

        public bool Validated
        {
            get { return validated; }

            set
            {
                validated = value;
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
        public LocationLapTimeConfigurationDRD SteplocationLapTimeConfigurationDRD
        {
            get { return steplocationLapTimeConfigurationDRD; }

            set
            {
                steplocationLapTimeConfigurationDRD = value;
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

        public int TireModelTypeID
        {
            get { return tireModelTypeID; }

            set
            {
                tireModelTypeID = value;
                OnPropertyChanged();
            }
        }

        public TireModelType TireModelType {
            get { return tireModelType; }

            set
            {
                tireModelType = value;
                OnPropertyChanged();
            }
        }

        public Tire LFTire
        {
            get { return lfTire; }

            set
            {
                lfTire = value;
                OnPropertyChanged();
            }
        }

        public Tire LRTire {
            get { return lRTire; }

            set
            {
                lRTire = value;
                OnPropertyChanged();
            }
        }

        public Tire RFTire {
            get { return rfTire; }

            set
            {
                rfTire = value;
                OnPropertyChanged();
            }
        }

        public Tire RRTire {
            get { return rrTire; }

            set
            {
                rrTire = value;
                OnPropertyChanged();
            }
        }

        [Required]
        public int TestRequestID { get; set; }

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
    public class TireModelType : INotifyPropertyChanged, IEquatable<TireModelType>
    {
        int tireModelTypeID;
        bool requiresCDTFile;
        string description;
        string fileExtensionList;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TireModelTypeID
        {
            get { return tireModelTypeID; }

            set
            {
                tireModelTypeID = value;
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
        public string FileExtensionList
        {
            get { return fileExtensionList; }

            set
            {
                fileExtensionList = value;
                OnPropertyChanged();
            }
        }
        
        //override equal check for combobox binding assistance
        public bool Equals(TireModelType other)
        {
            return other != null && TireModelTypeID == other.TireModelTypeID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TireModelTypeID);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class LocationLapTimeConfigurationDRD : INotifyPropertyChanged, IEquatable<LocationLapTimeConfigurationDRD>
    {
        int locationLapTimeConfigurationDRDID;
        string description;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationLapTimeConfigurationDRDID
        {
            get { return locationLapTimeConfigurationDRDID; }

            set
            {
                locationLapTimeConfigurationDRDID = value;
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
        public bool Equals(LocationLapTimeConfigurationDRD other)
        {
            return other != null && LocationLapTimeConfigurationDRDID == other.LocationLapTimeConfigurationDRDID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocationLapTimeConfigurationDRDID);
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