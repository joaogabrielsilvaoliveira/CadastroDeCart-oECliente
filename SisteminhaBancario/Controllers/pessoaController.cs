using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisteminhaBancario.Models;
using SisteminhaBancario.Repositories.Interfaces;

namespace SisteminhaBancario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pessoaController : ControllerBase
    {

        private readonly IPessoaRepositorio _pessoaRepositorio;

        public pessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodosUsuarios()
        {
            List<PessoaModel> Pessoa = await _pessoaRepositorio.BuscarTodosUsuarios();
            return Ok(Pessoa);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPorId(int id)
        {
            PessoaModel Pessoa = await _pessoaRepositorio.BuscarPorId(id);
            return Ok(Pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel pessoa = await _pessoaRepositorio.Adicionar(pessoaModel);
            return Ok(pessoa);
        }
        [HttpPut("{id}")]
     public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel pessoaModel, int id)
        {
            pessoaModel.cpf = id;
            PessoaModel pessoa = await _pessoaRepositorio.Atualizar(pessoaModel, id);
            return Ok(pessoa);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<PessoaModel>> Apagar(int id)
        {
     
            bool apagado = await _pessoaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
