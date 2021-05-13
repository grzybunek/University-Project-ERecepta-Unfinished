namespace Patient.Web.Application.Queries
{
    using Patient.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPatientsHandler
    {
        Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptionAsync(int idPatient);

        Task<IEnumerable<AppointmentDto>> GetAllPatientAppointments(int idPatient);

        Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointments(int idPatient);

        Task AddAppointment(AppointmentDto appointmentDto);


        
        }
}
