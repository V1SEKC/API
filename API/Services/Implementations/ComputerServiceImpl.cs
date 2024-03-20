using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using AutoMapper;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Implementations
{
	public class ComputerServiceImpl : IComputerServise
	{
		private readonly IComputerRepository _computerRepository;
		private readonly IMapper _mapper;

		public ComputerServiceImpl(IComputerRepository computerRepository, IMapper mapper)
		{
			_computerRepository = computerRepository;
			_mapper = mapper;
		}

		public async Task<List<ComputerDto>> GetComputersAsync()
		{
			List<ComputerDto> dtos = new List<ComputerDto>();
			List<Computer> computers = await _computerRepository.GetAsync();
			computers.ForEach(computers => dtos.Add(_mapper.Map<ComputerDto>(computers)));
			return dtos;
		}

		public async Task<ComputerDto> GetComputerByNumberAsync([FromQuery] string number)
		{
			if (string.IsNullOrWhiteSpace(number))
			{
				throw new BadRequestException($"Поле {number} не соответствует ожидаению");
			}
		    Computer computer = _computerRepository.GetByNumber(number);

			return (new ComputerDto(computer.IsFree, computer.PricePerHour, computer.Number));
		}

		public async Task<Computer> Id(int id)
		{
			return await _computerRepository.GetByIdAsync(id);		}
	}
}
