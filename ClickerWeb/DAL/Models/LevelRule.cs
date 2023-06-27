namespace ClickerWeb.DAL.Models
{
    public class LevelRule
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int LearningStepSize { get; set; }
        public int ExpSalaryRate { get; set; }
        public int MinExp { get; set; }
        public string? LevelImageUrl { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
