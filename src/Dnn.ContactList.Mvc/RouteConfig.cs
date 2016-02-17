using DotNetNuke.Web.Mvc.Routing;

namespace Dnn.ContactList.Mvc
{
    public class RouteConfig : IMvcRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapRoute("ContactList", "ContactList", "{controller}/{action}", new[]
            {"Dnn.ContactList.Mvc.Controllers"});
        }
    }
}
