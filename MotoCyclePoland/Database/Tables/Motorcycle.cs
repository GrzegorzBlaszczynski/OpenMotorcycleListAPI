using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorCyclePoland.Database.Tables
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }


        public int BrandId { get; set; }
        public string Name { get; set; }    


        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public int HorsePower { get;set; }


        public int Displacement { get; set; }
        public DateTime StartProduction { get; set; }
        
        public DateTime? EndProduction { get; set; }

        public float? TankCapacity { get; set; }
        public string? Drive { get; set; }
        public int? GearCount { get; set; }

        public int? Mass { get; set; }

        public string? Size { get; set; }
    }
}
