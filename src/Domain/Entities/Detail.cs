using Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Detail : Entities.BaseEntity
    {
        public int UserId { get; set; }
        public DetailType Type { get; set; }
        public string TypeText => Type == DetailType.Address ? "Endereço" : Type == DetailType.Email ? "E-mail" : "Telefone";
        public string Value { get; set; }
        public virtual User User { get; set; }
    }
}
