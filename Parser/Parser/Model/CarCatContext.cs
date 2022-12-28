using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Parser.Model.Models;
using Parser.Model.Models.BaseClasses;
using Parser.Model.Models.Classes;
using Parser.Model.Models.Configuration;
using Parser.Model.ViewModels;

namespace Parser.Model
{
    public class CarCatContext : DbContext
    {
        public DbSet<Car> Cars { set; get; }
        public DbSet<Body> Bodies { set; get; }
        public DbSet<Configuration_Car> Configuration_Cars { set; get; }
        public DbSet<FuelInduction> FuelInductions { set; get; }
        public DbSet<BuildingContition> BuildingContitions { set; get; }
        public DbSet<Grade> Grades { set; get; }
        public DbSet<ATM_MTM> ATM_MTMs { set; get; }
        public DbSet<GearShiftType> GearShiftTypes { set; get; }
        public DbSet<Cab> Cabs { set; get; }
        public DbSet<TransmissionModel> TransmissionModels { set; get; }
        public DbSet<LoadingCapacity> LoadingCapacities { set; get; }
        public DbSet<RearTire> RearTires { set; get; }
        public DbSet<Destination> Destinations { set; get; }
        public DbSet<CarPresent> CarPresents { set; get; }

        public BaseConfiguration GetConfigObj(string valueSearch, string nameObject)
        {
            if (nameObject.Equals(NameTableFromSite.Body))
            {
                return Bodies.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.FuelInduction))
            {
                return FuelInductions.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.BuildingCondition))
            {
                return BuildingContitions.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.Grade))
            {
                return Grades.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.ATM_MTM))
            {
                return ATM_MTMs.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.GearShiftType))
            {
                return GearShiftTypes.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.Cab))
            {
                return Cabs.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.TransmissionModel))
            {
                return TransmissionModels.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.LoadingCapacity))
            {
                return LoadingCapacities.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.RearTire))
            {
                return RearTires.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            else if (nameObject.Equals(NameTableFromSite.Destination))
            {
                return Destinations.Where(b => b.Value.Equals(valueSearch)).FirstOrDefault();
            }
            return null;
        }

        public BaseConfiguration CreateNewDbItem(string value, string nameObject)
        {
            if (nameObject.Equals(NameTableFromSite.Body))
            {
                return new Body(value);
            }
            else if (nameObject.Equals(NameTableFromSite.FuelInduction))
            {
                return new FuelInduction(value);
            }
            else if (nameObject.Equals(NameTableFromSite.BuildingCondition))
            {
                return new BuildingContition(value);
            }
            else if (nameObject.Equals(NameTableFromSite.Grade))
            {
                return new Grade(value);
            }
            else if (nameObject.Equals(NameTableFromSite.ATM_MTM))
            {
                return new ATM_MTM(value);
            }
            else if (nameObject.Equals(NameTableFromSite.GearShiftType))
            {
                return new GearShiftType(value);
            }
            else if (nameObject.Equals(NameTableFromSite.Cab))
            {
                return new Cab(value);
            }
            else if (nameObject.Equals(NameTableFromSite.TransmissionModel))
            {
                return new TransmissionModel(value);
            }
            else if (nameObject.Equals(NameTableFromSite.LoadingCapacity))
            {
                return new LoadingCapacity(value);
            }
            else if (nameObject.Equals(NameTableFromSite.RearTire))
            {
                return new RearTire(value);
            }
            else if (nameObject.Equals(NameTableFromSite.Destination))
            {
                return new Destination(value);
            }
            return null;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
               .Entity<CarPresent>()
               .ToView("TakeData")
               .HasKey(t => t.Id);
        }
        string configvalue1 = ConfigurationManager.AppSettings["ClientsFilePath"];
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(configvalue1);
    }
}
