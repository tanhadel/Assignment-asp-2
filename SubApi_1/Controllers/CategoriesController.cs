
using Infrastracture.Context;
using Infrastracture.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SubApi_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(DataContext dataContext) : ControllerBase
{

   
    private readonly DataContext _dataContext = dataContext;
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _dataContext.Categories.OrderBy(o => o.CategoryName).ToListAsync();
        return Ok (CategoryFactory.Create(categories));
    }
}
