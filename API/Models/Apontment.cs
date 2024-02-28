using API.Models.Base;

namespace API.Models
{
	public class Apontment : BaseModel
	{
		public int Hors { get; set; }
		public DateTime Beginning { get; set; }
		public DateTime Ending { get; set; }

	}
}
