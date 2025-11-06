using QuanLySanPhamAPI.DTOs;
using QuanLySanPhamAPI.Models;
using QuanLySanPhamAPI.Repositories.Interfaces;
using QuanLySanPhamAPI.Services.Interfaces;

namespace QuanLySanPhamAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description
            };
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                Description = createProductDto.Description
            };

            await _productRepository.AddAsync(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description
            };
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(updateProductDto.Id);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = updateProductDto.Name;
            existingProduct.Price = updateProductDto.Price;
            existingProduct.Stock = updateProductDto.Stock;
            existingProduct.Description = updateProductDto.Description;

            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}