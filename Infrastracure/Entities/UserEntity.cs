

using Infrastracure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastracture.Entities;

public class UserEntity:IdentityUser
{

    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;


    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }

    public bool IsExternal { get; set; }
    public string? Bio {  get; set; }

    public string? ProfileImage { get; set; } = "avatar.jpg";



}
