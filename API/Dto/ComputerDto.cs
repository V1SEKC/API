namespace API.Dto
{
	public record ComputerDto
	{
		public bool IsFree { get; set; }
        public int PricePerHour { get; set; }
		public string Number { get; set; }

		public ComputerDto(bool isFree, int pricePerHour, string number)
		{
			IsFree = isFree;
			PricePerHour = pricePerHour;
			Number = number;
		}
	}
}
