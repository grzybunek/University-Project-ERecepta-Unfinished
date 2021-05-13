namespace MedicalAppointments.Web.Application.Commands
{
    using MedicalAppointments.Web.Application.Commands;
    using MedicalAppointments.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteAppointmentCommandHandler : ICommandHandler<DeleteAppointmentCommand>
    {
        private readonly IMedicalAppointmentsRepository appointmentRepository;

        public DeleteAppointmentCommandHandler(IMedicalAppointmentsRepository prescriptionRepository)
        {
            this.appointmentRepository = prescriptionRepository;
        }
        public void Handle(DeleteAppointmentCommand command)
        {
            appointmentRepository.DeleteAppointmentAsync(command.IdAppointment);
        }
    }
}
