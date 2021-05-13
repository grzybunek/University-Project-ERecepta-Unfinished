namespace Doctor.Web.Application.Dtos
{
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public int IdDoctor { get; set; }

        public int IdPatient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public IEnumerable<MedicineDto> Medicines { get; set; }
    }
}