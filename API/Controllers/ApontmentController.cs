using API.Dto;
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
			_apontmentRepository.Get().ForEach(apontment => dtos.Add(new ApontmentDto(apontment.Hors, apontment.Beginning, apontment.Ending)));
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
            var apontment = _apontmentRepository.GetByHors(apontmentHors);
            if (apontment == null)
            {
                return NotFound();
            }
            _apontmentRepository.Remove(apontment);
            _apontmentRepository.SaveChanges();
            return NoContent();
        }
    }
}

//Добавить связь между заявкой и пользователем с пк
//добавить ксатомные исключеня добавить глобальную обработку исключений 
// в дто кидаю айди пользователя от его лица
//Рест апи и следователь сооап

//Дто имя пользователя + мани => ищем в репозитории. Обращаемся к мани += Дто.мани сохранить изменения  Пут запрос на обенавление 