using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApontmentController : ControllerBase
	{
		private readonly IApontmentRepository _apontmentRepository;

		public ApontmentController(IApontmentRepository apontmentRepository)
		{
			_apontmentRepository = apontmentRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<ApontmentDto>>> GetApontment()
		{
			List<ApontmentDto> dtos = new List<ApontmentDto>();
			List<Apontment> apontments = await _apontmentRepository.GetAsync();
			apontments.ForEach(apontment => dtos.Add(new ApontmentDto(apontment.Hors, apontment.Beginning, apontment.Ending)));
			return Ok(dtos);
		}

        [HttpPost]
        public async Task<ActionResult<ApontmentDto>> CreateApontment([FromBody] ApontmentDto dto)
        {
            Apontment apontment = new Apontment(dto);
            _apontmentRepository.Create(apontment);
            _apontmentRepository.SaveChanges();
            return Ok(apontment);
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
            _apontmentRepository.SaveChanges();
            return NoContent();
        }

		//TODO убрать
		public Apontment Hors(int hors)
		{
			if(int.IsPow2(hors))
					throw new BadRequestException($"Поле {hors} не соответствует ожидаению");
			return (hors);
		}

	}
}

//Добавить связь между заявкой и пользователем с пк
//добавить ксатомные исключеня добавить глобальную обработку исключений 
// в дто кидаю айди пользователя от его лица
//Рест апи и следователь сооап

//Дто имя пользователя + мани => ищем в репозитории. Обращаемся к мани += Дто.мани сохранить изменения  Пут запрос на обенавление 