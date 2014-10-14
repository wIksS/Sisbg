using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisbg.Models
{
    public class Product
    {
        private ICollection<File> images;
        private ICollection<Length> lengths;

        public Product()
        {
            this.Images = new HashSet<File>();
            this.Lengths = new HashSet<Length>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BriefDescription { get; set; }

        public string Description { get; set; }

        public string JobDescription { get; set; }

        public virtual File FirstImage { get; set; }

        public virtual ICollection<File> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Length> Lengths
        {
            get { return this.lengths; }
            set { this.lengths = value; }
        }
    }
}
