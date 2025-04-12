using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Services.Abstractions;
using Shared;

namespace Services
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper Mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            var Brands=await unitOfWork.GetRepos<Productbrand,int>().GetAllAsync();
            var BrandRes=Mapper.Map<IEnumerable<BrandResultDTO>>(Brands);
            return BrandRes;
        }

        public Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResultDTO?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
