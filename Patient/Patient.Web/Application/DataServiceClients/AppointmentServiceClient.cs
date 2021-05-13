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

    public class AppointmentServiceClient : IAppointmentServiceClient
        {
        public IHttpClientFactory clientFactory;

        public AppointmentServiceClient(IHttpClientFactory clientFactory) {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointments(int idPatient)
            {
            var request = new HttpRequestMessage(HttpMethod.Get,
           $"https://localhost:44381/GetClosestPatientAppointments?idPatient={idPatient}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
                {
                PropertyNameCaseInsensitive = true,
                };

            return await JsonSerializer.DeserializeAsync<IEnumerable<AppointmentDto>>(responseStream, options);
            }

        public async Task<IEnumerable<AppointmentDto>> GetAllPatientAppointments(int idPatient)
            {
            var request = new HttpRequestMessage(HttpMethod.Get,
           $"https://localhost:44381/GetAllPatientAppointments?idPatient={idPatient}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
                {
                PropertyNameCaseInsensitive = true,
                };

            return await JsonSerializer.DeserializeAsync<IEnumerable<AppointmentDto>>(responseStream, options);
            }

        public async Task AddAppointment(AppointmentDto appointmentdto)
            {
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://localhost:44381/AddAppointment");
            request.Headers.Add("Accept", "application/json");

            var options = new JsonSerializerOptions
                {
                PropertyNameCaseInsensitive = true,
                };

            var jsonString = JsonSerializer.Serialize(appointmentdto, options);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            request.Content = content;

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();
            }

        }
}
