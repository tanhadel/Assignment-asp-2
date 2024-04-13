using Assignment.Models;
using Infrastracture.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Assignment.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, HttpClient http, IConfiguration configuration) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;


    #region  signup
    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }



    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {

                if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
                {
                    var userEntity = new UserEntity
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Email = viewModel.Email,
                        UserName = viewModel.Email,

                    };
                    var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn", "Auth");
                    }
                    else
                    {
                        ViewData["SatusMessage"] = "Something went wrong.Please try again.";
                    }

                }
                else
                {
                    ViewData["SatusMessage"] = "user with the same email address already exists";
                }
            }
            catch { }
        }

        return View(viewModel);
    }
    #endregion





    #region  signin
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        return View();
    }


    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Default");
                }

            }
        }

        ViewData["statusMessage"] = "Incorrect email or password ";
        return View(viewModel);
    }

    #endregion



    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        Response.Cookies.Delete("AccessToken");
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }

}



