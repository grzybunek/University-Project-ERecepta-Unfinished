namespace Prescription.Domain
{
    using global::Prescription.Domain.Template;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PrescriptionObject : Entity
    {
        #region Properties and Fields
        public int IdDoctor { get; private set; }
        public int IdPatient { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime DateOfExpiration { get; private set; }
        public IList<Medicine> Medicines { get; private set; } = new List<Medicine>();

        #endregion

        public PrescriptionObject(int id, int idDoctor, int idPatient, DateTime date, DateTime dateOfExpiration) : base(id) {
            IdDoctor = idDoctor;
            IdPatient = idPatient;
            Date = date;
            DateOfExpiration = dateOfExpiration;
            
        }

        public PrescriptionObject(int id, int idDoctor, int idPatient, DateTime date, DateTime dateOfExpiration, List<Medicine> medicines) : this(id,idDoctor,idPatient,date,dateOfExpiration)
        {
            Medicines = medicines;

        }
        public void AddMedicine(Medicine medicine)
        {
            Medicines.Add(medicine);
        }
        public void AddMedicines(IEnumerable<Medicine> medicines)
        {
            foreach (var medicine in medicines)
                Medicines.Add(medicine);
        }
    }
}
