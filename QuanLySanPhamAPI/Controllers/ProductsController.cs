using Microsoft.AspNetCore.Mvc;
using QuanLySanPhamAPI.DTOs;
using QuanLySanPhamAPI.Services.Interfaces;

namespace QuanLySanPhamAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); 
        }

        // GET: /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); 
            }
            return Ok(product); 
        }

        // POST: /api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var newProductDto = await _productService.CreateProductAsync(createProductDto);
            
          
            return CreatedAtAction(nameof(GetById), new { id = newProductDto.Id }, newProductDto);
        }

        // PUT: /api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            
            if (id != updateProductDto.Id)
            {
                return BadRequest("ID trong URL không khớp với ID trong body.");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
           
            var productToUpdate = await _productService.GetProductByIdAsync(id);
            if (productToUpdate == null)
            {
                return NotFound();
            }

            await _productService.UpdateProductAsync(updateProductDto);
            
            return NoContent(); 
        }

        // DELETE: /api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            var productToDelete = await _productService.GetProductByIdAsync(id);
            if (productToDelete == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(id);
            
            return NoContent(); 
        }
    }
}