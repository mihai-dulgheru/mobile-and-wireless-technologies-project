using Project.Models;

namespace Project.ViewModels
{
    internal class CartesianChartViewModel
    {
        public List<Person> Data { get; set; }

        public CartesianChartViewModel()
        {
            Data = new List<Person>()
            {
                new Person { Name = "David", Height = 170 },
                new Person { Name = "Michael", Height = 96 },
                new Person { Name = "Steve", Height = 65 },
                new Person { Name = "Joel", Height = 182 },
                new Person { Name = "Bob", Height = 134 }
            };
        }

    }
}
