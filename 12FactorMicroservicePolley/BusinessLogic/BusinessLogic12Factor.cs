using TwelveFactorMicroservicePolley.Data;
using TwelveFactorMicroservicePolley.Models;

namespace TwelveFactorMicroservicePolley.BusinessLogic
{
    public class BusinessLogic12Factor : IBusinessLogic12Factor
    {
        private readonly IRepository repo;
        //private readonly ILogger<> _logger;

        public BusinessLogic12Factor(IRepository repo)
        {
            this.repo = repo;
        }

        public RouteDataObject CallRouteAPI(string StartLocation, string EndLocation)
        {
            return new RouteDataObject("test1API", "test1", "test1");
        }

        public RouteDataObject GetRouteDataBL(string StartLocation, string EndLocation)
        {
            var result = repo.GetRouteDataDAL(StartLocation, EndLocation);

            if(result == null)
            {
                result = CallRouteAPI(StartLocation, EndLocation);
                SaveRouteBL(result);
            }

            return result;
            
        }

        public void SaveRouteBL(RouteDataObject routeData)
        {
            repo.SaveRouteDAL(routeData);
        }
    }
}
