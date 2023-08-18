using Microsoft.AspNetCore.Identity;

namespace ClickerWeb.DAL.Models
{
    public class User : IdentityUser
    {
        public int Exp { get; set; }
        public int Coins { get; set; }
    }
}
