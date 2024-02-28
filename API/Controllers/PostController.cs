using API.Data;
using API.Dto;
using API.Migrations;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController
	{
		private readonly IApontmentRepository _apontmentRepository;

		public ApontmentController(IApontmentRepository apontmentRepository)
		{
			_apontmentRepository = apontmentRepository;
		}

		[HttpGet]
		public ActionResult<List<ApontmentDto>> GetApontmen()
		{
			List<ApontmentDto> apontment = new List<ApontmentDto>();
			_apontmentRepository.Get().ForEach(apontment =>
				apontment.Add(new ApontmentDto()
				{ 
					Hors = apontment.Hors,
					Beginning = apontment.Beginning,
					Ending = apontment.Ending
				}));
			return Ok(apontment);
		}

		[HttpPost]
		public ActionResult<ApontmentDto> CreateApontment([FromBody] ApontmentDto Dto)
		{
			Apontment apontment = new Apontment()
			{ 
				Hors = Dto.Hors,
				Beginning = Dto.Beginning,
				Ending = Dto.Ending
			};

			_apontmentRepository.Create(apontment);
			_apontmentRepository.SaveChanges();
			return Ok(apontment);

		}

		[HttpDelete("{ApontmentHors}")]
		public ActionResult<string> DeleteApontment([FromRoute] int apontmentHors)
		{
			var apontment = _apontmentRepository.Remove(apontmentHors);
			if (apontment == null)
			{
				return NotFound();
			}
			_apontmentRepository.Delete(apontment);
			_apontmentRepository.SaveChanges();
			return Ok("Успешно");
		}

	}

}
