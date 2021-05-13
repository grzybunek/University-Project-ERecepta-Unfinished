namespace Prescription.Web.Application.Queries
{
    using Prescription.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPrescriptionQueriesHandler
    {
        Task<IEnumerable<PrescriptionObjectDto>> GetAllAsync();

        Task<IEnumerable<PrescriptionObjectDto>> GetAllDoctorAsync(int idDoctor);

        Task<IEnumerable<PrescriptionObjectDto>> GetAllPatientAsync(int idPatient);
    }
}
