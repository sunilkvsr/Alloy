using Alloy.Models.ViewModels;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Alloy.Models.Pages
{
    [SiteContentType(DisplayName = "Design Center", GUID = "f85d431c-9742-4381-8e8a-8ec4fd0acc8f", Description = "Design Center Management")]
    public class DesignCenterPage: PageData
    {
        [Display(
         Name = "Content Area",
         GroupName = SystemTabNames.Content,
         Order = 100)]
        [CultureSpecific]
        public virtual ContentArea ContentArea { get; set; }
    }
}
