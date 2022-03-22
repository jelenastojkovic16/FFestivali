using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Festival
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string NazivFestivala { get; set; }

        [Required]
        public string OpisFestivala { get; set; }

        [MaxLength(50)]
        [Required]
        public string Grad { get; set; }

        [MaxLength(50)]
        [Required]    
        public string Adresa { get; set; }

        
        [Required]
        public DateTime Pocetak { get; set; }
        [Required]
        public DateTime Kraj { get; set; }

        [JsonIgnore]
        public List<DnevniRepertoar> DnevniRepertoari{ get; set; }
       
        
    }
}