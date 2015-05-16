using System;
using LaMa.Framework.Core.Web.Enums;

namespace LaMa.Framework.Core.Web.ValueObjects
{
    internal interface IRouteInfo 
    {
        string Action { get; set; }
        string Controller { get; set; }
        string Area { get; set; }
    }

    internal class RouteInfo
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }

        public bool IsEqualTo(RouteInfo routeInfo, MatchesRoutingPart matchesRoutingPart)
        {
            switch (matchesRoutingPart)
            {
                case MatchesRoutingPart.OnlyController:
                    return Controller.Equals(routeInfo.Controller);
                case MatchesRoutingPart.OnlyArea:
                    return Area.Equals(routeInfo.Area);
                case MatchesRoutingPart.AreaAndController:
                    return Area.Equals(routeInfo.Area) && Controller.Equals(routeInfo.Controller);
                case MatchesRoutingPart.All:
                    return Area.Equals(routeInfo.Area) && Controller.Equals(routeInfo.Controller) &&
                           Action.Equals(routeInfo.Action);
                default:
                    throw new NotImplementedException(string.Format("The matching route part {0} is not supported",
                        matchesRoutingPart));
            }
        }
    }
}