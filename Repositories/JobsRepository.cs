namespace gregSharp.Repositories;

public class JobsRepository
{
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Job Create(Job jobData)
    {
        string sql = @"
        INSERT INTO jobs
        (title, company, fullTime, hourlyRate, imgUrl, description)
        VALUES
        (@title, @company, @fullTime, @hourlyRate, @imgUrl, @description);

        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, jobData);
        jobData.Id = id;
        return jobData;
    }
}
