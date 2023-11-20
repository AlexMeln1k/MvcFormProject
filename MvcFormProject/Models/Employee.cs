using System;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Key]
    public int EmployeeID { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(1)]
    public string Gender { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(15)]
    public string ContactNumber { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    public string Position { get; set; }

    [Required]
    [StringLength(50)]
    public string Department { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime HireDate { get; set; }

    [Required]
    public decimal Salary { get; set; }

    [StringLength(255)]
    public string Photo { get; set; }
}
