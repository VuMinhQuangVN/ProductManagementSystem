using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySanPhamAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [MinLength(3, ErrorMessage = "Tên sản phẩm phải có ít nhất 3 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng tồn kho là bắt buộc.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải lớn hơn hoặc bằng 0.")]
        public int Stock { get; set; }

        public string? Description { get; set; }

    }
}