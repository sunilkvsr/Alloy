using System.Collections.Generic;

namespace Alloy.Models.ViewModels
{
    public class LocationModel
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }

        public string Address_1 { get; set; }

        public string Address_2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZIP { get; set; }

        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Direction_1_Label { get; set; }

        public string Direction_1_Detail { get; set; }

        public string Direction_2_Label { get; set; }

        public string Direction_2_Detail { get; set; }

        public string Direction_3_Label { get; set; }

        public string Direction_3_Detail { get; set; }

        public string Hours_1_Label { get; set; }

        public string Hours_1_Detail { get; set; }

        public string Hours_2_Label { get; set; }

        public string Hours_2_Detail { get; set; }

        public bool Active { get; set; }

        public byte[]? Image { get; set; }
    }
}
