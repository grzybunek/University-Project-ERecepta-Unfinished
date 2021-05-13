namespace Doctor.Web.Application.Queries
{
    using Doctor.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorsHandler
    {
        Task<IEnumerable<PrescriptionDto>> GetDoctorPrescriptionAsync(int idDoctor);

        Task AddPrescriptionAsync(AddPrescriptionDto prescriptionDto);

        Task DeletePrescriptionAsync(int idPrescription);

        Task<IEnumerable<MedicalAppointmentDto>> GetDoctorMedicalAppointmentAsync(int idDoctor);

        Task AddMedicalAppointmentAsync(MedicalAppointmentDto appointmentDto);

        Task<IEnumerable<MedicalAppointmentDto>> GetAllTodaysDoctorMedicalAppointmentAsync(int idDoctor);

        Task DeleteAppointmentAsync(int idAppointment);
    }
}
