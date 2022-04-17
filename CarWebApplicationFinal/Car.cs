using System;
using System.Collections.Generic;

namespace CarWebApplicationFinal
{
    public partial class Car
    {
        public int CrId { get; set; }
        public string? CrBrand { get; set; }
        public string? CrModel { get; set; }
        public string CrManufacturerCountry { get; set; } = null!;
        public int? CrPrice { get; set; }
        public int? CrYearOfIssue { get; set; }
        public string? CrAutoShowroom { get; set; }

        public virtual Brand Cr { get; set; } = null!;
    }
}
