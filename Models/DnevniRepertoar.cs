using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class DnevniRepertoar
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public float Cena { get; set; }
        [Required]
        public string Dan { get; set; }
        [Required]
        public DateTime Datum { get; set; }

        [JsonIgnore]
        public virtual Festival Festival { get; set; }
        
        [JsonIgnore]
        public List<Film> Filmovi { get; set; }
        public List<Karta> Karte { get; set; }
        


        
    }
}