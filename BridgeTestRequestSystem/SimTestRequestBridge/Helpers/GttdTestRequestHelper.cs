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
            var stepListRaw = document.Descendants().Where(p => p.Name.LocalName == "step");
            //< test_step_number > A </ test_step_number >

            var step0A = stepListRaw.FirstOrDefault(p => p.Attribute("step_sequence").Value == "0");

            //<cond name="SITE" seq="1" uom="NONE">ETL-LAB</cond>
            //<cond name="TEMPERATURE" seq="1" uom="NONE">LAB AMBIENT</cond>
            //<cond name="PREFER DRIVER" seq="1" uom="NONE">NAG NICK GULLATTA - TEX/AKR</cond>
            //<cond name="MACHINE NAME" seq="1" uom="NONE">DIM250 AKRON</cond>
            //<cond name="DURATION" seq="1" uom="NONE">1 TO 10 SUBJECTIVE DISTURBANCE RATINGS</cond>
            //<cond name="SURFACE" seq="1" uom="NONE">CONCRETE OR MACADAM WITH IRREGULARITIES TO SATISFY</cond>
            //<cond name="SURFACE" seq="2" uom="NONE">TEST CONDITIONS</cond>
            //<cond name="RADIAL LOAD" seq="1" uom="NONE">CURB + DRIVER</cond>
            //<cond name="SPEED" seq="1" uom="NONE">VARIABLE</cond>
            //<cond name="SUPPLEMENTAL" seq="1" uom="NONE">TIRE/VEHICLE MODELS TO BE PROVIDED</cond>
            //<cond name="SUPPLEMENTAL" seq="2" uom="NONE">BY TVM UPON REQUEST</cond>
            //<cond name="SUPPLEMENTAL" seq="3" uom="NONE">THE NORMAL GOODYEAR HARSHNESS EVAULATION TO BE</cond>
            //<cond name="SUPPLEMENTAL" seq="4" uom="NONE">PERFORMED</cond>
            //<cond name="VEHICLE MODEL" seq="1" uom="NONE">VW GOLF 8</cond>

            var conds = step0A.Elements().Descendants("cond");
            var PREFER_DRIVERRaw = conds.FirstOrDefault(i => i.Attribute("name").Value == "PREFER DRIVER");
            var driver = PREFER_DRIVERRaw.Value;
          
            TestRequest tempRequest = new TestRequest();

           //tempRequest.Car = 

          
            //var tire = preferences.Descendants().FirstOrDefault(i => i.Attribute("name").Value == tirePositionStringValue);
            //tire.Attribute("value").Value = value;



            return null;
        }

   
    }
}
