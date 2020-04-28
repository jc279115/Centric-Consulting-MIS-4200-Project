using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Centric_Consulting_MIS_4200_Project.Models; // This is needed to access the models
using System.Data.Entity; // this is needed to access the DbContext object
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Centric_Consulting_MIS_4200_Project.DAL
{
    public class MIS4200Context : DbContext // inherits from DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        { 
        }

        public DbSet <Profile> Profiles { get; set; }

        public System.Data.Entity.DbSet<Centric_Consulting_MIS_4200_Project.Models.Leaderboard> Leaderboards { get; set; }

        public System.Data.Entity.DbSet<Centric_Consulting_MIS_4200_Project.Models.NominationPage> NominationPages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}