using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using AutoMapper;

namespace API.Services.Implementations
{
	//Сделать валидатор
	public class ApontmentServiceImpl : IApontmentService
	{
		// добавить два репозитория
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
			return dtos;
		}

		//Решить проблему NotFound для компьютера и пользователя
		public async Task<ApontmentDto> CreateApontmentAsync(ApontmentDto dto)
		{
			//Перевести на GetById
			User user = new User();
			Computer computer = new Computer();
			int price = computer.PricePerHour * dto.Hors;
			//вынести в валидатор
			if (price > user.Monny)
			{
				// выкинуть BadRequestException
			}
			//Уменьшить баланс пользователя на Price
			_apontmentRepository.Create(_mapper.Map<Apontment>(dto));
			await _apontmentRepository.SaveChangesAsync();
			//Вызвать метод сохранения у репозитория пользователей
			return dto;
		}
		
		public async Task DeleteApontmentAsync(int apontmentHors)
		{
            // Вынести в валидатор
            if (apontmentHors <= 0)
            {
                throw new BadRequestException($"Поле не соответствует ожидаению");
            }
            var apontment = _apontmentRepository.GetByHors(apontmentHors);
			_apontmentRepository.Remove(apontment);
			await _apontmentRepository.SaveChangesAsync();
		}
	}
}