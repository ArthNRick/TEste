using System;
using System.Collections.Generic;
using System.Text;

namespace TR.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Detail> Details { get; set; }
        public string FullName => $"{Name} {LastName}";
    }
}