namespace Project.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        string Image { get; set; }
        string ImageType { get; set; }
        string Title { get; set; }
    }
}