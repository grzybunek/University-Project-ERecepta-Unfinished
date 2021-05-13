namespace Prescription.Domain.Services
{
    using Prescription.Domain.Template;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MedicinePrescription : Entity
    {
        public int MedicineId { get; private set; }
        public int PrescriptionId { get; private set; }


        public MedicinePrescription(int id, int medicineId, int prescriptionId):base(id) {
            MedicineId = medicineId;
            PrescriptionId = prescriptionId;
        
        }
    }
}
