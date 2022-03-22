using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Karta
    {
        [Key]
        public int ID { get; set; }

        [Range(1,5)]
        [Required]
        public int BrojUlaznica { get; set; }

        [JsonIgnore]
        public virtual DnevniRepertoar Dan { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}