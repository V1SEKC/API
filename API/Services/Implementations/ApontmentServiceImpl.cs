using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using API.Repositories.Implementations;
using AutoMapper;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Implementations
{
	public class ApontmentServiceImpl : IApontmentService
	{
		private readonly IApontmentRepository _apontmentRepository;
		private readonly IMapper _mapper;

		public ApontmentServiceImpl(IApontmentRepository apontmentRepository, IMapper mapper)
		{
			_apontmentRepository = apontmentRepository;
			_mapper = mapper;
		}
		public async Task<List<ApontmentDto>> GetApontmentAsync()
		{
			List<ApontmentDto> dtos = new List<ApontmentDto>();
			List<Apontment> apontments = await _apontmentRepository.GetAsync();
			apontments.ForEach(apontment => dtos.Add(_mapper.Map<ApontmentDto>(apontment)));
			return (dtos);
		}
		public async Task<ApontmentDto> CreateApontmentAsync(ApontmentDto dto)
		{
			Apontment apontment = _mapper.Map<Apontment>(dto);
			_apontmentRepository.Create(apontment);
			await _apontmentRepository.SaveChangesAsync();
			return (dto);
		}
		public async Task DeleteApontmentAsync(int apontmentHors)
		{
			var apontment = _apontmentRepository.GetByHors(apontmentHors);
			if (apontment == null)
			{
				throw new BadRequestException($"Поле не соответствует ожидаению");
			}
			_apontmentRepository.Remove(apontment);
			await _apontmentRepository.SaveChangesAsync();
			return;
		}
	}
}