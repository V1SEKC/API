using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Dto
{
	public class ApontmentDto
	{
		public int Hors { get; set; }
		public DateTime Beginning { get; set; }
		public DateTime Ending { get; set; }

        public ApontmentDto(int hors, DateTime beginning, DateTime ending)
        {
			Hors = hors;
			Beginning = beginning;
			Ending = ending;
		}
    }
}
