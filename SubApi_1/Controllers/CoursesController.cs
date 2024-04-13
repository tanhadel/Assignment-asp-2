
using Infrastracture.Context;
using Infrastracture.Factories;
using Infrastracure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SubApi_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(DataContext dataContext) : ControllerBase
{
    private readonly DataContext _dataContext = dataContext;

    [HttpGet]
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {
        var query = _dataContext.Courses
            .Include(i => i.Category)
            .AsQueryable();

        if (!string.IsNullOrEmpty(category) && category != "all")
            query = query.Where(x => x.Category!.CategoryName == category);

        if (!string.IsNullOrEmpty(searchQuery))
            query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));

        query = query.OrderByDescending(c => c.LastUpdated);


        var totalItemCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        var courses = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();



        var result = new CoursesResult
        {

            TotalItems =  totalItemCount,
            TotalPages = totalPages,
            Courses = CourseFactory.Create(courses),


        };
     

        return Ok(result);

    }



}
