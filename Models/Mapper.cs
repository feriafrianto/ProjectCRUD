using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraderSys.Portfolios.Models.Entities;
using AutoMapper;

namespace TraderSys.Portfolios.Models
{
    public class Mapper : Profile
    {
        public Mapper(){
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>().ReverseMap();
            // CreateMap<PaginatedCargos, PaginatedList<Cargo>>().ReverseMap();
        }
    }
}