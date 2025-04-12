using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Services.Abstractions
{
public interface IProductService
    {
        public Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync();
        public Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        public Task <IEnumerable<TypeResultDTO>> GetAllTypesAsync();
        public Task <ProductResultDTO?> GetProductByIdAsync(int  id);
    }
}
