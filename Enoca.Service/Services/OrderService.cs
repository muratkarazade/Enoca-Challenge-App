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
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
    }
}
