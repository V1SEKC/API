using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApontmentController : ControllerBase
	{
		private readonly IApontmentRepository _apontmentRepository;
		private readonly IMapper _mapper;
		
		public ApontmentController(IApontmentRepository apontmentRepository, IMapper mapper)
		{
			_apontmentRepository = apontmentRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<ApontmentDto>>> GetApontment()
		{
			List<ApontmentDto> dtos = new List<ApontmentDto>();
			List<Apontment> apontments = await _apontmentRepository.GetAsync();
			apontments.ForEach(apontment => dtos.Add(_mapper.Map<ApontmentDto>(apontment)));
			return Ok(dtos);
		}

        [HttpPost]
        public async Task<ActionResult<ApontmentDto>> CreateApontment([FromBody] ApontmentDto dto)
        {
			Apontment apontment = _mapper.Map<Apontment>(dto);
			_apontmentRepository.Create(apontment);
            await _apontmentRepository.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpDelete("{ApontmentHors}")]
        public async Task<ActionResult> DeleteApontment([FromRoute] int apontmentHors)
        {
            //Добавить проверку для apontmentHors
            var apontment = _apontmentRepository.GetByHors(apontmentHors);
            //Убрать
			if (apontment == null)
            {
				throw new BadRequestException($"Поле не соответствует ожидаению");
			}
            _apontmentRepository.Remove(apontment);
            await _apontmentRepository.SaveChangesAsync();
            return NoContent();
        }
	}
}

//Добавить связь между заявкой и пользователем с пк
//добавить ксатомные исключеня добавить глобальную обработку исключений 
// в дто кидаю айди пользователя от его лица
//Рест апи и следователь сооап

//Дто имя пользователя + мани => ищем в репозитории. Обращаемся к мани += Дто.мани сохранить изменения  Пут запрос на обенавление 