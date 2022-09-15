using Alloy.DataAccessLayer;
using Alloy.Models.Pages;
using Alloy.Models.ViewModels;
using Alloy.Service;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Alloy.Controllers
{
    public class AdminPageController : PageController<AdminPage>
    {
        private IDesignCenterService _designCenterService;
        private IHostingEnvironment Environment;
        public AdminPageController(IDesignCenterService designCenterService, IHostingEnvironment _environment)
        {
            _designCenterService = designCenterService;
            Environment = _environment;
        }

        public ActionResult Index(AdminPage currentPage)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetVirtualPath(currentPage.ContentLink);
            ViewBag.BaseUrl = pageUrl.VirtualPath;

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
            currentPage.designCenterModel.Divisions = divisionItem;
            currentPage.designCenterModel.locationModels = designCenters;
            return View(currentPage);
        }

        [HttpPost]
        public PartialViewResult RenderLocation(int locationId)
        {
            LocationModel locationModel = new LocationModel();
            if (locationId == 0)
            {
                locationModel = new LocationModel();
            }
            else
            {
                locationModel = _designCenterService.GetDesignCenterById(locationId);
            }
            ViewBag.DesignCenterId = locationId;
            return PartialView("_Location", locationModel);
        }

        [HttpPost]
        public JsonResult DeleteLocation(int designCenterId)
        {
            try
            {
                if (designCenterId > 0)
                {
                    _designCenterService.DeleteDesignCenter(designCenterId);
                }
                return Json(new { result = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "Error", ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SaveLocation([FromBody] LocationModel model)
        {
            try
            {
                TempData["DesignCenterId"] = "";
                int DesignCenterId = _designCenterService.SAVE_DSC_DESIGN_CENTER(model);
                TempData["DesignCenterId"] = DesignCenterId.ToString();
                return Json(new { result = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "Error", ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult StoreImage()
        {
            try
            {
                var image = HttpContext.Request.Form.Files["file"];
                if (image.ContentType.Length > 0)
                {
                    //string wwwPath = this.Environment.WebRootPath;
                    //string contentPath = this.Environment.ContentRootPath;

                    //string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    //if (!Directory.Exists(path))
                    //{
                    //    Directory.CreateDirectory(path);
                    //}

                    //var fileName = Path.GetFileName(image.FileName);
                    //using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    //{
                    //    image.CopyTo(stream);
                    //}

                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.CopyTo(ms);
                        byte[] byteArr = ms.ToArray();
                        string imreBase64Data = Convert.ToBase64String(byteArr);
                        string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                        TempData["imageData"] = imreBase64Data;
                    }
                }
                return Json(new { result = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "Error", ErrorMessage = ex.Message });
            }
        }
    }
}
