namespace MedicalAppointments.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMedicalAppointmentsRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();

        Task AddAppointmentAsync(Appointment appointment);

        Task DeleteAppointmentAsync(int appointmentId);

        Task<IEnumerable<Appointment>> GetAllDoctorAppointmentsAsync(int idDoctor);


        Task<IEnumerable<Appointment>> GetTodaysDoctorAppointmentsAsync(int idDoctor);


        Task<IEnumerable<Appointment>> GetClosestAppointments(int idPatient);


        Task<IEnumerable<Appointment>> GetAllPatientAppointmentsAsync(int idPatient);


        //miejsce na nowe (ale to są metody do bazy danych) 
    }
}
