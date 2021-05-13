namespace Patient.Web.Application.DataServiceClients
{
    using Patient.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAppointmentServiceClient
    {
        Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointments(int idPatient);
        Task<IEnumerable<AppointmentDto>> GetAllPatientAppointments(int idPatient);
        Task AddAppointment(AppointmentDto appointmentdto);

    }
}
