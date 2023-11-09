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
            try
            {
                var result = repo.GetRouteDataDAL(StartLocation, EndLocation);
                //RouteDataObject result = null;

                if(result == null)
                {
                    result = CallRouteAPI(StartLocation, EndLocation);
                    SaveRouteBL(result);
                }

                return result;
            }
            catch(Exception ex)
            {
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
                throw new Exception("Error", ex);
            }
        }
    }
}
