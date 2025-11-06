using Microsoft.EntityFrameworkCore;
using QuanLySanPhamAPI.Data;
using QuanLySanPhamAPI.Models;
using QuanLySanPhamAPI.Repositories.Interfaces;

namespace QuanLySanPhamAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}