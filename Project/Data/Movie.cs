namespace Project.Data
{
    public class Movie
    {
        public Movie(string title, int year)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Year = year;
        }

        public string Title { get; private set; }
        public int Year { get; private set; }
    }
}
