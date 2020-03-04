﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Centric_Consulting_MIS_4200_Project.Models; // This is needed to access the models
using System.Data.Entity; // this is needed to access the DbContext object


namespace Centric_Consulting_MIS_4200_Project.DAL
{
    public class MIS4200Context : DbContext // inherits from DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        { 
        }

        public DbSet <Profile> Profiles { get; set; }

    }
}