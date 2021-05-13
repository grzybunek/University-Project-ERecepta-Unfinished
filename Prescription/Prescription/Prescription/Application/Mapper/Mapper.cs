namespace Prescription.Web.Application.Mapper
{
    using Prescription.Domain;
    using Prescription.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Mapper
    {
        public static PrescriptionObjectDto Map(this PrescriptionObject prescription)
        {
            if (prescription == null)
                return null;

            return new PrescriptionObjectDto
            {
                IdPrescription = prescription.Id,
                IdDoctor = prescription.IdDoctor,
                IdPatient = prescription.IdPatient,
                Date = prescription.Date,
                DateOfExpiration = prescription.DateOfExpiration,
                Medicines = prescription.Medicines
            };
        }

    }
}
