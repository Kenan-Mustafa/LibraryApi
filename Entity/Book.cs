using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Count { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }

}
