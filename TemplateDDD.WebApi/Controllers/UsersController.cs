using System.Net;
using TemplateDDD.Domain.Interfaces.Services;
using TemplateDDD.Domain.Views;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDDD.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //Todo: Tirar o comentario abaixo quando precisar usar autenticação
        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserView>>> GetAll()
        {
            //Usado para verificar se os paramentros que foram passados condizem com minha classe 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 bad resquest - solicitação inválida
            }

            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (ArgumentException ex) //ArgumentException bom para tratar erros de argumentos 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}", Name = "GetId")]
        public async Task<ActionResult<UserView>> GetId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _userService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<UserView>> Post([FromBody] UserView user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var retorno = await _userService.Post(user);
                if (retorno != null)
                {
                    return Created(nameof(GetId), retorno);
                }
                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserView user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var retorno = await _userService.Put(user);
                if (retorno != null)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var retorno = await _userService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}