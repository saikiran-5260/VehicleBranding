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
        int CreateVehicle(VehicleModel model);
        int UpdateVehicle(VehicleModel model,int id);
        int CreateVehicleMapping(VehicleColorMapping model);
        int UpdateVehicleColorMapping(VehicleColorMapping model,int id);
        string DeleteVehicleDetails(int id);
    }
}
