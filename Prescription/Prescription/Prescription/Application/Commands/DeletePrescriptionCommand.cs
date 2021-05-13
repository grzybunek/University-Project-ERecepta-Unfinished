namespace Prescription.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeletePrescriptionCommand : ICommand
    {
        public int IdPrescription { get; set; }
    }
}
