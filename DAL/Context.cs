using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        public Context()
            : base("MyDatabaseConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Configurations;
            config.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
