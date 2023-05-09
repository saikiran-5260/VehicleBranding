using BusinessLL.BusinessLogic;
using BusinessLL.DTOS;
using DomainLL.Models;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize]
        public ActionResult<List<VehicleDetailsDTO>> GetDeatilsOfVehicles()
        {
            //calling Ivehicle service interface
            var list = _VS.GetVehicleDetails();
            return Ok(list);
        }
        [Authorize]
        [HttpGet]
        [Route("GetDeatilsOfVehiclesByChassisNum")]
        public ActionResult<List<VehicleDetailsDTO>> GetDeatilsOfVehiclesByChassisNum(string chassisNum)
        {
            var list = _VS.GetVehicleDetailsByChassisNumber(chassisNum);
            return Ok(list);
        }
        [Authorize]
        [HttpGet]
        [Route("GetDeatilsOfVehiclesById")]
        public ActionResult<List<VehicleDetailsDTO>> GetDeatilsOfVehiclesById(int Id)
        {
            var list = _VS.GetVehicleDetailsById(Id);
            return Ok(list);
        }
        [Authorize]
        [HttpPost]
        [Route("PostVehicleModel")]
        public ActionResult<VehicleModelDTO> PostVehicleModel(VehicleModelDTO modelDTO)
        {
            var postVehicle = _VS.CreateVehicle(modelDTO);
            return Ok(postVehicle);
        }
        [Authorize]
        [HttpPut]
        [Route("PutVehicle/{id:int}")]
        public ActionResult<VehicleModelDTO> PutVehicle(VehicleModelDTO modelDTO,int id)
        {
            var putVehicle = _VS.UpdateVehicle(modelDTO,id);
            return Ok(putVehicle);
        }
        [Authorize]
        [HttpPost]
        [Route("PostVehicleColorMapping")]
        public ActionResult<VehicleColorMappingDTO> PostVehicleColorMapping(VehicleColorMappingDTO modelDTO)
        {
            var postVehicle = _VS.CreateVehicleMapping(modelDTO);
            return Ok(postVehicle);
        }
        [Authorize]
        [HttpPut]
        [Route("PutVehicleColorMapping/{id:int}")]
        public ActionResult<VehicleColorMappingDTO> PutVehicleColorMapping(VehicleColorMappingDTO modelDTO, int id)
        {
            var putVehicle = _VS.UpdateVehicleColorMapping(modelDTO, id);
            return Ok(putVehicle);
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteVehicle/{id:int}")]
        public ActionResult<string> DeleteVehicle(int id)
        {
            var deleteVehicle = _VS.DeleteVehicleDetails(id);
            return Ok(deleteVehicle);
        }
    }
}
