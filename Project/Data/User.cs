using SQLite;

namespace Project.Data
{
    [Table("user")]
    internal class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Username { get; set; }

        public User()
        {
        }

        public User(int id, string username)
        {
            Id = id;
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
