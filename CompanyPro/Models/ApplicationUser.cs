using Microsoft.AspNetCore.Identity;

namespace CompanyPro.Models
{
    
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
