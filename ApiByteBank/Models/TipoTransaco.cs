using System;
using System.Collections.Generic;

#nullable disable

namespace ApiByteBank.Models
{
    public partial class TipoTransaco
    {
        public TipoTransaco()
        {
            Transacos = new HashSet<Transaco>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Transaco> Transacos { get; set; }
    }
}
