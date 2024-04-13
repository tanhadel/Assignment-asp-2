
using System.ComponentModel.DataAnnotations;

namespace Infrastracure.Models;

public class AccountBasicInfo
{

    [Display(Name = "First name", Prompt = "John")]
    [Required(ErrorMessage = "You most enter a first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;



    [Display(Name = "Last name", Prompt = "Doe")]
    [Required(ErrorMessage = "You most enter a last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email address", Prompt = "john.doe@domain.com")]
    [Required(ErrorMessage = "You most enter an e-mail address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone number")]

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = null!;

    [Display(Name = "Bio (Optional)", Prompt = "Add a short bio...")]
    public string Bio { get; set; } = null!;

}
