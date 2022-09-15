using Alloy.Models.ViewModels;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Alloy.Models.Blocks
{

    [ContentType(DisplayName = "Design Center", GUID = "bf290130-662d-475c-b408-f2d09a8fbbca", Description = "This module is used for manage design center detail")]
    public class DesignCenterBlock : BlockData
    {
        public DesignCenterBlock()
        {
            designCenterModel = new DesignCenterModel();
        }

        [Ignore]
        public DesignCenterModel designCenterModel { get; set; }

    }
}
