using System;
using System.Collections.Generic;

namespace CarWebApplicationFinal
{
    public partial class Brand
    {
        public int BrId { get; set; }
        public string? BrName { get; set; }
        public string? BrModels { get; set; }
        public string? BrCountry { get; set; }

        public virtual Car? Car { get; set; }
    }
}
