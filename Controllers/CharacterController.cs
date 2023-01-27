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
        public ActionResult<List<Character>> Get(){
            return Ok(_characterService.GetAllCharacters());
        }
         // Display Specific Id URL: http://localhost:6600/api/Character/1
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(_characterService.GetCharacterById(id));
        }

        
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}