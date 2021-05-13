namespace Prescription.Web.Application.Commands
{
    using Prescription.Domain;
    using Prescription.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PrescriptionsCommandsHandler : ICommandHandler<AddPrescriptionCommand>
    {
        private readonly IPrescriptionRepository prescriptionRepository;

        public PrescriptionsCommandsHandler(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }

        public void Handle(AddPrescriptionCommand command)
        {
            var medicines = new List<Medicine>();

            foreach (var medicine in command.Medicines)
                medicines.Add(new Medicine(0,medicine.Key,medicine.Value));

            prescriptionRepository.AddPrescriptionAsync(new PrescriptionObject(0, command.IdDoctor, command.IdPatient, command.Date, command.DateOfExpiration, medicines));

        }



    }
}
