#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

    public class MvcSchoolContext : DbContext
    {
        public MvcSchoolContext (DbContextOptions<MvcSchoolContext> options)
            : base(options)
        {
        }

        public DbSet<School.Models.Countries> Countries { get; set; }

        public DbSet<School.Models.Classes> Classes { get; set; }
    }
