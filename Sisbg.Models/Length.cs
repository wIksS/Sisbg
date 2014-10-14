using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisbg.Models
{
    public class Length
    {
        public int Id { get; set; }

        public int Inches { get; set; }

        public string Code { get; set; }

        public int Weight { get; set; }

        public int Pallet { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
