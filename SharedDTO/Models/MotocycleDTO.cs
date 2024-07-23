namespace SharedDTO.Models
{
    public class MotocycleDTO
    {
        public string MotocycleBrand { get; set; }
        public string Model { get; set; }
        public DateTime? ProductionStartYears { get; set; }
        public DateTime? ProductionEndYears { get; set; }
        public string HorsePower { get; set; }
        public string Displacement { get; set; }


        public override string ToString()
        {
            return MotocycleBrand + Model;
        }
    }
}
