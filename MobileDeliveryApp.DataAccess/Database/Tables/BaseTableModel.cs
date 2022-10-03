using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDeliveryApp.DataAccess.Database.Tables
{
    public class BaseTableModel
    {
        [Key]
        public int Id { get; set; }
    }
}
