using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    [Table("Stylists")]
    public class Stylist
    {
        [Key]
        public int StylistId { get; set; }
        public string StylistFirstName { get; set; }
        public string StylistLastName { get; set; }
        public virtual ICollection<StylistClient> StylistClients { get; set; }
        public virtual ICollection<StylistSpecialty> StylistSpecialties { get; set; }
    }
}