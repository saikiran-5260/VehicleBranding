using DomainLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLL.DomainLayer
{
    public interface IVehicleRepository
    {
        VehicleModel CreateVehicle(VehicleModel model);
        VehicleModel UpdateVehicle(VehicleModel model,int id);
        VehicleColorMapping CreateVehicleMapping (VehicleColorMapping model);
        VehicleColorMapping UpdateVehicleColorMapping (VehicleColorMapping model,int id);
    }
}
