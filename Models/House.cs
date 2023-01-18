namespace gregSharp.Models;

public class House
{
    public int Id { get; set; }
    public int? squareft { get; set; }
    public int? bedrooms { get; set; }
    public int? bathrooms { get; set; }
    public string description { get; set; }
    public string imgUrl { get; set; }
    public string address { get; set; }
    public double? price { get; set; }

}
