namespace Patient.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddPrescriptionDto
    {
        public int IdDoctor { get; set; }

        public int IdPatient { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public IDictionary<string,int> Medicines { get; set; }
    }
}
