using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Models.ScanLoad
{
    public class ScannedLoadWaybill
    {
        public bool succeeded { get; set; }
        public IEnumerable<Data> data { get; set; }  = new List<Data>();
    }
}
