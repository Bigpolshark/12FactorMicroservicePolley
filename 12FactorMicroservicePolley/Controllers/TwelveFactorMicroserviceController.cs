using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TwelveFactorMicroservicePolley.Data;
using TwelveFactorMicroservicePolley.Models;
using TwelveFactorMicroservicePolley.BusinessLogic;

namespace TwelveFactorMicroservicePolley.Controllers
{
    [ApiController]
    public class TwelveFactorMicroserviceController : ControllerBase
    {
        private readonly IBusinessLogic12Factor _logic;
        private readonly ILogger<TwelveFactorMicroserviceController> _logger;

        public TwelveFactorMicroserviceController(IBusinessLogic12Factor logic, ILogger<TwelveFactorMicroserviceController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        [HttpGet("GetRouteData")]
        [Consumes("application/json")]
        public virtual IActionResult GetRouteData(string start, string end)
        {

            try
            {
                var returnValue = _logic.GetRouteDataBL(start,end);

                _logger.LogInformation($"{nameof(TwelveFactorMicroserviceController)}: Operation successfull, see return value.");
                return StatusCode(200, returnValue);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"{nameof(TwelveFactorMicroserviceController)}: " + ex.Message);
                return StatusCode(400, ex.InnerException + ex.StackTrace);
            }

        }
    }
}
