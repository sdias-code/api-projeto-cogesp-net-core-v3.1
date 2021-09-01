using System;
using System.Collections.Generic;

#nullable disable

namespace ApiByteBank.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Conta = new HashSet<Conta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
    }
}
