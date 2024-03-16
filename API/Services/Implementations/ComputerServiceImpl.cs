using API.Dto;
using API.Models;
using API.Repositories;
using ConsoleApp1.Repositories;

namespace API.Services.Implementations
{
	public class ComputerServiceImpl : IComputerServise
	{
		private readonly IComputerRepository _computerRepository;

		public ComputerServiceImpl(IComputerRepository computerRepository)
		{
			_computerRepository = computerRepository;
		}

		public async Task<List<ComputerDto>> GetComputersAsync()
		{
			List<ComputerDto> dtos = new List<ComputerDto>();
			List<Computer> computers = await _computerRepository.GetAsync();
			computers.ForEach(computers => dtos.Add(new ComputerDto(computers.IsFree, computers.PricePerHour, computers.Number)));
			return dtos;
		}
	}
}
