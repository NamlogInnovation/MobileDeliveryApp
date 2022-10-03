using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.Models.Authentication
{
    public class AuthResponseModel
    {
        public bool succeeded { get; set; }
        public string message { get; set; }
        public Data data { get; set; } = new Data();

    }
}
