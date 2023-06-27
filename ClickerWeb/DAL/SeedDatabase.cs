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

                if (!webContext.LevelRules.Any(x => x.Level == 1))
                {
                    var firstLeveRule = new LevelRule
                    {
                        Name = "Trainee",
                        Level = 1,
                        LearningStepSize = 1,
                        ExpSalaryRate = 1,
                        LevelImageUrl = "/images/L0.png",
                        MinExp = 0,
                    };
                    webContext.LevelRules.Add(firstLeveRule);
                    webContext.SaveChanges();
                }

                if (!webContext.LevelRules.Any(x => x.Level == 2))
                {
                    var firstLeveRule = new LevelRule
                    {
                        Name = "Junior",
                        Level = 2,
                        LearningStepSize = 2,
                        ExpSalaryRate = 2,
                        LevelImageUrl = "/images/L1.png",
                        MinExp = 10,
                    };
                    webContext.LevelRules.Add(firstLeveRule);
                    webContext.SaveChanges();
                }

                if (!webContext.LevelRules.Any(x => x.Level == 3))
                {
                    var firstLeveRule = new LevelRule
                    {
                        Name = "Middle",
                        Level = 3,
                        LearningStepSize = 4,
                        ExpSalaryRate = 4,
                        LevelImageUrl = "/images/L2.png",
                        MinExp = 40,
                    };
                    webContext.LevelRules.Add(firstLeveRule);
                    webContext.SaveChanges();
                }
            }
        }
    }
}
