using Infrastracure.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models;

public class AccountdetailsViewModel
{

    public AccountBasicInfo BasicInfo { get; set; } = null!;
    public AccountAddressInfo AddressInfo { get; set; } = null!;
    
}

