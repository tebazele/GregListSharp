namespace gregSharp.Services;

public class JobsService
{
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
        _repo = repo;
    }

    internal Job Create(Job jobData)
    {
        Job job = _repo.Create(jobData);
        return job;
    }
}
