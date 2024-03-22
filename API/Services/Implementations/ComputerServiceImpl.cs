using API.Dto;
using API.Exceptions;
using API.Models;
using API.Validators;
using AutoMapper;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Implementations
{
	public class ComputerServiceImpl : IComputerServise
	{
		private readonly IComputerValidator _computerValidator;
		private readonly IComputerRepository _computerRepository;
		private readonly IMapper _mapper;

		public ComputerServiceImpl(IComputerRepository computerRepository, IMapper mapper, IComputerValidator computerValidator)
		{
			_computerRepository = computerRepository;
			_mapper = mapper;
			_computerValidator = computerValidator;
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
			_computerValidator.ValidatorGetComputerByNumber(number);
			return _mapper.Map<ComputerDto>(_computerRepository.GetByNumber(number));
		}

		public async Task<ComputerDto> GetComputerByIdAsync(int id)
		{
			_computerValidator.ValidateId(id);
			return _mapper.Map<ComputerDto>(await _computerRepository.GetByIdAsync(id));
		}
	}
}