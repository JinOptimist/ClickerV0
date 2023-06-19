namespace DAL.Models
{
    public class LevelRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int InitialExp { get; set; }
        public int ExpSalaryRate { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
