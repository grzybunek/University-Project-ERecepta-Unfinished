namespace Prescription.Domain
{
    using global::Prescription.Domain.Template;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Medicine : Entity
    {
        #region Properties and Fields
        public string Name { get; private set; }
        public int DailyDose { get; private set; }

        #endregion

        public Medicine(int id, string name, int dailyDose) : base(id) {
            Name = name;
            DailyDose=dailyDose;
        }
    }
}
