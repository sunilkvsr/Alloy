using Alloy.Models.ViewModels;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Alloy.Models.Pages
{
    [SiteContentType(DisplayName = "Admin Page", GUID = "cfbef347-985e-459d-8b1f-d49d954c0325", Description = "")]
    public class AdminPage : PageData
    {
        public AdminPage()
        {
            designCenterModel = new DesignCenterModel();
        }

        [Ignore]
        public DesignCenterModel designCenterModel { get; set; }

        //[Display(
        // Name = "Left Header",
        // GroupName = SystemTabNames.Content,
        // Order = 100)]
        //[CultureSpecific]
        //public virtual ContentArea LeftSideContentArea { get; set; }

        [Display(
         Name = "Content Area",
         GroupName = SystemTabNames.Content,
         Order = 100)]
        [CultureSpecific]
        public virtual ContentArea ContentArea { get; set; }

        //[Display(
        // Name = "Top Header",
        // GroupName = SystemTabNames.Content,
        // Order = 300)]
        //[CultureSpecific]
        //public virtual ContentArea TopContentArea { get; set; }
    }
}
