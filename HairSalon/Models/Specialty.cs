using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    [Table("Specialties")]
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StylistSpecialty> StylistSpecialties { get; set; }
    }
}
