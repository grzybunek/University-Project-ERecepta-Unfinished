namespace MedicalAppointments.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteAppointmentCommand : ICommand
    {
        public int IdAppointment { get; set; }
    }
}
