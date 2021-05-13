namespace Patient.Web.Application.DataServiceClients
{
    using Patient.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPrescriptionServiceClient
    {
        Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptionsAsync(int idDoctor);

  
    }
}
