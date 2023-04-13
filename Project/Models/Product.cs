namespace Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }

        public Product(int id, string title, string image, string imageType)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ImageType = imageType ?? throw new ArgumentNullException(nameof(imageType));
        }
    }
}
