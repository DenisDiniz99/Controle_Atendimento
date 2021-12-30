using System;

namespace Prefeitura.SysCras.Business.Entities
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
