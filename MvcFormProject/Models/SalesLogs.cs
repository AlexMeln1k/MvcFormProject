using MvcFormProject.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SalesLogs
{
    [Key]
    public int SaleID { get; set; }

    [Required]
    public int CustomerID { get; set; }

    [Required]
    public int EmployeeID { get; set; }

    [Required]
    public int ItemID { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime SaleDate { get; set; }

    [Required]
    public int QuantitySold { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total must be greater than 0")]
    public decimal Total { get; set; }

    [ForeignKey("CustomerID")]
    public Customer Customer { get; set; }

    [ForeignKey("EmployeeID")]
    public Employee Employee { get; set; }

    [ForeignKey("ItemID")]
    public Inventory Item { get; set; }

}
