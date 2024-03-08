using API.Models.Base;

namespace API.Models
{
	public class Computer : BaseModel
	{
		public bool IsFree { get; set; }
		public int PricePerHour { get; set; }
		public string Number {  get; set; }
		public List<Apontment> Apontments { get; set; } = new List<Apontment>();
	}
}
