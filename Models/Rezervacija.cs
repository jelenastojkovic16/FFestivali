using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Rezervacija
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(80)]
        [EmailAddress]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }  

        [MaxLength(50)]
        public string Ime { get; set; }

        [MaxLength(50)]
        public string Prezime { get; set; }

        [Required]
        public float UkupnaCena { get; set; }

    

       
      
        [JsonIgnore]
        public List<Karta> Karte { get; set; }

        
    }
}