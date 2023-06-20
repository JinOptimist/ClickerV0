using ClickerWeb.DAL.Models;

namespace ClickerWeb.DAL
{
    public class SeedDatabase
    {
        public void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var webContext = scope.ServiceProvider.GetService<WebContext>();

                var levelRulesCount = webContext.LevelRules.Count(x => x.Level == 1);
                if (levelRulesCount == 0)
                {
                    var firstLeveRule = new LevelRule
                    {
                        Name = "Trainee",
                        Level = 1,
                        LearningStepSize = 1,
                        ExpSalaryRate = 2,
                    };
                    webContext.LevelRules.Add(firstLeveRule);
                    webContext.SaveChanges();
                }
            }
        }
    }
}
