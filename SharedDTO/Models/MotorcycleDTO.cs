namespace SharedDTO.Models
{
    public class MotorcycleDTO
    {
        public string MotorcycleBrand { get; set; }
        public string Model { get; set; }
        public DateTime? ProductionStartYear { get; set; }
        public DateTime? ProductionEndYear { get; set; }
        public string HorsePower { get; set; }
        public string Displacement { get; set; }

        public float? TankCapacity { get; set; }
        public string? Drive { get; set; }
        public int? GearCount { get; set; }

        public int? Mass { get; set; }

        public string? Size { get; set; }

        public override string ToString()
        {
            return MotorcycleBrand+ " " + Model;
        }
    }
}
