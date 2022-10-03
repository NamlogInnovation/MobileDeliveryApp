using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Models.Authentication
{
    public class Data
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string displayName { get; set; }
        public string jwToken { get; set; }
    }
}
