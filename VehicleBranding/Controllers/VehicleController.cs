using BusinessLL.BusinessLogic;
using BusinessLL.DTOS;
using DomainLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VehicleBranding.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _VS;
        public VehicleController(IVehicleService vs) 
        {
            _VS= vs;
        }
        [HttpGet]
        [Route("GetDeatilsOfVehicles")]
        public ActionResult<List<VehicleDetailsDTO>> GetDeatilsOfVehicles()
        {
            //calling Ivehicle service interface
            var list = _VS.GetVehicleDetails();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetDeatilsOfVehiclesByChassisNum")]
        public ActionResult<List<VehicleDetailsDTO>> GetDeatilsOfVehiclesByChassisNum(string chassisNum)
        {
            var list = _VS.GetVehicleDetailsByChassisNumber(chassisNum);
            return Ok(list);
        }
        [HttpGet]
        [Route("GetDeatilsOfVehiclesById")]
        public ActionResult<List<VehicleDetailsDTO>> GetDeatilsOfVehiclesById(int Id)
        {
            var list = _VS.GetVehicleDetailsById(Id);
            return Ok(list);
        }
        [HttpPost]
        [Route("PostVehicleModel")]
        public ActionResult<VehicleModelDTO> PostVehicleModel(VehicleModelDTO modelDTO)
        {
            var postVehicle = _VS.CreateVehicle(modelDTO);
            return Ok(postVehicle);
        }
        [HttpPut]
        [Route("PutVehicle/{id:int}")]
        public ActionResult<VehicleModelDTO> PutVehicle(VehicleModelDTO modelDTO,int id)
        {
            var putVehicle = _VS.UpdateVehicle(modelDTO,id);
            return Ok(putVehicle);
        }
        [HttpPost]
        [Route("PostVehicleColorMapping")]
        public ActionResult<VehicleColorMappingDTO> PostVehicleColorMapping(VehicleColorMappingDTO modelDTO)
        {
            var postVehicle = _VS.CreateVehicleMapping(modelDTO);
            return Ok(postVehicle);
        }
        [HttpPut]
        [Route("PutVehicleColorMapping/{id:int}")]
        public ActionResult<VehicleColorMappingDTO> PutVehicleColorMapping(VehicleColorMappingDTO modelDTO, int id)
        {
            var putVehicle = _VS.UpdateVehicleColorMapping(modelDTO, id);
            return Ok(putVehicle);
        }
        [HttpDelete]
        [Route("DeleteVehicle/{id:int}")]
        public ActionResult<string> DeleteVehicle(int id)
        {
            var deleteVehicle = _VS.DeleteVehicleDetails(id);
            return Ok(deleteVehicle);
        }
    }
}
