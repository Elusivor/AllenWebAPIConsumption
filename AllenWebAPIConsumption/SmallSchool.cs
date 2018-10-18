using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllenWebAPIConsumption
{
    public class SmallSchool
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public override string ToString()
        {
            return $"{SchoolName}";
        }
    }
}
