using BusinessLL.DTOS;
using DomainLL.DomainLayer;
using DomainLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLL.BusinessLogic
{
    public interface IVehicleService
    {
        List<VehicleDetailsDTO> GetVehicleDetailsById(int id);
        List<VehicleDetailsDTO> GetVehicleDetailsByChassisNumber(string ChassisNumber);
        List<VehicleDetailsDTO> GetVehicleDetails();
        int CreateVehicle(VehicleModelDTO model);
        int UpdateVehicle(VehicleModelDTO model, int id);
        int CreateVehicleMapping(VehicleColorMappingDTO model);
        int UpdateVehicleColorMapping(VehicleColorMappingDTO model, int id);
        string DeleteVehicleDetails(int id);

    } 
}
