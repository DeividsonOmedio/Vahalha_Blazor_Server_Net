using Microsoft.AspNetCore.Mvc;
using Valhahalha_Blazor_Server.Api.Model;
using Valhahalha_Blazor_Server.Api.Repository.Interfaces;
using Valhahalha_Blazor_ServerSide.Model;

namespace Valhahalha_Blazor_Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarios _comentario;

        public ComentariosController(IComentarios Icomentario)
        {
            _comentario = Icomentario;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comentari>> GetById(int id)
        {
            try
            {
                var result = await _comentario.GetById(id);
                if (result == null)
                    return NotFound("Id não encontrado");
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao retornar os dados do banco de dados");

            }

        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> PostAdicinarComentario( int id, Comentari comentario)
        {
            try
            {
                var result = await _comentario.AdicionarComentario(comentario);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao retornar os dados do banco de dados");
            }
        }

   

        
       

    }
}
