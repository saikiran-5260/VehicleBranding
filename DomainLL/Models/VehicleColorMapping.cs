using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLL.Models
{
    public class VehicleColorMapping
    {
        [Key]
        public int ColorMappingId { get; set; }
        public int VehicleId { get; set; }
        public byte ColorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
