using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaPrefeitura.Domain.Models.Shared
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        //public abstract Entity WithId(Guid Id);

    }
}
