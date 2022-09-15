using System.ComponentModel.DataAnnotations;

namespace Alloy.DataAccessLayer
{
    public class AR_AREA
    {
        [Key]
        public int AR_ID { get; set; }

        [MaxLength(100)]
        [Required]
        public string AR_CODE { get; set; }

        [MaxLength(100)]
        [Required]
        public string AR_FULL_NAME { get; set; }

        [MaxLength(100)]
        [Required]
        public string AR_STATE1 { get; set; }

        [MaxLength(100)]
        public string AR_STATE2 { get; set; }

        [MaxLength(100)]
        public string AR_STATE3 { get; set; }

        [MaxLength(100)]
        public string AR_STATE4 { get; set; }

        public int? AR_OLOC_ID { get; set; }

        [MaxLength(100)]
        public string AR_LEAD_TO { get; set; }

        [MaxLength(100)]
        public string AR_LEAD_CC { get; set; }

        public decimal? AR_GMAP_CLAT { get; set; }

        public decimal? AR_GMAP_CLNG { get; set; }

        public int? AR_GMAP_ZOOM { get; set; }

        [MaxLength(100)]
        public string AR_DIR_NAME { get; set; }

        public int? AR_MOVE_IN_PAD_DAYS { get; set; }

        [MaxLength(100)]
        public string AR_EN_CD { get; set; }

        [MaxLength(100)]
        public string AR_EN_NM { get; set; }
    }
}
