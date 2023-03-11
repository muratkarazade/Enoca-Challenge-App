using Enoca.Core.Models;
using Enoca.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {

        public CompanyRepository(AppDbContext context) : base(context) 
        {
            
        }

        public Task<Company> GetCompanyByIdWithOrderAsync(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
