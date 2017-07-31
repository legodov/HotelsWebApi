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
    public class HotelsInfoController : Controller
    {
        private HotelsInfoService _infoService;
        private ILogger _logger;

        public HotelsInfoController(HotelsInfoService infoService, ILogger<HotelsInfoController> logger)
        {
            _infoService = infoService;
            _logger = logger;
        }

        // GET: /api/HotelsStatistics/GetHotelNameList
        [HttpGet]
        [Route("GetHotelNameList")]
        public IActionResult GetHotelNameList()
        {
            try
            {
                _logger.LogInformation("Getting hotel name list from database");
                var cityList = _infoService.GetHotelNameList();
                return Json(JsonConvert.SerializeObject(cityList));           
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Hotel name list not found");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
