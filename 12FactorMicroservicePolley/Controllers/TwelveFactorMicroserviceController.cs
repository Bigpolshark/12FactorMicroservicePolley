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

        public TwelveFactorMicroserviceController(IBusinessLogic12Factor logic)
        {
            _logic = logic;
        }

        [HttpGet("GetRouteData")]
        [Consumes("application/json")]
        public virtual IActionResult GetRouteData(string start, string end)
        {

            try
            {
                var returnValue = _logic.GetRouteDataBL(start,end);

                return StatusCode(200, returnValue);
            }
            catch (System.Exception ex)
            {

                return StatusCode(400, ex.InnerException + ex.StackTrace);
            }

        }
    }
}
