using SQLite;

namespace Project.Models
{
    [Table("Product")]
    public class Product : IProduct
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [MaxLength(250)]
        public string ImageType { get; set; }

        public Product()
        {

        }

        public Product(int id, string title, string image, string imageType)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ImageType = imageType ?? throw new ArgumentNullException(nameof(imageType));
        }
    }
}
