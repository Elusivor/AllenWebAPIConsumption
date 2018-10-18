using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllenWebAPIConsumption
{
    public class SchoolData
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Website { get; set; }

        public override string ToString()
        {
            return $"School ID: {SchoolID} \r\nSchool name: {SchoolName} \r\nAddress1: {Address1} \r\nAddress2: {Address2} \r\nCity: {City} \r\nPostCode: {PostCode} \r\nWebsite: {Website}";
        }
    }
}
