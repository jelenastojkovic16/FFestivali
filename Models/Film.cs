using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Film{
        [Key]
        public int ID { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string NazivFilma { get; set; }

        [MaxLength(50)]
        [Required]
        public string ImeReditelja { get; set; }

        [Required]
        public DateTime Vreme { get; set; }

        [Required]
        public int Trajanje { get; set; }

        
        [JsonIgnore]
        public virtual DnevniRepertoar Dan { get; set; }

        
        
    }
}