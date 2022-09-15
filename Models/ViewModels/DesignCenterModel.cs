using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Alloy.Models.ViewModels
{
    public class DesignCenterModel
    {
        public List<LocationModel> locationModels { get; set; }

        public List<SelectListItem> Divisions { get; set; }
    }
}
