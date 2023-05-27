namespace Project.ViewModels
{
    internal interface IHomeViewModel
    {
        string RandomFoodTrivia { get; set; }

        Task GetRandomFoodTriviaAsync();
    }
}