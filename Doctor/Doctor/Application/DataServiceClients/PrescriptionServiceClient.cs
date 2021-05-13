namespace Doctor.Web.Application.DataServiceClients
{
    using Doctor.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class PrescriptionServiceClient : IPrescriptionServiceClient
    {
        public IHttpClientFactory clientFactory;

        public PrescriptionServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task AddPrescriptionAsync(AddPrescriptionDto prescriptionDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            $"https://localhost:44381/add-prescription");
            request.Headers.Add("Accept", "application/json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var jsonString = JsonSerializer.Serialize(prescriptionDto, options);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            request.Content = content;

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();


        }

        public async Task DeletePrescriptionAsync(int idPrescrtiption)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete,
           $"https://localhost:44381/delete-prescription?IdPrescription={idPrescrtiption}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllDoctorPrescriptionsAsync(int idDoctor)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           $"https://localhost:44381/get-all-doctor-prescriptions?idDoctor={idDoctor}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<PrescriptionDto>>(responseStream, options);
        }
    }
}
