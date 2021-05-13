namespace Doctor.Web.Application.Queries
{
    using Doctor.Web.Application.DataServiceClients;
    using Doctor.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class DoctorsQueryHandler : IDoctorsHandler
    {
        private readonly IPrescriptionServiceClient prescriptionServiceClient;
        private readonly IMedicalAppointmentServiceClient medicalAppointmentServiceClient;

        public DoctorsQueryHandler(IPrescriptionServiceClient prescriptionServiceClient, IMedicalAppointmentServiceClient medicalAppointmentServiceClient) {
            this.prescriptionServiceClient = prescriptionServiceClient;
            this.medicalAppointmentServiceClient = medicalAppointmentServiceClient;
        }

        public async Task AddPrescriptionAsync(AddPrescriptionDto prescriptionDto)
        {
             await prescriptionServiceClient.AddPrescriptionAsync(prescriptionDto);
        
        }

        public async Task DeletePrescriptionAsync(int idPrescription)
        {
            await prescriptionServiceClient.DeletePrescriptionAsync(idPrescription);
        }
        public async Task<IEnumerable<PrescriptionDto>> GetDoctorPrescriptionAsync(int idDoctor)
        {
            var doctors = await prescriptionServiceClient.GetAllDoctorPrescriptionsAsync(idDoctor);

            return doctors;

        }

        public async Task<IEnumerable<MedicalAppointmentDto>> GetDoctorMedicalAppointmentAsync(int idDoctor)
        {
            var doctors = await medicalAppointmentServiceClient.GetAllDoctorMedicalAppointmentsAsync(idDoctor);
            return doctors;
        }

        public async Task AddMedicalAppointmentAsync(MedicalAppointmentDto appointmentDto) {
            await medicalAppointmentServiceClient.AddMedicalAppointmentAsync(appointmentDto);

        }

        public async Task<IEnumerable<MedicalAppointmentDto>> GetAllTodaysDoctorMedicalAppointmentAsync(int idDoctor) 
        {
            var appointments = await medicalAppointmentServiceClient.GetAllTodaysDoctorMedicalAppointmentAsync(idDoctor);
            return appointments;
        }

        public async Task DeleteAppointmentAsync(int idAppointment)
        {
            await medicalAppointmentServiceClient.DeleteAppointmentAsync(idAppointment);
        }
    }
}
