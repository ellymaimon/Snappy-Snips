using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    [Table("StylistClients")]
    public class StylistClient
    {
        [Key]
        public int StylistClientId { get; set; }
        public int ClientId { get; set; }
        public int StylistId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Stylist Stylist { get; set; }

        public StylistClient() { }

        public StylistClient(int clientId, int stylistId)
        {
            ClientId = clientId;
            StylistId = stylistId;
        }
    }
}