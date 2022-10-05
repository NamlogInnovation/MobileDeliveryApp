using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MobileDeliveryApp.DataAccess.Database.Tables;
using SQLitePCL;

namespace MobileDeliveryApp.DataAccess.Database.DatabaseContext
{
    public class MobileDeliveryAppDbContext : DbContext
    {
        public DbSet<WaybillInformation> WaybillInformation { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public MobileDeliveryAppDbContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.MigrateAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MobileDeliveryAppDb.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
