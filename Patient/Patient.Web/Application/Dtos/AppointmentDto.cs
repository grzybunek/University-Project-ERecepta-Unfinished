namespace Patient.Web.Application.Dtos
    {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppointmentDto
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime StartDateOfTheVisit { get; set; }
        public DateTime EndDateOfTheVisit { get; set; }
        public PlaceDto Place { get; set; }
    }
}
