namespace Doctor.Web.Application.DataServiceClients
{
    using Doctor.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPrescriptionServiceClient
    {
        Task<IEnumerable<PrescriptionDto>> GetAllDoctorPrescriptionsAsync(int idDoctor);

        Task AddPrescriptionAsync(AddPrescriptionDto prescriptionDto);

        Task DeletePrescriptionAsync(int idPrescrtiption);
    }
}
