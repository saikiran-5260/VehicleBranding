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
        List<VehicleDetails> GetVehicleDetailsById(int id);
        List<VehicleDetails> GetVehicleDetailsByChassisNumber(string ChassisNumber);
        List<VehicleDetails> GetVehicleDetails();
        VehicleModel CreateVehicle(VehicleModel model);
        VehicleModel UpdateVehicle(VehicleModel model,int id);
        VehicleColorMapping CreateVehicleMapping (VehicleColorMapping model);
        VehicleColorMapping UpdateVehicleColorMapping (VehicleColorMapping model,int id);
        string DeleteVehicleDetails(int id);
    }
}
