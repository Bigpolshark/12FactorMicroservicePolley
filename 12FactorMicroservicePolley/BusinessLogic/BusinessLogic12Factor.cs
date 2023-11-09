using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Drawing;
using TwelveFactorMicroservicePolley.Data;
using TwelveFactorMicroservicePolley.Models;

namespace TwelveFactorMicroservicePolley.BusinessLogic
{
    public class BusinessLogic12Factor : IBusinessLogic12Factor
    {
        private readonly IRepository repo;
        private readonly ILogger<BusinessLogic12Factor> _logger;

        public BusinessLogic12Factor(IRepository repo, ILogger<BusinessLogic12Factor> logger)
        {
            this.repo = repo;
            _logger = logger;
        }


        public RouteDataObject GetRouteDataBL(string StartLocation, string EndLocation)
        {
            try
            {
                var result = repo.GetRouteDataDAL(StartLocation, EndLocation);

                if(result == null)
                {
                    _logger.LogInformation($"{nameof(GetRouteDataBL)}: Route not existing. Sending API Request for new route data.");

                    result = CallRouteAPI(StartLocation, EndLocation);

                    _logger.LogInformation($"{nameof(GetRouteDataBL)}: Saving API result to Database.");
                    SaveRouteBL(result);
                }

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError($"{nameof(GetRouteDataBL)}: " + ex.Message);
                throw new Exception("Error", ex);
            }
            
        }

        public void SaveRouteBL(RouteDataObject routeData)
        {
            try
            {
                repo.SaveRouteDAL(routeData);

            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(SaveRouteBL)}: " + ex.Message);
                throw new Exception("Error", ex);
            }
        }

        public RouteDataObject CallRouteAPI(string StartLocation, string EndLocation)
        {
            try
            {
                var returnStringTask = GetContent(StartLocation,EndLocation);
                Task.WaitAll(returnStringTask);

                return new RouteDataObject(StartLocation, EndLocation, returnStringTask.Result);
            }
            catch (Exception ex)
            {

                _logger.LogError($"{nameof(CallRouteAPI)}: " + ex.Message);
                throw new Exception("Error", ex);
            }

        }

        public async Task<string> GetContent(string StartLocation, string EndLocation)
        {
            //DirectionsAPI
            using var client = new HttpClient();

            string key = Environment.GetEnvironmentVariable("MapQuestAPIKey");

            //can be potentially also changed via environment variables, but not implemented
            string routeType = "pedestrian";


            string directionURL = "http://www.mapquestapi.com/directions/v2/route?key=" + key + "&from=" + StartLocation + "&to=" + EndLocation + "&routeType=" + routeType;

            var response = await client.GetAsync(directionURL).ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync();

        }
    }
}
