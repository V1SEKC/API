using API.Models.Base;

namespace API.Models
{
	public class User : BaseModel
	{ 
		public int Monny {  get; set; }
		public string Name { get; set; }
		public int Hors { get; set; }
        public List<Apontment> Apontments { get; set; } = new List<Apontment>();
    }
}
