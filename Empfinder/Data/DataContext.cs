using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;
using Empfinder.Models;

namespace cardscore_api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ParserInstructor> ParserInstructors { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Debug);
        }
    }
}