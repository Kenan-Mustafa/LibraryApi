using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BaseEntity 
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
