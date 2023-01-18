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

    internal List<Job> Get()
    {
        List<Job> jobs = _repo.Get();
        return jobs;
    }

    internal Job Get(int id)
    {
        Job job = _repo.Get(id);
        return job;
    }

    internal string Remove(int id)
    {
        Job foundJob = Get(id);
        bool deleted = _repo.Remove(id);
        if (deleted == false)
        {
            throw new Exception("no job was deleted");
        }
        return $"{foundJob.Title} was deleted";
    }

    internal Job Update(Job jobData, int id)
    {
        Job original = Get(id);
        original.Company = jobData.Company ?? original.Company;
        original.Description = jobData.Description ?? original.Description;
        original.FullTime = jobData.FullTime ?? original.FullTime;
        original.HourlyRate = jobData.HourlyRate ?? original.HourlyRate;
        original.ImgURL = jobData.ImgURL ?? original.ImgURL;
        original.Title = jobData.Title ?? original.Title;

        bool edited = _repo.Update(original);
        if (edited == false)
        {
            throw new Exception("Job was not actually updated");
        }
        return original;
    }
}
