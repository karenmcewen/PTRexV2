﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PTRex.MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PTRexEntities : DbContext
    {
        public PTRexEntities()
            : base("name=PTRexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActualWorkout> ActualWorkouts { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<PainLevel> PainLevels { get; set; }
        public virtual DbSet<ProfilePix> ProfilePixes { get; set; }
        public virtual DbSet<TargetWorkout> TargetWorkouts { get; set; }
        public virtual DbSet<TimeOfDay> TimeOfDays { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
    }
}
