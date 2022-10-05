using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Models.Authentication
{
    public class EmployeeModel
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Department { get; set; }
        public string ScanTagToken { get; set; }
    }
}
