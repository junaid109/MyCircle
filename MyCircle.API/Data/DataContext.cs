using Microsoft.EntityFrameworkCore;
using MyCircle.API.Entities;

namespace MyCircle.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        
        public DbSet<AppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MySocialDB;Trusted_Connection=True;");


        }

    }
}
