using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace ApiByteBank.Models
{
    public partial class Transaco
    {
        public int Id { get; set; }
        public int? ContaId { get; set; }
        public int? TipoTransacaoId { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        [JsonIgnore]
        public virtual Conta Conta { get; set; }
        
        public virtual TipoTransaco TipoTransacao { get; set; }
    }
}
