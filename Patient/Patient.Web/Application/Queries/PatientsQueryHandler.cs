namespace Patient.Web.Application.Queries
{
    using Patient.Web.Application.DataServiceClients;
    using Patient.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class PatientsQueryHandler : IPatientsHandler
    {
        private readonly IPrescriptionServiceClient prescriptionServiceClient;
        private readonly IAppointmentServiceClient appointmentServiceClient;

        public PatientsQueryHandler(IPrescriptionServiceClient prescriptionServiceClient, IAppointmentServiceClient appointmentServiceClient)
            {
            this.prescriptionServiceClient = prescriptionServiceClient;
            this.appointmentServiceClient = appointmentServiceClient;
            }




        

     


        public async Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptionAsync(int idPatient)
        {
            var doctors = await prescriptionServiceClient.GetAllPatientPrescriptionsAsync(idPatient);

            return doctors;

        }


       
         public async Task<IEnumerable<AppointmentDto>> GetAllPatientAppointments(int idPatient)
            {
            var allAppointments = await appointmentServiceClient.GetClosestPatientAppointments(idPatient);

            return allAppointments;

            }
        


    public async Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointments(int idPatient)
            {
            var closestAppointments = await appointmentServiceClient.GetClosestPatientAppointments(idPatient);

            return closestAppointments;

            }


        public async Task AddAppointment(AppointmentDto appointmentDto)
            {
            await appointmentServiceClient.AddAppointment(appointmentDto);

            }


        }
}
