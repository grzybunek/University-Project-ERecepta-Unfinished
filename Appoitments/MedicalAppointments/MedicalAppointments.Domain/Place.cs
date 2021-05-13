namespace MedicalAppointments.Domain
{
    using MedicalAppointments.Domain.Template;
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    public class Place: Entity
    {
        #region Properties and Fields
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string HouseNumber { get; private set; }
        public string Town { get; private set; }
        #endregion

        #region Constructors
        public Place(int id, string name, string street, string houseNumber, string town) : base(id)
        {
            this.Name = name;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.Town = town;
        }
        #endregion

    }
}
