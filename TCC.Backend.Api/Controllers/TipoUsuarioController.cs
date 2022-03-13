using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TCC.Backend.Application.Models;
using TCC.Backend.Domain.Repositories;

namespace TCC.Backend.Api.Controllers
{
    [ApiController]
    [Route("tipos-usuario")]
    public class TipoUsuarioController : ApiBaseController
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var usuario = await _tipoUsuarioRepository.Listar();
            if (usuario == null)
                return NotFound();

            return Ok();
        }
    }
}
