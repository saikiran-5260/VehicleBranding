﻿using AutoMapper;
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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _VR;
        private readonly IMapper _mapper;

        public VehicleService()
        {
        }

        public VehicleService(IVehicleRepository vR, IMapper mapper)
        {
            _VR = vR;
            _mapper = mapper;
        }

        public VehicleModelDTO CreateVehicle(VehicleModelDTO model)
        {
            var vehicle = new VehicleModelDTO()
            {
                //VehicleId= model.VehicleId,
                VehicleName= model.VehicleName,
                VIN_Number= model.VIN_Number,
                Engine = model.Engine,
                FuelCapacity= model.FuelCapacity,
                FuelReserveCapacity= model.FuelReserveCapacity,
                MileagePerLit= model.MileagePerLit,
                SeatCapacity= model.SeatCapacity,
                VehicleTypeName= model.VehicleTypeName,
                TransmissionName= model.TransmissionName,
                CreatedOn= model.CreatedOn,
                CreatedBy= model.CreatedBy,
            };
            var newVehicle = _mapper.Map<VehicleModel>(vehicle);
            var createdVehicle = _VR.CreateVehicle(newVehicle);
            return _mapper.Map<VehicleModelDTO>(createdVehicle);
        }

        public VehicleColorMappingDTO CreateVehicleMapping(VehicleColorMappingDTO model)
        {
            var vehicleColorMapping = new VehicleColorMappingDTO()
            {
                VehicleName = model.VehicleName,
                ColorName = model.ColorName,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.CreatedBy
            };

            VehicleColorMapping newVehicleColorMapping = _mapper.Map<VehicleColorMapping>(model);
            var createdVehicleColorMap = _VR.CreateVehicleMapping(newVehicleColorMapping);
            return _mapper.Map<VehicleColorMappingDTO>(createdVehicleColorMap);
        }

        public string DeleteVehicleDetails(int id)
        {
            var deleteVehicle = _VR.DeleteVehicleDetails(id);
            return deleteVehicle;
        }

        public List<VehicleDetailsDTO> GetVehicleDetails()
        {
            var vehicleDetails = _VR.GetVehicleDetails();
            return (_mapper.Map<List<VehicleDetailsDTO>>(vehicleDetails));
        }

        public List<VehicleDetailsDTO> GetVehicleDetailsByChassisNumber(string ChassisNumber)
        {
            var getVehicleByChasssiNum = _VR.GetVehicleDetailsByChassisNumber(ChassisNumber);
            return (_mapper.Map<List<VehicleDetailsDTO>>(getVehicleByChasssiNum));
        }

        public List<VehicleDetailsDTO> GetVehicleDetailsById(int id)
        {
            var vehicleById = _VR.GetVehicleDetailsById(id);
            return (_mapper.Map<List<VehicleDetailsDTO>>(vehicleById));
        }

        public VehicleModelDTO UpdateVehicle(VehicleModelDTO model, int id)
        {
            
            //var newVehicleDTO = new VehicleModelDTO()
            //{
            //    VehicleName = model.VehicleName,
            //    VIN_Number = model.VIN_Number,
            //    Engine = model.Engine,
            //    FuelCapacity = model.FuelCapacity,
            //    FuelReserveCapacity = model.FuelReserveCapacity,
            //    MileagePerLit = (model.MileagePerLit),
            //    SeatCapacity = (model.SeatCapacity),
            //    VehicleTypeId = model.VehicleTypeId,
            //    TransmissionId = model.TransmissionId,
            //    CreatedOn = (model.CreatedOn),
            //    CreatedBy = (model.CreatedBy)
            //};
            var Vehicle = (_mapper.Map<VehicleModel>(model));
            var updateVehicle = _VR.UpdateVehicle(Vehicle,id);
            return _mapper.Map<VehicleModelDTO>(updateVehicle);

        }

        public VehicleColorMappingDTO UpdateVehicleColorMapping(VehicleColorMappingDTO model, int id)
        {

            //var vehicleColorMappingDTO = new VehicleColorMappingDTO()
            //{
            //    ColorMappingId = model.ColorMappingId,
            //    VehicleName = model.VehicleName,
            //    ColorName = model.ColorName,
            //    CreatedOn = model.CreatedOn,
            //    CreatedBy = model.CreatedBy,
            //};
            var mapperVehicle = (_mapper.Map<VehicleColorMapping>(model));
            var updateVehicleColorMap = _VR.UpdateVehicleColorMapping(mapperVehicle,id);
            return _mapper.Map<VehicleColorMappingDTO>(updateVehicleColorMap);
        }
    }
}
