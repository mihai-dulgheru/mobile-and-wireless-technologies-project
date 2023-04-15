namespace Project.Models
{
    public class Ingredient
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string SafetyLevel { get; set; }

        public Ingredient() { }

        public Ingredient(string description, string name, string safetyLevel)
        {
            Description = description;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            SafetyLevel = safetyLevel;
        }
    }
}
