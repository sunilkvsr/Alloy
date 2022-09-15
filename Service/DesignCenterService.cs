using Alloy.DataAccessLayer;
using Alloy.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alloy.Service
{
    public class DesignCenterService : IDesignCenterService
    {
        private DreesDbContext _context;
        public DesignCenterService(DreesDbContext context)
        {
            _context = context;
        }

        public void DeleteDesignCenter(int Id)
        {
            var designCenter = _context.DSC_DESIGN_CENTER.ToList().Where(x => x.DSC_ID == Id).FirstOrDefault();
            if (designCenter != null)
            {
                designCenter.DSC_ACTIVE = false;
                _context.SaveChanges();
            }
        }

        public List<LocationModel> GetAllDesignCenter()
        {
            List<LocationModel> locationModels = new List<LocationModel>();
            try
            {
                var designCenters = _context.DSC_DESIGN_CENTER.ToList().Where(x => x.DSC_ACTIVE == true).OrderBy(x => x.DSC_ID).ToList();
                foreach (var designCenter in designCenters)
                {
                    LocationModel locationModel = new LocationModel
                    {
                        Id=designCenter.DSC_ID,
                        DivisionId=designCenter.AR_ID,
                        Heading=designCenter.DSC_HEADLINE,
                        Description=designCenter.DSC_DESC,
                        Address_1=designCenter.DSC_ADDRESS1,
                        Address_2=designCenter.DSC_ADDRESS2,
                        City=designCenter.DSC_CITY,
                        State=designCenter.DSC_STATE,
                        ZIP=designCenter.DSC_ZIP,
                        PhoneNumber=designCenter.DSC_PHONE,
                        Longitude = Convert.ToString(designCenter.DSC_LNG),
                        Latitude=Convert.ToString(designCenter.DSC_LAT),
                        Direction_1_Label=designCenter.DSC_DIRECTIONS1_LBL,
                        Direction_1_Detail=designCenter.DSC_DIRECTIONS1,
                        Direction_2_Label=designCenter.DSC_DIRECTIONS2_LBL,
                        Direction_2_Detail=designCenter.DSC_DIRECTIONS2,
                        Direction_3_Label=designCenter.DSC_DIRECTIONS3_LBL,
                        Direction_3_Detail=designCenter.DSC_DIRECTIONS3,
                        Hours_1_Label=designCenter.DSC_HOURS1_LBL,
                        Hours_1_Detail=designCenter.DSC_HOURS1,
                        Hours_2_Label=  designCenter.DSC_HOURS2_LBL,
                        Hours_2_Detail=designCenter.DSC_HOURS2,
                        Active = designCenter.DSC_ACTIVE
                    };
                    locationModels.Add(locationModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return locationModels; 
        }

        public List<DivisionModel> GetAllDivision()
        {
            List<DivisionModel> divisionModels = new List<DivisionModel>();
            try
            {
                var divisions = _context.AR_AREA.ToList().OrderBy(x => x.AR_FULL_NAME).ToList();
                foreach (var division in divisions)
                {
                    divisionModels.Add(new DivisionModel
                    {
                        AR_ID = division.AR_ID,
                        AR_CODE = division.AR_CODE,
                        AR_FULL_NAME = division.AR_FULL_NAME,
                        AR_STATE1 = division.AR_STATE1,
                        AR_STATE2 = division.AR_STATE2,
                        AR_STATE3 = division.AR_STATE3,
                        AR_STATE4 = division.AR_STATE4,
                        AR_OLOC_ID = division.AR_OLOC_ID,
                        AR_LEAD_TO = division.AR_LEAD_TO,
                        AR_LEAD_CC = division.AR_LEAD_CC,
                        AR_GMAP_CLAT = division.AR_GMAP_CLAT,
                        AR_GMAP_CLNG = division.AR_GMAP_CLNG,
                        AR_GMAP_ZOOM = division.AR_GMAP_ZOOM,
                        AR_DIR_NAME = division.AR_DIR_NAME,
                        AR_MOVE_IN_PAD_DAYS = division.AR_MOVE_IN_PAD_DAYS,
                        AR_EN_CD = division.AR_EN_CD,
                        AR_EN_NM = division.AR_EN_NM
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return divisionModels;
        }

        public LocationModel GetDesignCenterById(int Id)
        {
            try
            {
                var designCenter = _context.DSC_DESIGN_CENTER.ToList().Where(x => x.DSC_ID == Id).FirstOrDefault();

                LocationModel locationModel = new LocationModel
                {
                    Id = designCenter.DSC_ID,
                    DivisionId = designCenter.AR_ID,
                    Heading = designCenter.DSC_HEADLINE,
                    Description = designCenter.DSC_DESC,
                    Address_1 = designCenter.DSC_ADDRESS1,
                    Address_2 = designCenter.DSC_ADDRESS2,
                    City = designCenter.DSC_CITY,
                    State = designCenter.DSC_STATE,
                    ZIP = designCenter.DSC_ZIP,
                    PhoneNumber = designCenter.DSC_PHONE,
                    Longitude = Convert.ToString(designCenter.DSC_LNG),
                    Latitude = Convert.ToString(designCenter.DSC_LAT),
                    Direction_1_Label = designCenter.DSC_DIRECTIONS1_LBL,
                    Direction_1_Detail = designCenter.DSC_DIRECTIONS1,
                    Direction_2_Label = designCenter.DSC_DIRECTIONS2_LBL,
                    Direction_2_Detail = designCenter.DSC_DIRECTIONS2,
                    Direction_3_Label = designCenter.DSC_DIRECTIONS3_LBL,
                    Direction_3_Detail = designCenter.DSC_DIRECTIONS3,
                    Hours_1_Label = designCenter.DSC_HOURS1_LBL,
                    Hours_1_Detail = designCenter.DSC_HOURS1,
                    Hours_2_Label = designCenter.DSC_HOURS2_LBL,
                    Hours_2_Detail = designCenter.DSC_HOURS2,
                    Active = designCenter.DSC_ACTIVE,
                    Image = designCenter.DSC_IMAGE
                };
                return locationModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveImage(int DesignCenterId, byte[] Image)
        {
            var designCenter = _context.DSC_DESIGN_CENTER.ToList().Where(x => x.DSC_ID == DesignCenterId).FirstOrDefault();
            if (designCenter != null)
            {
                designCenter.DSC_IMAGE = Image;
                _context.SaveChanges();
            }
        }

        public int SAVE_DSC_DESIGN_CENTER(LocationModel locationModel)
        {
            if (locationModel.Id == 0)
            {
                DSC_DESIGN_CENTER DSC_DESIGN_CENTER = new DSC_DESIGN_CENTER
                {
                    AR_ID = locationModel.DivisionId,
                    DSC_HEADLINE = locationModel.Heading,
                    DSC_DESC = locationModel.Description,
                    DSC_ADDRESS1 = locationModel.Address_1,
                    DSC_ADDRESS2 = locationModel.Address_2,
                    DSC_CITY = locationModel.City,
                    DSC_STATE = locationModel.State,
                    DSC_ZIP = locationModel.ZIP,
                    DSC_PHONE = locationModel.PhoneNumber,
                    DSC_LNG = !string.IsNullOrEmpty(locationModel.Longitude) ? Convert.ToDecimal(locationModel.Longitude) : null,
                    DSC_LAT = !string.IsNullOrEmpty(locationModel.Latitude) ? Convert.ToDecimal(locationModel.Latitude) : null,
                    DSC_DIRECTIONS1_LBL = locationModel.Direction_1_Label,
                    DSC_DIRECTIONS1 = locationModel.Direction_1_Detail,
                    DSC_DIRECTIONS2_LBL = locationModel.Direction_2_Label,
                    DSC_DIRECTIONS2 = locationModel.Direction_2_Detail,
                    DSC_DIRECTIONS3_LBL = locationModel.Direction_3_Label,
                    DSC_DIRECTIONS3 = locationModel.Direction_3_Detail,
                    DSC_HOURS1_LBL = locationModel.Hours_1_Label,
                    DSC_HOURS1 = locationModel.Hours_2_Detail,
                    DSC_HOURS2_LBL = locationModel.Hours_2_Label,
                    DSC_HOURS2 = locationModel.Hours_2_Detail,
                    DSC_ACTIVE = locationModel.Active,
                };
                _context.Add(DSC_DESIGN_CENTER);
                _context.SaveChanges();

                return DSC_DESIGN_CENTER.DSC_ID;
            }
            else
            {
                var designCenter = _context.DSC_DESIGN_CENTER.ToList().Where(x => x.DSC_ID == locationModel.Id).FirstOrDefault();
                if (designCenter != null)
                {
                    designCenter.AR_ID = locationModel.DivisionId;
                    designCenter.DSC_HEADLINE = locationModel.Heading;
                    designCenter.DSC_DESC = locationModel.Description;
                    designCenter.DSC_ADDRESS1 = locationModel.Address_1;
                    designCenter.DSC_ADDRESS2 = locationModel.Address_2;
                    designCenter.DSC_CITY = locationModel.City;
                    designCenter.DSC_STATE = locationModel.State;
                    designCenter.DSC_ZIP = locationModel.ZIP;
                    designCenter.DSC_PHONE = locationModel.PhoneNumber;
                    designCenter.DSC_LNG = !string.IsNullOrEmpty(locationModel.Longitude) ? Convert.ToDecimal(locationModel.Longitude) : null;
                    designCenter.DSC_LAT = !string.IsNullOrEmpty(locationModel.Latitude) ? Convert.ToDecimal(locationModel.Latitude) : null;
                    designCenter.DSC_DIRECTIONS1_LBL = locationModel.Direction_1_Label;
                    designCenter.DSC_DIRECTIONS1 = locationModel.Direction_1_Detail;
                    designCenter.DSC_DIRECTIONS2_LBL = locationModel.Direction_2_Label;
                    designCenter.DSC_DIRECTIONS2 = locationModel.Direction_2_Detail;
                    designCenter.DSC_DIRECTIONS3_LBL = locationModel.Direction_3_Label;
                    designCenter.DSC_DIRECTIONS3 = locationModel.Direction_3_Detail;
                    designCenter.DSC_HOURS1_LBL = locationModel.Hours_1_Label;
                    designCenter.DSC_HOURS1 = locationModel.Hours_2_Detail;
                    designCenter.DSC_HOURS2_LBL = locationModel.Hours_2_Label;
                    designCenter.DSC_HOURS2 = locationModel.Hours_2_Detail;
                    designCenter.DSC_ACTIVE = locationModel.Active;
                    _context.SaveChanges();
                }
                return locationModel.Id;
            }
        }

    }
}
