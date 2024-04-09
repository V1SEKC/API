using API.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
	public class User : IdentityUser<int>
	{ 
		public int Monny {  get; set; }
		public string Name { get; set; }
		public int Hors { get; set; }
        public List<Apontment> Apontments { get; set; } = new List<Apontment>();

		internal static Task<object?> FirstOrDefault(Func<object, bool> value)
		{
			throw new NotImplementedException();
		}
	}
}
