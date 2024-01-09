using Microsoft.AspNetCore.Identity;

namespace ShopCore.Domain
{
	public class ApplicationUser : IdentityUser
	{
		public string City { get; set; }
	}
}
