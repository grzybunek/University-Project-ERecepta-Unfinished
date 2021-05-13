namespace Prescription.Web.Application.Queries
{
    using Prescription.Domain.Services;
    using Prescription.Web.Application.Dtos;
    using Prescription.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PrescriptionQueriesHandler : IPrescriptionQueriesHandler
    {
        private readonly IPrescriptionRepository prescriptionsRepository;

        public PrescriptionQueriesHandler(IPrescriptionRepository prescriptionsRepository)
        {
            this.prescriptionsRepository = prescriptionsRepository;
        }
        public async Task<IEnumerable<PrescriptionObjectDto>> GetAllAsync()
        {
            return (await prescriptionsRepository.GetAllAsync()).Select(r => r.Map());
        }

        public async Task<IEnumerable<PrescriptionObjectDto>> GetAllDoctorAsync(int idDoctor)
        {
            return (await prescriptionsRepository.GetAllDoctorPrescriptions(idDoctor)).Select(r => r.Map());
        }

        public async Task<IEnumerable<PrescriptionObjectDto>> GetAllPatientAsync(int idPatient)
        {
            return (await prescriptionsRepository.GetAllPatientPrescriptions(idPatient)).Select(r => r.Map());
        }
    }
}
