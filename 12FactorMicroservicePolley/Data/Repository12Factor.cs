using TwelveFactorMicroservicePolley.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TwelveFactorMicroservicePolley.Controllers;
using TwelveFactorMicroservicePolley.BusinessLogic;

namespace TwelveFactorMicroservicePolley.Data
{
    public class Repository12Factor : IRepository
    {

        private readonly DbContext12Factor context;
        private readonly ILogger<Repository12Factor> _logger;

        public Repository12Factor(DbContext12Factor context, ILogger<Repository12Factor> logger)
        {
            this.context = context;
            _logger = logger;
        }

        public RouteDataObject GetRouteDataDAL(string StartLocation, string EndLocation)
        {
            try
            {
                context.Database.EnsureCreated();

                var result = context.RouteDataDB
                    .Where(item => item.StartLocation == StartLocation)
                    .Where(item => item.EndLocation == EndLocation)
                    .FirstOrDefault();

                return result;
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"{nameof(GetRouteDataDAL)}: " + ex.Message);
                throw new Exception("Error", ex);
            }
        }

        public void SaveRouteDAL(RouteDataObject routeData)
        {
            try
            {
                context.Database.EnsureCreated();
                context.Add(routeData);
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"{nameof(SaveRouteDAL)}: " + ex.Message);
                throw new Exception("Error", ex);
            }
        }
    }
}
