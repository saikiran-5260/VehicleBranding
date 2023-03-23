using DomainLL.Data;
using DomainLL.Models;
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

        public VehicleModel CreateVehicle(VehicleModel model)
        {
            _db.Add(model);
            _db.SaveChanges();
            return model;
            
        }

        public VehicleColorMapping CreateVehicleMapping(VehicleColorMapping model)
        {
            _db.Add(model);
            _db.SaveChanges();
            return model;
        }

        public VehicleModel UpdateVehicle(VehicleModel model, int id)
        {
            var vehicleModel = _db.Vehicle.FirstOrDefault(x => x.VehicleId == id);
            if (vehicleModel != null)
            {
                vehicleModel.VehicleId = id;
                vehicleModel.VehicleName = model.VehicleName;
                vehicleModel.VIN_Number = model.VIN_Number;
                vehicleModel.Engine = model.Engine;
                vehicleModel.FuelCapacity = model.FuelCapacity;
                vehicleModel.FuelReserveCapacity = model.FuelReserveCapacity;
                vehicleModel.MileagePerLit = model.MileagePerLit;
                vehicleModel.SeatCapacity = model.SeatCapacity;
                vehicleModel.CreatedOn = model.CreatedOn;
                vehicleModel.CreatedBy = model.CreatedBy;
                vehicleModel.VehicleTypeId = model.VehicleTypeId;
                vehicleModel.TransmissionId = model.TransmissionId;
            }
            else
            {
                return null;
            }
            _db.Update(vehicleModel);
            _db.SaveChanges();
            return vehicleModel;



        }

        public VehicleColorMapping UpdateVehicleColorMapping(VehicleColorMapping model, int id)
        {
            var vehicleColorMappaping = _db.VehicleColorMapping.FirstOrDefault(x=>x.ColorMappingId== id);
            //if(vehicleColorMappaping!= null)
            //{
            //    vehicleColorMappaping.ColorMappingId = id;
            //    vehicleColorMappaping.VehicleId = model.VehicleId;
            //    vehicleColorMappaping.ColorId = model.ColorId;
            //    vehicleColorMappaping.CreatedOn = model.CreatedOn;
            //    vehicleColorMappaping.CreatedBy = model.CreatedBy;
            //}
            //else
            //{
            //    return null;
            //}
            if(vehicleColorMappaping != null)
            {
                _db.Update(vehicleColorMappaping);
                _db.SaveChanges();
                return vehicleColorMappaping;
            }
            else
            {
                return null;
            }
           
        }
    }
}
