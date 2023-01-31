using ApiProject.Models;
using ApiProject.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        // Constructor
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        //http://localhost:6600/api/Character/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Character>>> Get(){
            return Ok(await _characterService.GetAllCharacters()); // Service Methods
        }
         // Display Specific Id URL: http://localhost:6600/api/Character/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id)); // Service Methods
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter)); // Service Methods
        }
    }
}