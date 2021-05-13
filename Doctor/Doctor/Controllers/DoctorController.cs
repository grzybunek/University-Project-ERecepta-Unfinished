namespace Doctor.Web.Controllers
{
    using Doctor.Web.Application.Dtos;
    using Doctor.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class DoctorController
    {
        private readonly ILogger<DoctorController> logger;
        private readonly IDoctorsHandler doctorsHandler;


        public DoctorController(ILogger<DoctorController> logger, IDoctorsHandler doctorsHandler) {
            this.logger = logger;
            this.doctorsHandler = doctorsHandler;
        }

        [HttpGet("get-all-doctor-prescriptions")]
        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptions([FromQuery] int idDoctor)
        {
            return await doctorsHandler.GetDoctorPrescriptionAsync(idDoctor);
        }

        [HttpPost("add-new-prescription")]
        public async Task AddNewPrescription([FromBody] AddPrescriptionDto prescriptionDto) {

            await doctorsHandler.AddPrescriptionAsync(prescriptionDto);
        }

        [HttpDelete("delete-prescription")]
        public async Task DeletePrescription([FromQuery] int idPrescription )
        {
           await doctorsHandler.DeletePrescriptionAsync(idPrescription);
        }

        [HttpGet("get-all-doctor-appointments")]
        public async Task<IEnumerable<MedicalAppointmentDto>> GetAllMedicalAppointment([FromQuery] int idDoctor)
        {
            return await doctorsHandler.GetDoctorMedicalAppointmentAsync(idDoctor);
        }

        [HttpPost("add-new-appointment")]
        public async Task AddNewAppointment([FromBody] MedicalAppointmentDto appointmentDto)
        {

            await doctorsHandler.AddMedicalAppointmentAsync(appointmentDto);
        }

        [HttpGet("get-allTodays-doctor-appointments")]
        public async Task<IEnumerable<MedicalAppointmentDto>> GetAllTodaysDoctorMedicalAppointment([FromQuery] int idDoctor)
        {
            return await doctorsHandler.GetAllTodaysDoctorMedicalAppointmentAsync(idDoctor);
        }


        [HttpDelete("delete-appointment")]
        public async Task DeleteAppointment([FromQuery] int idAppointment)
        {
            await doctorsHandler.DeleteAppointmentAsync(idAppointment);
        }


    }
}
