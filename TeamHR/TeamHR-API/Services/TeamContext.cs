using Microsoft.EntityFrameworkCore;
using teamhr_api.DAO;

namespace teamhr_api.Services
{
    public class TeamContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public string DbPath { get; }

        public TeamContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "teamhr.db");
        }

        //Configures EF to create a SQLite database file in the special "local" folder on your device.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }

}
