using API.Dto;
using API.Models.Base;

namespace API.Models
{
	public class Apontment : BaseModel
	{
		public int Hors { get; set; }
		public DateTime Beginning { get; set; }
		public DateTime Ending { get; set; }
		public int ComputerId { get; set; }
		public int UserId { get; set; }
		public Computer Computer { get; set; }
		public User User { get; set; }

		public Apontment() { }
	
		public Apontment(int hors, DateTime beginiing, DateTime ending)
		{
			Hors = hors;
			Beginning = beginiing;
			Ending = ending;
		}

		public Apontment(ApontmentDto apontment)
		{
			Hors = apontment.Hors;
			Beginning = apontment.Beginning;
			Ending = apontment.Ending;
		}

    }
}
