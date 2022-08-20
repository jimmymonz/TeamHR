using Microsoft.EntityFrameworkCore;
using TeamHR.DAO;

namespace TeamHR.Services
{
    public class TeamHRContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public string DbPath { get; }
        public TeamHRContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "teamHR.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
