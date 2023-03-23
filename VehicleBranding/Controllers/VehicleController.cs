using BusinessLL.BusinessLogic;
using BusinessLL.DTOS;
using DomainLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace VehicleBranding.Controllers
{
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _VS;
        public VehicleController(IVehicleService vs) 
        {
            _VS= vs;
        }

        [HttpPost]
        [Route("PostVehicleModel")]
        public ActionResult<VehicleModelDTO> PostVehicleModel(VehicleModelDTO modelDTO)
        {
            var postVehicle = _VS.CreateVehicle(modelDTO);
            return Ok(postVehicle);
        }
        [HttpPut]
        [Route("PutVehicle")]
        public ActionResult<VehicleModelDTO> PutVehicle(VehicleModelDTO modelDTO,int id)
        {
            var putVehicle = _VS.UpdateVehicle(modelDTO,id);
            return Ok(putVehicle);
        }
    }
}
