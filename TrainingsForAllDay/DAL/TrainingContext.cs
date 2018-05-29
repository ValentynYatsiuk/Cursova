using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrainingsForAllDay.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TrainingsForAllDay.DAL
{
    public class TrainingContext : DbContext
    {
        public TrainingContext() : base("TrainingContext")
        {
        }
        public DbSet<DateModel> DateModels { get; set; }
        public DbSet<MondayModel> MondayModels { get; set; }
        public DbSet<WednesdayModel> WednesdayModels { get; set; }
        public DbSet<FridayModel> FridayModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}