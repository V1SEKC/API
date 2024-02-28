namespace API.Dto
{
	public record UserDto
	{
		public int Monny { get; set; }
		public string Name { get; set; }
		public int Hors { get; set; }

		public UserDto(int monny, string name, int hors)
		{
			Monny = monny;
			Name = name;
			Hors = hors;
		}
	}
}
