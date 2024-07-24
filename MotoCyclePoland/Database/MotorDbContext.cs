using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotorCyclePoland.Database.Tables;
using SharedDTO.Models;

namespace MotorCyclePoland.Database
{
    public class MotorDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }



        public MotorDbContext(DbContextOptions<MotorDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandModelConfig());
            modelBuilder.ApplyConfiguration(new MotorcycleModelConfig());
            base.OnModelCreating(modelBuilder);

            StreamReader streamReader = new StreamReader("moto.csv");
            List<AutoMotocycleDataSeed> motoList = new List<AutoMotocycleDataSeed>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

                string[] data = line.Split(';');

                AutoMotocycleDataSeed temp = new AutoMotocycleDataSeed()
                {
                    Brand = data[0],
                    MotocycleName = data[1],
                    ProductionYears = data[2],
                    HorsePower = data[3],
                    Displacement = data[4],
                };

                motoList.Add(temp);
            }

            List<AutoMotocycleDataSeed> BrandList = motoList.DistinctBy(x => x.Brand).ToList();
            int id = 1;
            foreach (var temp in BrandList)
            {
                modelBuilder.Entity<Brand>().HasData(
                       new Brand
                       {
                           Id = id,
                           Name = temp.Brand
                       });
                id++;
            }

            id = 1;
            foreach (var temp in motoList)
            {


                DateTime? endProduction = (temp.ProductionYears.Split(" - ").Length == 2) ? new DateTime(int.Parse(temp.ProductionYears.Split(" - ")[1]), 1, 1) : null;
                modelBuilder.Entity<Motorcycle>().HasData(
                       new Motorcycle
                       {
                           Id = id,
                           Name = temp.MotocycleName,
                           BrandId = BrandList.IndexOf(BrandList.FirstOrDefault(x=>x.Brand == temp.Brand))+1,
                           Displacement = int.Parse(temp.Displacement.Replace(" cm","")),
                           StartProduction = new DateTime(int.Parse(temp.ProductionYears.Split(" - ")[0]),1,1),
                           EndProduction = endProduction,
                           HorsePower = int.Parse(temp.HorsePower.Replace("KM",""))
                       });
                id++;
            }


            streamReader.Close();
        }
    }
}
