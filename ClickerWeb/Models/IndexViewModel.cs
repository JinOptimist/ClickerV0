﻿namespace ClickerWeb.Models
{
    public class IndexViewModel
    {
        public string UserName { get; set; }
        public string CurrentLevelName { get; set; }
        public int Exp { get; set; }
        public int Coins { get; set; }
        public string ImageUrl { get; set; }

        public List<LevelDetailViewModel> LevelDetails { get; set; } = new List<LevelDetailViewModel>();
    }
}
