using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Web.Application.Commands
{
    using MedicalAppointments.Domain.Services;
    using MedicalAppointments.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppointmentsCommandsHandler : ICommandHandler<AddAppointmentCommand>
    {
        private readonly IMedicalAppointmentsRepository appointmentsRepository;

        public AppointmentsCommandsHandler(IMedicalAppointmentsRepository appointmentsRepository)
        {
            this.appointmentsRepository = appointmentsRepository;
        }

        public void Handle(AddAppointmentCommand command)
        {
            appointmentsRepository.AddAppointmentAsync(new Appointment(0, command.IdDoctor, command.IdPatient, command.StartDateOfTheVisit, command.EndDateOfTheVisit, 
                new Place(0, command.Place.Name, command.Place.Street, command.Place.HouseNumber, command.Place.Town)));      
        }
    }
}
