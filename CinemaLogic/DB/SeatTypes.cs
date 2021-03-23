using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaLogic.DB
{
    public partial class SeatTypes
    {
        public int SeatTypeId { get; set; }
        public string Naming { get; set; }
        public decimal Price { get; set; }
    }
}
