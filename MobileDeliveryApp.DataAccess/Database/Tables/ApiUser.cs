using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.DataAccess.Database.Tables
{
    public class ApiUser : BaseTableModel
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }
}
