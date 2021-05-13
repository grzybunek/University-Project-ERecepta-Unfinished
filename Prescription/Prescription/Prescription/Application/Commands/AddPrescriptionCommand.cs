namespace Prescription.Web.Application.Commands
{
    using Prescription.Domain;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddPrescriptionCommand : ICommand
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public IDictionary<string,int> Medicines { get; set; }



    }
}
