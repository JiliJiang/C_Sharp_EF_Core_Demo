using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace EFDataAccessLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options): base(options) { }
        public Microsoft.EntityFrameworkCore.DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}
