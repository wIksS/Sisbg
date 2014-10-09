using Sisbg.Data.Repositories;
using Sisbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sisbg.Data
{
    public interface ISisbgData
    {
        IRepository<Product> Products { get; }

        IRepository<ApplicationUser> Users { get; }        

    }
}
