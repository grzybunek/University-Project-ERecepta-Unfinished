namespace Prescription.Web.Application.Dtos
{
    using Prescription.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PrescriptionObjectDto
    {
        public int IdPrescription { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public IEnumerable<Medicine> Medicines { get; set; }
    }
}
