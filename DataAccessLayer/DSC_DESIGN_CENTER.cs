using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alloy.DataAccessLayer
{
    public class DSC_DESIGN_CENTER
    {
        [Required]
        [Key]
        public int DSC_ID { get; set; }

        [Required]
        [ForeignKey("AR_AREA")]
        public int AR_ID { get; set; }

        public string DSC_ADDRESS1 { get; set; }

        public string DSC_ADDRESS2 { get; set; }

        public string DSC_CITY { get; set; }

        public string DSC_STATE { get; set; }

        public string DSC_ZIP { get; set; }

        public string DSC_PHONE { get; set; }

        public string DSC_DIRECTIONS1_LBL { get; set; }

        public string DSC_DIRECTIONS1 { get; set; }

        public string DSC_DIRECTIONS2_LBL { get; set; }

        public string DSC_DIRECTIONS2 { get; set; }

        public string DSC_DIRECTIONS3_LBL { get; set; }

        public string DSC_DIRECTIONS3 { get; set; }

        public string DSC_HOURS1_LBL { get; set; }

        public string DSC_HOURS1 { get; set; }
        public string DSC_HOURS2_LBL { get; set; }

        public string DSC_HOURS2 { get; set; }

        public decimal? DSC_LAT { get; set; }

        public decimal? DSC_LNG { get; set; }

        public bool DSC_ACTIVE { get; set; }

        public string DSC_HEADLINE { get; set; }

        public string DSC_DESC { get; set; }

        public string DSC_FILENAME { get; set; }

        [MaxLength]
        public byte[] DSC_IMAGE { get; set; }
    }
}
