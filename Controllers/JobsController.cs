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

    [HttpGet]
    public ActionResult<List<Job>> Get()
    {
        try
        {
            List<Job> jobs = _jobsService.Get();
            return jobs;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
        try
        {
            Job job = _jobsService.Get(id);
            return job;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Update([FromBody] Job jobData, int id)
    {
        try
        {
            Job updatedJob = _jobsService.Update(jobData, id);
            return updatedJob;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Remove(int id)
    {
        try
        {
            string message = _jobsService.Remove(id);
            return message;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
