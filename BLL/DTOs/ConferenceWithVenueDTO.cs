using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ConferenceWithVenueDTO:ConferenceDTO
    {
        //public VenueDTO Venue{ get; set; }
        public string VenueName { get; set; }

    }
}
