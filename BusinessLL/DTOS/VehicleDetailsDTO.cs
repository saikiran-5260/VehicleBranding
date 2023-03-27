﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLL.DTOS
{
    public class VehicleDetailsDTO
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string Chassis_Number { get; set; }
        public string Engine { get; set; }
        public int FuelCapacity { get; set; }
        public int FuelReserveCapacity { get; set; }
        public int MileagePerLit { get; set; }
        public int SeatCapacity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string VehicleTypeName { get; set; }
        public string CreatedBy { get; set; }
        public string ColorName { get; set; }
        public string TransmissionName { get; set; }
    }
}
