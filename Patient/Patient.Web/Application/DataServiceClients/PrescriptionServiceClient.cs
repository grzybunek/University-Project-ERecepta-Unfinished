namespace Patient.Web.Application.DataServiceClients
{
    using Patient.Web.Application.Dtos;
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

        public PrescriptionServiceClient(IHttpClientFactory clientFactory) {
            this.clientFactory = clientFactory;
        }

      

        public async Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptionsAsync(int idPatient)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           $"https://localhost:44381/get-all-patient-prescriptions?idPoctor={idPatient}");
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
