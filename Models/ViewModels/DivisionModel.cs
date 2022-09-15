namespace Alloy.Models.ViewModels
{
    public class DivisionModel
    {
        public int AR_ID { get; set; }
        public string AR_CODE { get; set; }
        public string AR_FULL_NAME { get; set; }
        public string AR_STATE1 { get; set; }
        public string AR_STATE2 { get; set; }
        public string AR_STATE3 { get; set; }
        public string AR_STATE4 { get; set; }
        public int? AR_OLOC_ID { get; set; }
        public string AR_LEAD_TO { get; set; }
        public string AR_LEAD_CC { get; set; }
        public decimal? AR_GMAP_CLAT { get; set; }
        public decimal? AR_GMAP_CLNG { get; set; }
        public int? AR_GMAP_ZOOM { get; set; }
        public string AR_DIR_NAME { get; set; }
        public int? AR_MOVE_IN_PAD_DAYS { get; set; }
        public string AR_EN_CD { get; set; }
        public string AR_EN_NM { get; set; }
    }
}
