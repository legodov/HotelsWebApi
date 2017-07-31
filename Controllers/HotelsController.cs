using System;
using Microsoft.AspNetCore.Mvc;
using HotelsWebApi.db;
using HotelsWebApi.Services;
using HotelsWebApi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace HotelsWebApi.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private IHotelsService _hotelsService;
        private ILogger _logger;

        public HotelsController(IHotelsService hotelsService, ILogger<HotelsController> logger)
        {
            _hotelsService = hotelsService;
            _logger = logger;
        }

        // GET: /api/Hotels/GetHotelList
        [HttpGet]
        [Route("GetHotelList")]
        public IActionResult GetHotelList()
        {
            try
            {
                _logger.LogInformation("Getting hotel list from database");
                var cityList = _hotelsService.GetHotelList();
                return Json(JsonConvert.SerializeObject(cityList));           
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Hotel list not found");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: /api/Hotels/AddHotel
        [HttpPost]
        [Route("AddHotel")]
        public IActionResult AddCity([FromBody]string name, [FromBody]string location, [FromBody]int stars)
        {
            if (name == null || name == "" || location == null || location == "")
            {
                _logger.LogWarning("New hotel not added. Bad parameters");
                return BadRequest();
            }
            try
            {
                _logger.LogInformation("Adding new hotel to database");
                _hotelsService.AddHotel(new Hotel { Name = name, Location = location, Stars = stars });
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("New hotel not added. Internal server error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Hotels/DeleteHotel/id
        [HttpDelete]
        [Route("DeleteHotel")]
        public IActionResult DeleteHotel([FromBody]int id)
        {
            try
            {
                _logger.LogInformation("Deleting hotel from database");
                _hotelsService.DeleteHotel(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Hotel not deleted. Internal server error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Hotels/DeleteHotelWithName/name
        [HttpDelete]
        [Route("DeleteHotelWithName")]
        public IActionResult DeleteHotelWithName([FromBody]string name)
        {
            try
            {
                _hotelsService.DeleteHotelWithName(name);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
