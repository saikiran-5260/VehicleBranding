﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLL.DTOS
{
    public class VehicleColorMappingDTO
    {
        //public int ColorMappingId { get; set; }
        public string VehicleName { get; set; }
        public string ColorName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
