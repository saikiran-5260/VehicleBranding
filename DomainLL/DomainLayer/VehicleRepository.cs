using DomainLL.Data;
using DomainLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLL.DomainLayer
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _db;
        public VehicleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int CreateVehicle(VehicleModel model)
        {
            int createVehicle = _db.Database.ExecuteSqlRaw($"spPostVehicleDetails @VehicleName='{model.VehicleName}',@VIN_Number='{model.VIN_Number}',@Engine= '{model.Engine}',@FuelCapacity='{model.FuelCapacity}',@FuelReserveCapacity='{model.FuelReserveCapacity}'," +
                $"@MileagePerLit='{model.MileagePerLit}',@SeatCapacity='{model.SeatCapacity}',@VehicleTypeName='{model.VehicleTypeName}',@TransmissionName='{model.TransmissionName}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'");
            return createVehicle;
                     
        }

        public int CreateVehicleMapping(VehicleColorMapping model)
        {

            int vehicleColorMapping = _db.Database.ExecuteSqlRaw($"spPostVehicleColorMappingDetails @VehicleName='{model.VehicleName}',@ColorName='{model.ColorName}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'");
            return vehicleColorMapping;
        }

        public string DeleteVehicleDetails(int id)
        {
            var deleteVehicle = _db.Vehicle.FirstOrDefault(x=>x.VehicleId== id);
            if (deleteVehicle != null)
            {
                _db.Vehicle.Remove(deleteVehicle);
                _db.SaveChanges();
            }
            else
            {
                return "not found";
            }
            return "deleted Successfully";
           
            
        }

        public List<VehicleDetails> GetVehicleDetails()
        {
            List<VehicleDetails> list = _db.vehicleDetails.FromSqlRaw("spgetVehicleDetails").ToList();
            if(list.Count == 0)
            {
                return null;
            }
            else
            {
                return list;
            }
        }

        public List<VehicleDetails> GetVehicleDetailsByChassisNumber(string ChassisNumber)
        {
            var vehicleDetailsByChassisNumber = _db.vehicleDetails.FromSqlRaw($"spgetVehicleByChassisNumber {ChassisNumber}").ToList();
            if (vehicleDetailsByChassisNumber.Count == 0)
            {
                return null;
            }
            else
            {
                return vehicleDetailsByChassisNumber;
            }
        }

        public List<VehicleDetails> GetVehicleDetailsById(int id)
        {
            var vehicleDetailsById = _db.vehicleDetails.FromSqlRaw($"spgetVehicleById {id}").ToList();
            if (vehicleDetailsById.Count == 0)
            {
                return null;
            }
            else
            {
                return vehicleDetailsById;
            }


        }

        public int UpdateVehicle(VehicleModel model, int id)
        {
            //var vehicleModel = _db.Vehicle.FirstOrDefault(x => x.VehicleId == id);
            //if (vehicleModel != null)
            //{
            //    vehicleModel.VehicleId = id;
            //    vehicleModel.VehicleName = model.VehicleName;
            //    vehicleModel.VIN_Number = model.VIN_Number;
            //    vehicleModel.Engine = model.Engine;
            //    vehicleModel.FuelCapacity = model.FuelCapacity;
            //    vehicleModel.FuelReserveCapacity = model.FuelReserveCapacity;
            //    vehicleModel.MileagePerLit = model.MileagePerLit;
            //    vehicleModel.SeatCapacity = model.SeatCapacity;
            //    vehicleModel.CreatedOn = model.CreatedOn;
            //    vehicleModel.CreatedBy = model.CreatedBy;
            //    vehicleModel.VehicleTypeName = model.VehicleTypeName;
            //    vehicleModel.TransmissionName = model.TransmissionName;
            //}
            //else
            //{
            //    return null;
            //}
            //_db.Update(vehicleModel);
            //_db.SaveChanges();
            //return vehicleModel;
            var updatedVehicle = _db.Database.ExecuteSqlRaw($"spUpdateVehicleDetails @Id='{id}',@VehicleName='{model.VehicleName}'," +
                $"@VIN_Number='{model.VIN_Number}',@Engine='{model.Engine}',@FuelCapacity='{model.FuelCapacity}',@FuelReserveCapacity='{model.FuelReserveCapacity}'," +
                $"@MileagePerLit='{model.MileagePerLit}',@SeatCapacity='{model.SeatCapacity}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'," +
                $"@VehicleTypeName='{model.VehicleTypeName}',@TransmissionName='{model.TransmissionName}'");

            return updatedVehicle;
        }

        public int UpdateVehicleColorMapping(VehicleColorMapping model, int id)
        {
            var updatedVehicleColorMapping = _db.Database.ExecuteSqlRaw($"spUpdateVehicleColorMappingDetails @Id='{id}',@VehicleName='{model.VehicleName}',@ColorName='{model.ColorName}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'");

            //var vehicleColorMappaping = _db.VehicleColorMapping.FirstOrDefault(x => x.ColorMappingId == id);
            //if (vehicleColorMappaping != null)
            //{
            //    vehicleColorMappaping.ColorMappingId = id;
            //    vehicleColorMappaping.VehicleName = model.VehicleName;
            //    vehicleColorMappaping.ColorName = model.ColorName;
            //    vehicleColorMappaping.CreatedOn = model.CreatedOn;
            //    vehicleColorMappaping.CreatedBy = model.CreatedBy;
            //}
            //else
            //{
            //    return null;
            //}
            //_db.Update(vehicleColorMappaping);
            //_db.SaveChanges();
            //return vehicleColorMappaping;
            return updatedVehicleColorMapping;
        }
    }
}
