using SisteminhaBancario.Models;

namespace SisteminhaBancario.Repositories.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<List<PessoaModel>> BuscarTodosUsuarios();

        Task<PessoaModel> BuscarPorId(int id);

        Task<PessoaModel> Adicionar(PessoaModel pessoa);
        Task<PessoaModel> Atualizar(PessoaModel pessoa, int id);

        Task<bool> Apagar(int id);
    }
}
