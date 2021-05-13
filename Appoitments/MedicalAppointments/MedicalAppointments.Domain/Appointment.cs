using System;

namespace MedicalAppointments.Domain
{
    using MedicalAppointments.Domain.Template;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Appointment : Entity
    {
        #region Properties and Fields
        public int IdDoctor { get; private set; }
        public int IdPatient { get; private set; }
        public DateTime StartDateOfTheVisit { get; private set; }
        public DateTime EndDateOfTheVisit { get; private set; }
        public Place Place { get; private set; }
        #endregion

        #region Constructors
        public Appointment(int id, int idDoctor, int idPatient, DateTime startDateOfTheVisit, DateTime endDateOfTheVisit) : base(id)
            {
            this.IdDoctor = idDoctor;
            this.IdPatient = idPatient;
            this.StartDateOfTheVisit = startDateOfTheVisit;
            this.EndDateOfTheVisit = endDateOfTheVisit;
            }
        public Appointment(int id, int idDoctor, int idPatient, DateTime startDateOfTheVisit, DateTime endDateOfTheVisit, Place place) : base(id)
        {
            this.IdDoctor = idDoctor;
            this.IdPatient = idPatient;
            this.StartDateOfTheVisit = startDateOfTheVisit;
            this.EndDateOfTheVisit = endDateOfTheVisit;
            this.Place = place;
        }
        #endregion

        public void AddPlace(Place place)
        {
            this.Place = place;
        }
    }
}
