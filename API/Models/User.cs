using API.Models.Base;

namespace API.Models
{
	public class User : BaseModel
	{ 
		public int Monny {  get; set; }
		public string Name { get; set; }
		public int Hors { get; set; }
	}
}
