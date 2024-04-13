

using Infrastracture.Entities;
using Infrastracure.Models;

namespace Infrastracure.Factories;

public class UserFactory
{
    public static User Create(UserEntity userEntity)
    {
        try
        {
            return new User
            {


                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email!,
                UserName = userEntity.Email!,
                PhoneNumber = userEntity.PhoneNumber,
                AddressLine_1 = userEntity.Address?.AddressLine_1,
                AddressLine_2 = userEntity.Address?.AddressLine_2,
                PostalCode = userEntity.Address?.PostalCode,
                City = userEntity.Address?.City,




            };
        }
        catch { }
        return null!;
    }



}
