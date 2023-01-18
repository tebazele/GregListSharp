namespace gregSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService)
    {
        _jobsService = jobsService;
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job jobData)
    {
        try
        {
            Job job = _jobsService.Create(jobData);
            return Ok(job);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
