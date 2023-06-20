using ClickerWeb.DAL;
using ClickerWeb.DAL.Models;
using ClickerWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClickerWeb.Controllers
{
    [ApiController]
    [Route("/api/Level")]
    public class ApiLevelController : Controller
    {
        private WebContext _webContext;

        public ApiLevelController(WebContext webContext)
        {
            _webContext = webContext;
        }

        [Route("GetDetail")]
        public LevelDetailViewModel GetDetail(int level)
        {
            var levelInfo = _webContext.LevelRules.Single(x => x.Level == level);

            var viewModel = new LevelDetailViewModel
            {
                Name = levelInfo.Name,
                ExpSalaryRate = levelInfo.ExpSalaryRate,
                LearningStepSize = levelInfo.LearningStepSize,
                Level = level
            };

            return viewModel;
        }
    }
}
