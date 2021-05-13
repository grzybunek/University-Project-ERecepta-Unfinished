namespace Doctor.Web.Application.DataServiceClients
{
    using Doctor.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMedicalAppointmentServiceClient
    {
        Task<IEnumerable<MedicalAppointmentDto>> GetAllDoctorMedicalAppointmentsAsync(int idDoctor);

        Task AddMedicalAppointmentAsync(MedicalAppointmentDto medicalAppointment);

        Task<IEnumerable<MedicalAppointmentDto>> GetAllTodaysDoctorMedicalAppointmentAsync(int idDoctor);

        Task DeleteAppointmentAsync(int idAppoinment);
    }
}
