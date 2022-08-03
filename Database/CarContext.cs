using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;

namespace EsercizioSuEntityFramework_Linq.Database
{
     class CarContext:DbContext
    {
        public DbSet<RootObject> RootObject { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSetting.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CarDb")).LogTo(Console.WriteLine,LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>modelBuilder.Entity<RootObject>().ToTable("RootObject");
    

    }
}
