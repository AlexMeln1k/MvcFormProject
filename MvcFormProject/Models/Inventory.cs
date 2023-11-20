using System;
using System.ComponentModel.DataAnnotations;

namespace MvcFormProject.Models
{
    public class Inventory
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be non-negative")]
        public int StockQuantity { get; set; }

        [Required]
        public bool AvailableForSale { get; set; }

        [Required]
        public bool RecommendedForDisabilities { get; set; }
    }
}
