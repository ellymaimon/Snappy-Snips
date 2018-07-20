using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    [Table("StylistSpecialties")]
    public class StylistSpecialty
    {
        [Key]
        public int StylistSpecialtyId { get; set; }
        public int SpecialtyId { get; set; }
        public int StylistId { get; set; }
        public virtual Specialty Specialty { get; set; }
        public virtual Stylist Stylist { get; set; }

        public StylistSpecialty() { }

        public StylistSpecialty(int specialtyId, int stylistId)
        {
            SpecialtyId = specialtyId;
            StylistId = stylistId;
        }
    }
}