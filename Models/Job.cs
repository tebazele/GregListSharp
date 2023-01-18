namespace gregSharp.Models;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public bool FullTime { get; set; }
    public int? HourlyRate { get; set; }
    public string ImgURL { get; set; }
    public string Description { get; set; }

}
