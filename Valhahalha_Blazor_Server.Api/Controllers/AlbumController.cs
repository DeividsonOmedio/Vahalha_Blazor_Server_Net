using Microsoft.AspNetCore.Mvc;
using Valhahalha_Blazor_Server.Api.Model;
using Valhahalha_Blazor_Server.Api.Repository.Interfaces;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbum _album;


        public AlbumController(IAlbum album)
        {
            _album = album;
        }

        [HttpGet]
        public async Task<ActionResult> GetAlbuns()
        {
            try
            {
                var result = await _album.ListarAlbus();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao retornar os dados do banco de dados");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Albun>> GetById(int id)
        {
            try
            {
                var result = await _album.GetById(id);
                if (result == null)
                    return NotFound("Id não encontrado");
                return result;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao retornar os dados do banco de dados");

            }
            
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarAlbum(Albun album)
        {
            try
            {
                if (album == null)
                {
                    return BadRequest();
                }
                var result = await _album.AdicinarAlbum(album);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao retornar os dados do banco de dados");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> DarLike(int id)
        {
            try
            {
                var result = await _album.DarLike(id);
                return Ok(result);
            }
            catch(Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao retornar os dados do banco de dados");

            }

        }
    }
}
