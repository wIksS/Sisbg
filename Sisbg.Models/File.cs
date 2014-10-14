using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisbg.Models
{
    public class File
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
