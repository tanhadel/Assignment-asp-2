using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubApi_1.Contexts;
using SubApi_1.Entities;
using SubApi_1.Models;
using System;

namespace SubApi_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(ApiSubContext apiSubContext) : ControllerBase
{

    private readonly ApiSubContext _apiSubContext = apiSubContext;


    [HttpPost]


    public async Task<IActionResult> Create(SubcribeForm form)
    {
        if (ModelState.IsValid)
        {

            if (!await _apiSubContext.Subscribers.AnyAsync(x => x.Email == form.Email))
            {


                var entity = new SubEntity
                {
                    Email = form.Email,
                    DailyNewsletter = form.DailyNewsletter,
                    WeekInReview = form.WeekInReview,
                    EventUpdates = form.EventUpdates,
                    StartupsWeekly = form.StartupsWeekly,
                    Podcasts = form.Podcasts,

                };

                _apiSubContext.Subscribers.Add(entity);
                await _apiSubContext.SaveChangesAsync();
                return Created("", null);
            }

            return Conflict();

        }
        return BadRequest();
    }
}
