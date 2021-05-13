namespace Prescription.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPrescriptionRepository
    {
        Task<IEnumerable<PrescriptionObject>> GetAllAsync();

        Task AddPrescriptionAsync(PrescriptionObject prescription);

        Task<IEnumerable<PrescriptionObject>> GetAllDoctorPrescriptions(int idDoctor);

        Task DeletePrescriptionAsync(int idPrescription);

        Task<IEnumerable<PrescriptionObject>> GetAllPatientPrescriptions(int idPatient);
    }
}
