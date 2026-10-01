using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    //ActivitiesController class inherits from BaseApiController and handles HTTP requests related to activities
    public class ActivitiesController (AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //Retrieve all activities from the database asynchronously and return them as an HTTP response
            var activities = await context.Activities.ToListAsync();
            return Ok(activities);
        }

    //GetActivity method handles HTTP GET requests to retrieve a specific activity by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            //Find the activity with the specified ID in the database
            var activity = await context.Activities.FindAsync(id);
            //If the activity is not found, return a NotFound response; otherwise, return the activity as an HTTP response
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }
    }
}