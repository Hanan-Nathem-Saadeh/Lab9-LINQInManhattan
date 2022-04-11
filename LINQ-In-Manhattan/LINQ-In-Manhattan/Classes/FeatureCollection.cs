using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_In_Manhattan.Classes;
namespace LINQ_In_Manhattan
{
    public class FeatureCollection
    {
        public string type { get; set; }
        public List<feature> features
        { get; set; }
    }
}
