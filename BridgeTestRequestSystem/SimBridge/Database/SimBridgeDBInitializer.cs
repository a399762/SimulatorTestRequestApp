    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimBridge.Database
{
    public class SimBridgeDBInitializer: DropCreateDatabaseAlways<SimBridgeDataContext>
    {
        protected override void Seed(SimBridgeDataContext context)
        {
            //IList<Grade> grades = new List<Grade>();

            //grades.Add(new Grade() { GradeName = "Grade 1", Section = "A" });
            //grades.Add(new Grade() { GradeName = "Grade 1", Section = "B" });
            //grades.Add(new Grade() { GradeName = "Grade 1", Section = "C" });
            //grades.Add(new Grade() { GradeName = "Grade 2", Section = "A" });
            //grades.Add(new Grade() { GradeName = "Grade 3", Section = "A" });

            //context.Grades.AddRange(grades);

            //base.Seed(context);
        }
    }
}
