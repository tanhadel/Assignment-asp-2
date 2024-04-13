
using System.ComponentModel.DataAnnotations;

namespace Infrastracure.Models;

public class AccountAddressInfo
{

    [Display(Name = "Adress line 1", Prompt = "Enter your address line ")]
    [Required(ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    public string Adress_1 { get; set; } = null!;


    [Display(Name = "Adress line 2", Prompt = "Enter your second address line")]
    [DataType(DataType.Text)]
    public string Adress_2 { get; set; } = null!;


    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [Required(ErrorMessage = "Enter your postal code")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your city")]
    [Required(ErrorMessage = "Enter your City")]
    public string City { get; set; } = null!;



}
