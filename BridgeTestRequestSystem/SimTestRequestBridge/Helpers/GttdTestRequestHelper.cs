using SimBridge.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimBridge.Helpers
{
    public static class GttdTestRequestHelper
    {

        public static TestRequest ConvertFromXMLToEntity(String xmlData)
        {
            XDocument document = XDocument.Parse(xmlData);
            var docRoot = document.Descendants("step_sets");

            //	<step_set step_set_number="1">

            //dig down to <test_step_number>A</test_step_number>
            //
            //  var testStepA = docRoot.ToList();
            var preferences = document.Descendants("step_sets").Descendants("step_set").FirstOrDefault();


            //var smart_driver_file = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == "smart_driver_file");

            //  smart_driver_file.Attribute("value").Value = vdfPath;
            var e = document.Descendants().Where(p => p.Name.LocalName == "step");

           var driverRaw = docRoot.FirstOrDefault(i => i.Attribute("name").Value == "PREFER DRIVER");
            
            //may want to make custom object for this import???
            TestRequest tempRequest = new TestRequest();

           //tempRequest.Car = 

          
            string t = "";
            //var tire = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == tirePositionStringValue);
            //tire.Attribute("value").Value = value;



            return null;
        }

   
    }
}
