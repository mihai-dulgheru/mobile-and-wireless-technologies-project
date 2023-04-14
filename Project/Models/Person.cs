using SQLite;

namespace Project.Models
{
    [Table("Person")]
    public class Person : IPerson
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }
    }
}
