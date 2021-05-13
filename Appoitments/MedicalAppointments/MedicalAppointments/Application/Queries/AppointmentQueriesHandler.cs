using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Web.Application.Queries
{
    using MedicalAppointments.Web.Application.Dtos;
    using MedicalAppointments.Domain.Services;
    using MedicalAppointments.Infrastructure.Repositories;
    using MedicalAppointments.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppointmentQueriesHandler : IAppointmentQueriesHandler
    {
        private readonly IMedicalAppointmentsRepository appointmentsRepository;

        public AppointmentQueriesHandler(IMedicalAppointmentsRepository appointmentsRepository)
        {
            this.appointmentsRepository = appointmentsRepository;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            return (await appointmentsRepository.GetAllAsync()).Select(r => r.Map());
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllDoctorAppointmentsAsync(int idDoctor)
            {
            return (await appointmentsRepository.GetAllDoctorAppointmentsAsync(idDoctor)).Select(r => r.Map());
            }

        public async Task<IEnumerable<AppointmentDto>> GetTodaysDoctorAppointmentsAsync(int idDoctor)
            {
            return (await appointmentsRepository.GetTodaysDoctorAppointmentsAsync(idDoctor)).Select(r => r.Map());
            }

        public async Task<IEnumerable<AppointmentDto>> GetClosestAppointments(int idPatient)
            {
            return (await appointmentsRepository.GetClosestAppointments(idPatient)).Select(r => r.Map());
            }

        public async Task<IEnumerable<AppointmentDto>> GetAllPatientAppointmentsAsync(int idPatient)
            {
            return (await appointmentsRepository.GetAllPatientAppointmentsAsync(idPatient)).Select(r => r.Map());
            }

        
    }
}
