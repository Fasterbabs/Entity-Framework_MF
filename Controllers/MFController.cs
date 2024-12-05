using Entity_Framework_MF.Data;
using Entity_Framework_MF.DTOs;
using Entity_Framework_MF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_MF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MFController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public MFController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
            };

            var backpack = new Backpack { Description = request.Backpack.Description, Character = newCharacter };

            newCharacter.Backpack = backpack;

            _dataContext.Characters.Add(newCharacter);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Characters.Include(c => c.Backpack).ToListAsync());
        }
    }
}
