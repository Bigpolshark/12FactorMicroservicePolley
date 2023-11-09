using TwelveFactorMicroservicePolley.Models;

namespace TwelveFactorMicroservicePolley.BusinessLogic
{
    public interface IBusinessLogic12Factor
    {
        public void SaveRouteBL(RouteDataObject routeData);
        public RouteDataObject GetRouteDataBL(string StartLocation, string EndLocation);
        public RouteDataObject CallRouteAPI(string StartLocation, string EndLocation);
    }
}
