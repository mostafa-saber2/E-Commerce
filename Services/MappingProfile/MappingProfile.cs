using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Shared;

namespace Services.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Productbrand,BrandResultDTO>();
            CreateMap<ProductType,TypeResultDTO>();
            CreateMap<Product, ProductResultDTO>()
                .ForMember(d => d.BrandName, Options => Options.MapFrom(S => S.productbrand.Name))
                .ForMember(d => d.TypeName, Options => Options.MapFrom(S => S.productType.Name));






        }
    }
}
