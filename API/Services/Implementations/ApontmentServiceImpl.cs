using API.Dto;
using API.Models;
using API.Repositories;
using API.Validators;
using AutoMapper;
using ConsoleApp1.Repositories;

namespace API.Services.Implementations
{
	public class ApontmentServiceImpl : IApontmentService
	{
		private readonly IApontmentValidator _apontmentValidator;
		private readonly IUserValidator _userValidator;
		private readonly IComputerRepository _computerRepository;
		private readonly IUserRepository _userRepository;
		private readonly IApontmentRepository _apontmentRepository;
		private readonly IMapper _mapper;

		public ApontmentServiceImpl(IApontmentRepository apontmentRepository, IMapper mapper, 
			IUserRepository userRepository, IComputerRepository computerRepository, IApontmentValidator apontmentvalidator,
            IUserValidator userValidator)
		{
			_apontmentRepository = apontmentRepository;
			_mapper = mapper;
			_userRepository = userRepository;
			_computerRepository = computerRepository;
			_apontmentValidator = apontmentvalidator;
			_userValidator = userValidator;
		}
		public async Task<List<ApontmentDto>> GetApontmentAsync()
		{
			List<ApontmentDto> dtos = new List<ApontmentDto>();
			List<Apontment> apontments = await _apontmentRepository.GetAsync();
			apontments.ForEach(apontment => dtos.Add(_mapper.Map<ApontmentDto>(apontment)));
			return dtos;
		}

		public async Task<ApontmentDto> CreateApontmentAsync(ApontmentDto dto)
		{
			_apontmentValidator.ValidateApontmentDto(dto);
			User user = await _userRepository.GetByIdAsync(dto.UserId);
			Computer computer = await _computerRepository.GetByIdAsync(dto.ComputerId);
			int price = computer.PricePerHour * dto.Hors;
			_userValidator.ValidateBalance(price,user.Monny);
			user.Monny -= price;
			_apontmentRepository.Create(_mapper.Map<Apontment>(dto));
			await _apontmentRepository.SaveChangesAsync();
			await _userRepository.SaveChangesAsync();
			return dto;
		}
		
		public async Task DeleteApontmentAsync(int apontmentHors)
		{
			_apontmentValidator.ValidateApontmentHors(apontmentHors);
            var apontment = _apontmentRepository.GetByHors(apontmentHors);
			_apontmentRepository.Remove(apontment);
			await _apontmentRepository.SaveChangesAsync();
		}
	}
}