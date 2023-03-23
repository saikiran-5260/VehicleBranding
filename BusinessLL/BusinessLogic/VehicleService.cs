using AutoMapper;
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
        public VehicleService(IVehicleRepository vR, IMapper mapper)
        {
            _VR = vR;
            _mapper = mapper;
        }

        public VehicleModelDTO CreateVehicle(VehicleModelDTO model)
        {
            var vehicle = new VehicleModelDTO()
            {
                VehicleId= model.VehicleId,
                VehicleName= model.VehicleName,
                VIN_Number= model.VIN_Number,
                Engine = model.Engine,
                FuelCapacity= model.FuelCapacity,
                FuelReserveCapacity= model.FuelReserveCapacity,
                MileagePerLit= model.MileagePerLit,
                SeatCapacity= model.SeatCapacity,
                VehicleTypeId= model.VehicleTypeId,
                TransmissionId= model.TransmissionId,
                CreatedOn= model.CreatedOn,
                CreatedBy= model.CreatedBy,
            };
            var newVehicle = _mapper.Map<VehicleModel>(vehicle);
            var createdVehicle = _VR.CreateVehicle(newVehicle);
            return (_mapper.Map<VehicleModelDTO>(createdVehicle));
        }

        public VehicleColorMappingDTO CreateVehicleMapping(VehicleColorMappingDTO model)
        {
            var vehicleColorMappingDTO = new VehicleColorMappingDTO()
            {
                ColorMappingId = model.ColorMappingId,
                VehicleId = model.VehicleId,
                ColorId = model.ColorId,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.CreatedBy,
            };
            var newVehicleColorMapping = _mapper.Map<VehicleColorMapping>(vehicleColorMappingDTO);
            var createdVehicleColorMap = _VR.CreateVehicleMapping(newVehicleColorMapping);
            return (_mapper.Map<VehicleColorMappingDTO>(createdVehicleColorMap));
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
            return (_mapper.Map<VehicleModelDTO>(updateVehicle));

        }

        public VehicleColorMappingDTO UpdateVehicleColorMapping(VehicleColorMappingDTO model, int id)
        {

            var vehicleColorMappingDTO = new VehicleColorMappingDTO()
            {
                ColorMappingId = model.ColorMappingId,
                VehicleId = model.VehicleId,
                ColorId = model.ColorId,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.CreatedBy,
            };
            var mapperVehicle = (_mapper.Map<VehicleColorMapping>(vehicleColorMappingDTO));
            var updateVehicleColorMap = _VR.UpdateVehicleColorMapping(mapperVehicle,id);
            return (_mapper.Map<VehicleColorMappingDTO>(updateVehicleColorMap));
        }
    }
}
