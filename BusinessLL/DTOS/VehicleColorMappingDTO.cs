using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLL.DTOS
{
    public class VehicleColorMappingDTO
    {
        public int ColorMappingId { get; set; }
        public int VehicleId { get; set; }
        public byte ColorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
