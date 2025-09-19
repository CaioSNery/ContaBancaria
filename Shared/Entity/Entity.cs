using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Entities.Interface
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}