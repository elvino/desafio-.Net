using System;

namespace Domain.Shared.Entities
{
    public abstract class Entity 
    {
        protected Entity() => Id = Guid.NewGuid();

        public Guid Id { get; private set; }
    }
}
