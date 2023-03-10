using ApiProject.DTOs.Character;
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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters()); // Service Methods
        }
         // Display Specific Id URL: http://localhost:6600/api/Character/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id)); // Service Methods
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter)); // Service Methods
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null) // if Charcter not found throw 404
            {
                return NotFound(response);
            }
            return Ok(response); // Service Methods
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data is null) // if Charcter not found throw 404
            {
                return NotFound(response);
            }
            return Ok(response); // Service Methods
        }
    }
}