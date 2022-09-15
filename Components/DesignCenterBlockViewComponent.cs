using Alloy.Models.Blocks;
using Alloy.Models.ViewModels;
using Alloy.Service;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Alloy.Components
{
    public class DesignCenterBlockViewComponent : BlockComponent<DesignCenterBlock>
    {
        private IDesignCenterService _designCenterService;
        public DesignCenterBlockViewComponent(IDesignCenterService designCenterService)
        {
            _designCenterService = designCenterService;
        }

        protected override IViewComponentResult InvokeComponent(DesignCenterBlock currentContent)
        {
            var division = _designCenterService.GetAllDivision();
            var designCenters = _designCenterService.GetAllDesignCenter();

            List<SelectListItem> divisionItem = new List<SelectListItem>();
            foreach (var item in division)
            {
                divisionItem.Add(new SelectListItem
                {
                    Text = item.AR_FULL_NAME.ToString(),
                    Value = item.AR_ID.ToString()
                });
            }

            DesignCenterModel designCenterModel = new DesignCenterModel();
            designCenterModel.Divisions = divisionItem;
            designCenterModel.locationModels = designCenters;
            return View(designCenterModel);
        }
    }
}
