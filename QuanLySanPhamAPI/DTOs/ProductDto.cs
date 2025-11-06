using System.ComponentModel.DataAnnotations;

namespace QuanLySanPhamAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int Stock { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}