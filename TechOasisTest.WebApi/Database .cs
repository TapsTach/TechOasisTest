using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechOasisTest.Shared.Entities;

namespace TechOasisTest.WebApi
{
    public class Database :DbContext
    {
        public Database (DbContextOptions options):base(options)
        {

        }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
    }
}
