using Assignment.Models;
using Assignment.Services;
using Infrastracure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers;

public class AccountController(AccountService accountService) : Controller
{
    private readonly AccountService _accountService = accountService;

    public async Task<IActionResult> Details()
    {
        var user = await _accountService.GetUserAsync(User);

        var viewModel = new AccountdetailsViewModel
        {
            BasicInfo = new AccountBasicInfo
            {
                FirstName= user.FirstName!,
                LastName= user.LastName!,
                Email = user.Email,
                PhoneNumber=user.PhoneNumber!,
                Bio= user.Bio!,
            
            },
            AddressInfo = new AccountAddressInfo
            {
              Adress_1=user.AddressLine_1!,
              Adress_2 = user.AddressLine_2!,
              PostalCode= user.PostalCode!,
              City= user.City!,
              

            }
        };

        return View(viewModel);
    }



    [HttpPost]
    public async Task <IActionResult>UpdateBasicInfo(AccountdetailsViewModel model)
    {
        if (model.BasicInfo != null)
        {
            if (!string.IsNullOrEmpty(model.BasicInfo.FirstName)&& !string.IsNullOrEmpty(model.BasicInfo.LastName))
            {              
                var result = await _accountService.UpdateBasicInfoAsync(User, model.BasicInfo);


            }

        }
        return RedirectToAction("Details", "Account");
    }


    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountdetailsViewModel model)
    {
        if (model.AddressInfo != null)                  
        {
            if (!string.IsNullOrEmpty(model.AddressInfo.Adress_1)&&!string.IsNullOrEmpty(model.AddressInfo.PostalCode)&&!string.IsNullOrEmpty(model.AddressInfo.City))
            {
                var result = await _accountService.UpdateAddressInfoAsync(User,model.AddressInfo);
            }
        }
        return RedirectToAction("Details", "Account");
    }


    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);
        return RedirectToAction("Details", "Account");
    }
}



           
       


        



   



