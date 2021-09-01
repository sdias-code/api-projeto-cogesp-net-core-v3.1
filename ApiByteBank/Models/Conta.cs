using System;
using System.Collections.Generic;

#nullable disable

namespace ApiByteBank.Models
{
    public partial class Conta
    {
        public Conta()
        {
            Transacos = new HashSet<Transaco>();
        }

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Transaco> Transacos { get; set; }
    }
}
