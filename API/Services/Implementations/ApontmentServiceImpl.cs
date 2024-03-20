using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using API.Validators;
using API.Validators.Base;
using AutoMapper;
using ConsoleApp1.Repositories;

namespace API.Services.Implementations
{
	//Сделать валидатор
	public class ApontmentServiceImpl : IApontmentService
	{
		// добавить два репозитория
		private readonly IApontmentValidator _apontmentValidator;
		private readonly IComputerRepository _computerRepository;
		private readonly IUserRepository _userRepository;
		private readonly IApontmentRepository _apontmentRepository;
		private readonly IMapper _mapper;

		public ApontmentServiceImpl(IApontmentRepository apontmentRepository, IMapper mapper, 
			IUserRepository userRepository, IComputerRepository computerRepository, IApontmentValidator apontmentvalidator)
		{
			_apontmentRepository = apontmentRepository;
			_mapper = mapper;
			_userRepository = userRepository;
			_computerRepository = computerRepository;
			_apontmentValidator = apontmentvalidator;
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
			// Я забыл что означает это 
			if (dto.UserId < 0 | dto.ComputerId < 0)
			{
				throw new NotFoundException($"Поле Money или UserName не соответствует ожидаению");
			}
			User user = _userRepository.GetByIdAsync(dto.UserId);
			Computer computer = _computerRepository.GetByIdAsync(id);
			int price = computer.PricePerHour * dto.Hors;
			//вынести в валидатор
			if (price > user.Monny)
			{
				throw new BadRequestException($"На балансе не достаточно средств");
			}
			//Уменьшить баланс пользователя на Price
			user.Monny = user.Monny - price;
			_apontmentRepository.Create(_mapper.Map<Apontment>(dto));
			await _apontmentRepository.SaveChangesAsync();
			//Вызвать метод сохранения у репозитория пользователей
			await _userRepository.SaveChangesAsync();
			return dto;
		}
		
		public async Task DeleteApontmentAsync(int apontmentHors)
		{
			// Вынести в валидатор
			_apontmentValidator.ValidatorDeleteApontment(apontmentHors);
            var apontment = _apontmentRepository.GetByHors(apontmentHors);
			_apontmentRepository.Remove(apontment);
			await _apontmentRepository.SaveChangesAsync();
		}
	}
}