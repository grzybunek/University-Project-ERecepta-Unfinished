namespace Patient.Web.Controllers
{
    using Patient.Web.Application.Dtos;
    using Patient.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    [ApiController]
    public class PatientController
    {
        private readonly ILogger<PatientController> logger;
        private readonly IPatientsHandler patientsHandler;


        public PatientController(ILogger<PatientController> logger, IPatientsHandler patientsHandler) {
            this.logger = logger;
            this.patientsHandler = patientsHandler;
        }

        [HttpGet("GetAllPatientPrescriptions")]
        public async Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptions([FromQuery] int idPatient)
            {
            return await patientsHandler.GetAllPatientPrescriptionAsync(idPatient);
            }

        [HttpGet("GetAllPatientAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetAlltPatientAppointments(int idPatient)
            {
            return await patientsHandler.GetAllPatientAppointments(idPatient);
            }



        [HttpGet("GetClosestPatientAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointments(int idPatient)
            {
            return await patientsHandler.GetClosestPatientAppointments(idPatient);
            }

        [HttpPost("AddAppointment")]
        public async Task AddAppointment([FromBody] AppointmentDto appointmentDto)
            {

            await patientsHandler.AddAppointment(appointmentDto);
            }


        [HttpDelete("DeleteAppointment")]
        public async Task DeleteAppointment([FromQuery] int idAppointment)
            {
            //dopisz kod
            }



        }




  
}
