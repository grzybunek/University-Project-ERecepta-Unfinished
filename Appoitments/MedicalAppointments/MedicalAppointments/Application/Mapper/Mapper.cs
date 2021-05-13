namespace MedicalAppointments.Web.Application.Mapper
{
    using MedicalAppointments.Domain;
    using MedicalAppointments.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Mapper
    {
        public static AppointmentDto Map(this Appointment appointment)
        {
            if (appointment == null)
                return null;

            return new AppointmentDto
            {   
                Id = appointment.Id,
                IdDoctor = appointment.IdDoctor,
                IdPatient = appointment.IdPatient,
                StartDateOfTheVisit = appointment.StartDateOfTheVisit,
                EndDateOfTheVisit = appointment.EndDateOfTheVisit,
                Place = new PlaceDto
                {
                    Name = appointment.Place.Name,
                    Street = appointment.Place.Street,
                    HouseNumber = appointment.Place.HouseNumber,
                    Town = appointment.Place.Town
                }
            };
        }
    }
}
