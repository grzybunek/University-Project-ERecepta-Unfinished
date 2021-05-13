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

    public class MedicalAppointmentServiceClient : IMedicalAppointmentServiceClient
    {
        public IHttpClientFactory clientFactory;

        public MedicalAppointmentServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<MedicalAppointmentDto>> GetAllDoctorMedicalAppointmentsAsync(int idDoctor) {
            var request = new HttpRequestMessage(HttpMethod.Get,
               $"https://localhost:44381/GetAllDoctorAppointments?idDoctor={idDoctor}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<MedicalAppointmentDto>>(responseStream, options);

        }

        public async Task AddMedicalAppointmentAsync(MedicalAppointmentDto medicalAppointment) {
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"https://localhost:44381/AddAppointment");
            request.Headers.Add("Accept", "application/json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var jsonString = JsonSerializer.Serialize(medicalAppointment, options);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            request.Content = content;

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }

        public async Task<IEnumerable<MedicalAppointmentDto>> GetAllTodaysDoctorMedicalAppointmentAsync(int idDoctor)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
              $"https://localhost:44381/GetAllTodaysDoctorAppointments?idDoctor={idDoctor}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<MedicalAppointmentDto>>(responseStream, options);
        }

        public async Task DeleteAppointmentAsync(int idAppoinment)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete,
        $"https://localhost:44381/DeleteAppointment?idAppointment={idAppoinment}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

        }
    }
}
