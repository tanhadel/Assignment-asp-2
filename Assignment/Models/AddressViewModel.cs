using System.ComponentModel.DataAnnotations;

namespace Assignment.Models;

public class AddressViewModel
{


    [Display(Name = "Adress line 1", Prompt = "Enter your address line")]
    [Required(ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    public string Adress_1 { get; set; } = null!;


    [Display(Name = "Adress line 2", Prompt = "Enter your second address line")]
    [Required(ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    public string Adress_2 { get; set; } = null!;


    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [Required(ErrorMessage = "A valid postal code is required")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your city")]
    [Required(ErrorMessage = "A valid city is required")]
    [DataType(DataType.PostalCode)]
    public string City { get; set; } = null!;
}
