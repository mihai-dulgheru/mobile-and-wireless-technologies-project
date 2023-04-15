namespace Project.Models
{
    public class CaloricBreakdown
    {
        public float PercentProtein { get; set; }
        public int PercentFat { get; set; }
        public float PercentCarbs { get; set; }

        public CaloricBreakdown() { }

        public CaloricBreakdown(float percentProtein, int percentFat, float percentCarbs)
        {
            PercentProtein = percentProtein;
            PercentFat = percentFat;
            PercentCarbs = percentCarbs;
        }
    }
}
