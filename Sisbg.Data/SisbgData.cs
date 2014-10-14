using Sisbg.Data;
using Sisbg.Data.Repositories;
using Sisbg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisbg.Data
{
    public class SisbgData : ISisbgData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public SisbgData()
            : this(new SisbgDbContext())
        {
        }

        public SisbgData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Product> Products
        {
            get { return this.GetRepository<Product>(); }
        }

        public IRepository<File> Files
        {
            get { return this.GetRepository<File>(); }
        }

        public IRepository<Length> Lengths
        {
            get { return this.GetRepository<Length>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
