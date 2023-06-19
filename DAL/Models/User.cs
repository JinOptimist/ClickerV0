using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public virtual LevelRule? CurrentLevel { get; set; }
    }
}
