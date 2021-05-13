
namespace MedicalAppointments.Web.Application.Queries
{
    using MedicalAppointments.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAppointmentQueriesHandler
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<IEnumerable<AppointmentDto>> GetAllDoctorAppointmentsAsync(int idDoctor);
        Task<IEnumerable<AppointmentDto>> GetTodaysDoctorAppointmentsAsync(int idDoctor);
        Task<IEnumerable<AppointmentDto>> GetClosestAppointments(int idPatient);

        Task<IEnumerable<AppointmentDto>> GetAllPatientAppointmentsAsync(int idPatient);
    }
}
