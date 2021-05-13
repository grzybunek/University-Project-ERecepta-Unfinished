using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Web.Application.Dtos
{
    using MedicalAppointments.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PlaceDto
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Town { get; set; }
    }
}
