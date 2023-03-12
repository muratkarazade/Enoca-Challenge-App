using Enoca.Core.Models;
using Enoca.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Product>> GetProductWithOrderAsync()
        {
            throw new NotImplementedException();
        }
    }
}
