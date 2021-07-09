using SimBridge.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimBridge.Helpers
{
    public static class SendFileHelper
    {
        static XNamespace xmlDefaultNamespace = "http://www.mscsoftware.com/:vfc";

        public enum TirePositionProperties
        {
            fl_tire_property_file,
            fr_tire_property_file,
            rl_tire_property_file,
            rr_tire_property_file
        };

        public enum VehiclUserLocation
        {
            vehicle_user_location_x,
            vehicle_user_location_y,
            vehicle_user_location_z,
            vehicle_user_location_yaw,
            vehicle_user_location_pitch,
            vehicle_user_location_roll
        };

        public static XDocument SetTirePropertyFilePath(TirePositionProperties tirePosition, string value, XDocument document)
        {
            String tirePositionStringValue = Enum.GetName(typeof(TirePositionProperties), tirePosition);

            var preferences = document.Descendants(xmlDefaultNamespace + "System").Descendants(xmlDefaultNamespace + "ParameterTree").FirstOrDefault(i => i.Attribute("name").Value == "preferences");
            var tire = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == tirePositionStringValue);
            tire.Attribute("value").Value = value;

            return document;
        }

        public static void SetStartingPosition(VehiclUserLocation vehiclUserLocation, int value, XDocument document)
        {
            String startingPositionStringValue = Enum.GetName(typeof(VehiclUserLocation), vehiclUserLocation);
           
            var preferences = document.Descendants(xmlDefaultNamespace + "System").Descendants(xmlDefaultNamespace + "ParameterTree").FirstOrDefault(i => i.Attribute("name").Value == "preferences");
            var location = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == startingPositionStringValue);
            location.Attribute("value").Value = value.ToString();
        }

        public static void SetVDFPath(string vdfPath, XDocument document)
        {
            var preferences = document.Descendants(xmlDefaultNamespace + "System").Descendants(xmlDefaultNamespace + "ParameterTree").FirstOrDefault(i => i.Attribute("name").Value == "preferences");
            var smart_driver_file = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == "smart_driver_file");

            smart_driver_file.Attribute("value").Value = vdfPath;
        }
    }
}
