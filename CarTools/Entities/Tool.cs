namespace CarTools.Entities;

public class Tool
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty; 
    public string Company { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Amount {  get; set; } 
}
