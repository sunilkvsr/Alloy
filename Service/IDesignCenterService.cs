using Alloy.Models.ViewModels;
using System.Collections.Generic;

namespace Alloy.Service
{
    public interface IDesignCenterService
    {
        List<DivisionModel> GetAllDivision();

        int SAVE_DSC_DESIGN_CENTER(LocationModel locationModel);

        List<LocationModel> GetAllDesignCenter();

        LocationModel GetDesignCenterById(int Id);

        void DeleteDesignCenter(int Id);

        void SaveImage(int DesignCenterId, byte[] Image);
    }
}
