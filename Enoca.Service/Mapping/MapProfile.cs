using AutoMapper;
using Enoca.Core.DTOs;
using Enoca.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Company,CompanyDto>().ReverseMap();
            CreateMap<OrderTimeUpdateDto, Company>();
            CreateMap<CompanyStatusUpdateDto, Company>();
            CreateMap<Company, CompanyWithProductDto>();
            CreateMap<Product, ProductWithOrderDto>();
            CreateMap<CompanyStatusUpdateDto, CompanyDto>();
            CreateMap<OrderTimeUpdateDto, CompanyDto>();
        }

    }
}
