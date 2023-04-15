namespace Project.Models
{
    public class Ingredient
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Safety_level { get; set; }

        public Ingredient() { }

        public Ingredient(string description, string name, string safety_level)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Safety_level = safety_level ?? throw new ArgumentNullException(nameof(safety_level));
        }
    }
}
