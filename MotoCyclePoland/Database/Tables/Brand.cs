using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotorCyclePoland.Database.Tables
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Motorcycle> Motorcycles { get; set; }
    }
}
