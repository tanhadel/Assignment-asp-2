
using Infrastracture.Context;
using Infrastracture.Entities;
using Infrastracure.Entities;
using Infrastracure.Factories;
using Infrastracure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Assignment.Services;

public class AccountService(UserManager<UserEntity> userManager, IConfiguration configuration, DataContext dataContext)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly DataContext _dataContext = dataContext;

    public async Task<User>GetUserAsync (ClaimsPrincipal claimsPrincipal)
    {

        var nameIdentifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var userEntity = await _dataContext.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifer);
        if (userEntity != null)
        {

            return UserFactory.Create(userEntity);
        }
        return null!;
    }  
    
    public async Task<bool>UpdateBasicInfoAsync(ClaimsPrincipal claimsPrincipal, AccountBasicInfo basicInfo)
    {
        try
        {
            var nameIdentifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id==nameIdentifer);
            if ( userEntity != null )
            {
                userEntity.FirstName = basicInfo.FirstName;
                userEntity.LastName = basicInfo.LastName;
                userEntity.PhoneNumber=basicInfo.PhoneNumber;
                userEntity.Bio=basicInfo.Bio;


                _dataContext.Update(userEntity);
                await _dataContext.SaveChangesAsync();
                return true;

            }
        }
        catch (Exception ex) { }
        return false;
    }


    public async Task<bool> UpdateAddressInfoAsync(ClaimsPrincipal claimsPrincipal, AccountAddressInfo addressInfo)
    {
        try
        {
            var nameIdentifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _dataContext.Users.Include(i=> i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifer);
            if (userEntity!.Address != null)
            {
                userEntity.Address.AddressLine_1= addressInfo.Adress_1;
                userEntity.Address.AddressLine_2= addressInfo.Adress_2;
                userEntity.Address.PostalCode= addressInfo.PostalCode;
                userEntity.Address.City = addressInfo.City;

            }
            else
            {

                userEntity.Address = new AddressEntity
                {
                    AddressLine_1 = addressInfo.Adress_1,
                    AddressLine_2 = addressInfo.Adress_2,
                    PostalCode = addressInfo.PostalCode,
                    City = addressInfo.City,
                };
            }
            _dataContext.Update(userEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { }
        return false;
    }


    public async Task <bool> UploadUserProfileImageAsync(ClaimsPrincipal userCliams, IFormFile file)
    {
        
        try
        {
            if (userCliams != null && file!=null &&file.Length!=0)
            {
                
                 var user = await _userManager.GetUserAsync (userCliams);
                if (user != null)
                {
                    var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FilePaths:ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream (filePath, FileMode.Create);
                    await file.CopyToAsync (fs);

                    user.ProfileImage = fileName;
                    _dataContext.Update (user);
                    await _dataContext.SaveChangesAsync();

                    return true;


                }                           

            }


        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return false;
    }


}

