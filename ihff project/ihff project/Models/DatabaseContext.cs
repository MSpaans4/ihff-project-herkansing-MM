using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ihff_project.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseConnection")
        {
        }

        public DbSet<Film> Films { get; set; }
    }
}