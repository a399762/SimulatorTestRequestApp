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

        public static XDocument SetTirePropertyFilePath(TirePositionProperties tirePosition,string value, XDocument document)
        {
            String tirePositionStringValue = Enum.GetName(typeof(TirePositionProperties), tirePosition);

            var preferences = document.Descendants(xmlDefaultNamespace + "System").Descendants(xmlDefaultNamespace + "ParameterTree").FirstOrDefault(i => i.Attribute("name").Value == "preferences"); ;
            var tire = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == tirePositionStringValue);
            tire.Attribute("value").Value = value;

            return document;
        }
    }
}
