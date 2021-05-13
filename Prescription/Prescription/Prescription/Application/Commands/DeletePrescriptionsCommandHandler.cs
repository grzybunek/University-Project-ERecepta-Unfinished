namespace Prescription.Web.Application.Commands
{
    using Prescription.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeletePrescriptionsCommandHandler : ICommandHandler<DeletePrescriptionCommand>
    {
        private readonly IPrescriptionRepository prescriptionRepository;

        public DeletePrescriptionsCommandHandler(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
        }
        public void Handle(DeletePrescriptionCommand command)
        {
            prescriptionRepository.DeletePrescriptionAsync(command.IdPrescription);
        }
    }
}
