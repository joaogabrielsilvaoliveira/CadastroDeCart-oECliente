using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisteminhaBancario.Models;
using SisteminhaBancario.Repositories.Interfaces;

namespace SisteminhaBancario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cartaoController : ControllerBase
    {

        private readonly IcartaoRepositorio _cartaoRepositorio;

        public cartaoController(IcartaoRepositorio cartaoRepositorio)
        {
            _cartaoRepositorio = cartaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<cartaoModel>>> BuscarTodosCartoes()
        {
            List<cartaoModel> Cartao = await _cartaoRepositorio.BuscarTodosCartoes();
            return Ok(Cartao);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<cartaoModel>> BuscarPorId(int id)
        {
            cartaoModel cartao = await _cartaoRepositorio.BuscarPorId(id);
            return Ok(cartao);
        }

        [HttpPost]
        public async Task<ActionResult<cartaoModel>> Cadastrar([FromBody] cartaoModel cartaoModel)
        {
            cartaoModel cartao = await _cartaoRepositorio.Adicionar(cartaoModel);
            return Ok(cartao);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<cartaoModel>> Atualizar([FromBody] cartaoModel cartaoModel, int id)
        {
            cartaoModel.Id = id;
            cartaoModel cartao = await _cartaoRepositorio.Atualizar(cartaoModel, id);
            return Ok(cartao);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<cartaoModel>> Apagar(int id)
        {

            bool apagado = await _cartaoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
