using Microsoft.AspNet.Identity.EntityFramework;
using Sisbg.Data.Migrations;
using Sisbg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisbg.Data
{
    public class SisbgDbContext : IdentityDbContext
    {
        public SisbgDbContext()
            : base("SisbgConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SisbgDbContext, Configuration>());
        }

        IDbSet<Product> Products { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        public static SisbgDbContext Create()
        {
            return new SisbgDbContext();
        }
    }
}
