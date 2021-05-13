namespace MedicalAppointments.Web.Application.Dtos
{
    using MedicalAppointments.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppointmentDto
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime StartDateOfTheVisit { get; set; }
        public DateTime EndDateOfTheVisit { get; set; }
        public PlaceDto Place { get; set; }
      
    }
}
