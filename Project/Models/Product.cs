using SQLite;

namespace Project.Models
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(250)]
        [Column("title")]
        public string Title { get; set; }

        [MaxLength(250)]
        [Column("image")]
        public string Image { get; set; }

        [MaxLength(250)]
        [Column("image_type")]
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
