using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TakeoverYourCoin;

[Route("api/[controller]")]
[ApiController]
public class ListedProjectsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly Logger<ListedProjectsController>? logger;

    public ListedProjectsController(AppDbContext context, ILogger<ListedProjectsController> logger)
    {
        _context = context;
        this.logger = (Logger<ListedProjectsController>?)logger;
    }

    // POST: api/takeovers
    [HttpPost]
    public async Task<ActionResult<ListedProject>> AddNewListedProject(ListedProject incomingProject)
    {
        try
        {

            _context.ListedProjects.Add(incomingProject); // Add the incoming project to the context
            await _context.SaveChangesAsync(); // Save the changes to the database

            logger.LogInformation($"Successfully added listing {incomingProject.ListingId} {incomingProject.ProjectName} to database at {DateTime.UtcNow.ToLongTimeString()} ");
            return CreatedAtAction(nameof(GetListedProject), new { listingId = incomingProject.ListingId }, incomingProject);
        }
        catch (Exception ex)
        {

            logger.LogError("Error deleting listing with Id {listingId}", DateTime.UtcNow.ToLongTimeString());
            return BadRequest();
        }
    }

    // POST: api/takeovers
    [HttpDelete("{listingId:int}")]
    public async Task<ActionResult<ListedProject>> RemoveListedProjectById(int listingId)
    {
        try
        {
            //fetch the listing from Db
            var listing = await _context.ListedProjects.FirstOrDefaultAsync(t => t.ListingId == listingId);
            if (listing is not null)
            {
                _context.ListedProjects.Remove(listing);

                await _context.SaveChangesAsync(); // Save the changes to the database
                
                logger.LogInformation($"Successfully deleted listing {listingId} from database at {DateTime.UtcNow.ToLongTimeString()} ");
                return Ok();
            }
            else return NotFound();
        }
        catch
        {
            logger.LogError("Error deleting listing with Id {listingId}", DateTime.UtcNow.ToLongTimeString());
            return NotFound();
        }
    }

    [HttpGet("{listingId:int}")]
    public async Task<ActionResult<ListedProject>> GetListedProject(int listingId)
    {
        // Search for the project using FirstOrDefaultAsync, since listingId is not the primary key
        var listedProject = await _context.ListedProjects
            .FirstOrDefaultAsync(p => p.ListingId == listingId);

        if (listedProject == null)
        {
            return NotFound(); // Return 404 if not found
        }

        return Ok(listedProject); // Return the project with a 200 OK response
    }

    // GET: api/takeovers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ListedProject>>> GetAllListedProjects()
    {
        return await _context.ListedProjects.ToListAsync();
    }
}
