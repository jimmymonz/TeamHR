using Microsoft.EntityFrameworkCore;
using TeamHR.DAO;

namespace TeamHR.Services
{
    public class TeamHRContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public string DbPath { get; }

        //Setup the location for the database file
        public TeamHRContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "teamHR.db");
        }

        //The configuration of EF to create a Sqlite database file in the local folder
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
