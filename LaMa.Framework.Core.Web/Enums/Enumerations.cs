using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaMa.Framework.Core.Web.Enums
{
    public enum MatchesRoutingPart
    {
        /// <summary>
        /// matches area, controller and action
        /// </summary>
        All,  
        /// <summary>
        ///matches only area and controller
        /// </summary>
        AreaAndController, 
        /// <summary>
        ///matches only controller, does not check area
        /// </summary>
        OnlyController,
        /// <summary>
        /// only matches with the area 
        /// </summary>
        OnlyArea, 
    }
}