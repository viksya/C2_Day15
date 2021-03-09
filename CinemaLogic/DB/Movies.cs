using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaLogic.DB
{
    public partial class Movies
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AvailableTime { get; set; }
    }
}
