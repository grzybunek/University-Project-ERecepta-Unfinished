namespace Prescription.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Prescription.Web.Application.Commands;
    using Prescription.Web.Application.Dtos;
    using Prescription.Web.Application.Queries;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class PrescriptionsController
    {
        private readonly ILogger<PrescriptionsController> logger;
        private readonly IPrescriptionQueriesHandler prescriptionsQueriesHandler;
        private readonly ICommandHandler<AddPrescriptionCommand> addPrescriptionCommandHandler;
        private readonly ICommandHandler<DeletePrescriptionCommand> deletePrescriptionCommandHandler;

        public PrescriptionsController(ILogger<PrescriptionsController> logger, IPrescriptionQueriesHandler prescriptionsQueriesHandler, ICommandHandler<AddPrescriptionCommand> addPrescriptionCommandHandler, ICommandHandler<DeletePrescriptionCommand> deletePrescriptionCommandHandler)
        {
            this.logger = logger;
            this.prescriptionsQueriesHandler = prescriptionsQueriesHandler;
            this.addPrescriptionCommandHandler = addPrescriptionCommandHandler;
            this.deletePrescriptionCommandHandler = deletePrescriptionCommandHandler;
        }

        [HttpGet("prescriptions")]
        public async Task<IEnumerable<PrescriptionObjectDto>> GetAllAsync()
        {
            return await prescriptionsQueriesHandler.GetAllAsync();
        }

        [HttpPost("add-prescription")]
        public void AddExaminationRoom([FromBody] AddPrescriptionCommand prescriptionCommand)
        {
            addPrescriptionCommandHandler.Handle(prescriptionCommand);
        }

        [HttpGet("get-all-doctor-prescriptions")]
        public async Task<IEnumerable<PrescriptionObjectDto>> GetDoctorPrescriptions(int idDoctor)
        {
            return await prescriptionsQueriesHandler.GetAllDoctorAsync(idDoctor);
        }

        [HttpGet("get-all-patient-prescriptions")]
        public async Task<IEnumerable<PrescriptionObjectDto>> GetPatientPrescriptions(int idPatient)
        {
            return await prescriptionsQueriesHandler.GetAllPatientAsync(idPatient);
        }


        [HttpDelete("delete-prescription")]
        public void DeletePrescription([FromQuery] DeletePrescriptionCommand prescriptionCommand)
        {
            deletePrescriptionCommandHandler.Handle(prescriptionCommand);
        }

    }
}
