using DomainLL.Data;
using DomainLL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLL.DomainLayer
{
    public class VehicleRepository : IVehicleRepository
    {
        private ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        //private readonly SqlConnection _conn;
        //private readonly string _CS = "\"server=(LocalDb)\\\\AL5260;database = Vehicles ;TrustServerCertificate = True;";
        public VehicleRepository(ApplicationDbContext db ,IConfiguration configuration/*SqlConnection conn, string CS*/)
        {
            _db = db;
            //_conn = conn;
            //_CS = CS;
            _configuration= configuration;
        }

        public VehicleModel CreateVehicle(VehicleModel model)
        {
            //int createVehicle = _db.Database.ExecuteSqlRaw($"spPostVehicleDetails @VehicleName='{model.VehicleName}',@VIN_Number='{model.VIN_Number}',@Engine= '{model.Engine}',@FuelCapacity='{model.FuelCapacity}',@FuelReserveCapacity='{model.FuelReserveCapacity}'," +
            //    $"@MileagePerLit='{model.MileagePerLit}',@SeatCapacity='{model.SeatCapacity}',@VehicleTypeName='{model.VehicleTypeName}',@TransmissionName='{model.TransmissionName}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'");
            //return createVehicle;
            int i;
            using(SqlConnection con = new SqlConnection(_configuration.GetConnectionString("VehicelConnection"))) 
            {
                SqlCommand sqlCommand = new SqlCommand("spPostVehicleDetails", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VehicleName", model.VehicleName);
                sqlCommand.Parameters.AddWithValue("@VIN_Number", model.VIN_Number);
                sqlCommand.Parameters.AddWithValue("@Engine", model.Engine);
                sqlCommand.Parameters.AddWithValue("@FuelCapacity", model.FuelCapacity);
                sqlCommand.Parameters.AddWithValue("@FuelReserveCapacity", model.FuelReserveCapacity);
                sqlCommand.Parameters.AddWithValue("@MileagePerLit", model.MileagePerLit);
                sqlCommand.Parameters.AddWithValue("@SeatCapacity", model.SeatCapacity);
                sqlCommand.Parameters.AddWithValue("@VehicleTypeName", model.VehicleTypeName);
                sqlCommand.Parameters.AddWithValue("@TransmissionName", model.TransmissionName);
                sqlCommand.Parameters.AddWithValue("@CreatedOn", model.CreatedOn);
                sqlCommand.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                con.Open();
                i = sqlCommand.ExecuteNonQuery();
            };
            if(i == -1)
            {
                return model;

            }
            else
            {
                return null;
            }
            
        }

        public VehicleColorMapping CreateVehicleMapping(VehicleColorMapping model)
        {
            
            var vehicleColorMapping = _db.Database.ExecuteSqlRaw($"spPostVehicleColorMappingDetails @VehicleName='{model.VehicleName}',@ColorName='{model.ColorName}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'");
            if (vehicleColorMapping == -1)
            {
                return model;
            }
            return null;
        }

        public string DeleteVehicleDetails(int id)
        {
            var deleteVehicle = _db.Database.ExecuteSqlRaw($"spDeleteVehicle {id}");
            if (deleteVehicle ==-1)
            {
                return "deleted Successfully";
            }
            else
            {
                return "not found";
            }
              
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

        public VehicleModel UpdateVehicle(VehicleModel model, int id)
        {
            
            var updatedVehicle = _db.Database.ExecuteSqlRaw($"spUpdateVehicleDetails @Id='{id}',@VehicleName='{model.VehicleName}'," +
                $"@VIN_Number='{model.VIN_Number}',@Engine='{model.Engine}',@FuelCapacity='{model.FuelCapacity}',@FuelReserveCapacity='{model.FuelReserveCapacity}'," +
                $"@MileagePerLit='{model.MileagePerLit}',@SeatCapacity='{model.SeatCapacity}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'," +
                $"@VehicleTypeName='{model.VehicleTypeName}',@TransmissionName='{model.TransmissionName}'");
            if(updatedVehicle == -1)
            {
                return model;
            }
            return null;
            
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
        }

        public VehicleColorMapping UpdateVehicleColorMapping(VehicleColorMapping model, int id)
        {
            var updatedVehicleColorMapping = _db.Database.ExecuteSqlRaw($"spUpdateVehicleColorMappingDetails @Id='{id}',@VehicleName='{model.VehicleName}',@ColorName='{model.ColorName}',@CreatedOn='{model.CreatedOn}',@CreatedBy='{model.CreatedBy}'");

           
            if(updatedVehicleColorMapping == -1 )
            {
                return model;
            }
            return null;
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

        }
    }
}
