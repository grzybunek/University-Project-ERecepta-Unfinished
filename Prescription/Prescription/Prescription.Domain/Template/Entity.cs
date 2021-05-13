using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Domain.Template
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
