using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using TruckDriverInfo.Services;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TruckDriverInfo.Controllers
{
    [ApiController]
    [Route("api/v1/truck/[action]")]
    public class TruckController : ControllerBase
    {
        private readonly ILogger<TruckController> _logger;
        private readonly IDriversInfoService _service;

        public TruckController(ILogger<TruckController> logger, IDriversInfoService service)
        {
            _logger = logger;
            _service = service;

        }

        /// <summary>
        /// Return Drivers Name Located in specific Location.
        /// </summary>
        /// <param name="location">Location where you need a Truck Driver</param>
        /// <returns>List of Truck Drivers</returns>
        /// <response code="400">If the item not found</response>
        [HttpGet]
        [ActionName("drivers")]
        [Produces("application/json")]
        [Route("{location}")]
        public IActionResult GetDriversNameByLocation(String location)
        {
            try
            {
                var driversByLocation = _service.GetDriversByLocation(location.Trim());
                if (driversByLocation.Count != 0)
                {
                    return Ok(driversByLocation);
                }
                _logger.LogInformation("Controller : Data Not Found for {Location}", location);
                return NotFound("Not found any record for {Location} "+ location);
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured in Truck contoller GetDriversNameByLocation for " + location + "exception: " + ex.InnerException);
                return Problem("Exception occured in Truck contoller GetDriversNameByLocation for " + location + "exception: " + ex.InnerException,
                    null, 500, "Server Error", null); 
            }
        }
    }
}