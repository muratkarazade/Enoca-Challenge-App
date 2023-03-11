using AutoMapper;
using Enoca.Core.Models;
using Enoca.Core.Repositories;
using Enoca.Core.Services;
using Enoca.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(
            IGenericRepository<Company> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICompanyRepository companyRepository
        ) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
