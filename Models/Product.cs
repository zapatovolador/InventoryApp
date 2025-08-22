namespace InventoryApp.Models;

using System.ComponentModel.DataAnnotations;


/*
Defining the Product properties
Id, Name, Price, Quantity
This class will be used to represent a product in the inventory system.
*/
public class Product
{
    public int Id { get; set; }
    // Adding validation attributes to ensure data integrity
    [Required(ErrorMessage = "A name is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "The product name cannot be empty and must be at least one character long.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "A price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "The price must be a positive number.")]
    public decimal Price { get; set; }
    // Quantity may accept orders even if there is no stock
    public int Quantity { get; set; }
}

