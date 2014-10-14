using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisbg.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual File Image { get; set; }

        public int ImageId { get; set; }
    }
}
