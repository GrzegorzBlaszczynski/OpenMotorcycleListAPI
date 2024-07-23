using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotoCyclePoland.Database.Tables;
using SharedDTO.Models;

namespace MotoCyclePoland.Database
{
    public class motoDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Motocycle> Motocycles { get; set; }



        public motoDbContext(DbContextOptions<motoDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandModelConfig());
            modelBuilder.ApplyConfiguration(new BMotocycleModelConfig());
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
                modelBuilder.Entity<Motocycle>().HasData(
                       new Motocycle
                       {
                           Id = id,
                           Name = temp.MotocycleName,
                           BrandId = BrandList.IndexOf(BrandList.FirstOrDefault(x=>x.Brand == temp.Brand))+1,
                           Displacement = int.Parse(temp.Displacement.Replace(" cm","")),
                           StartProduction = new DateTime(int.Parse(temp.ProductionYears.Split(" - ")[0]),1,1),
                           HorsePower = int.Parse(temp.HorsePower.Replace("KM",""))
                       });
                id++;
            }
        }
    }
}
