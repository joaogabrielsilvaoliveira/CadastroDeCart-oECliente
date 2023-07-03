using SisteminhaBancario.Models;

namespace SisteminhaBancario.Repositories.Interfaces
{
    public interface IcartaoRepositorio
    {
        Task<List<cartaoModel>> BuscarTodosCartoes();
        Task<cartaoModel> BuscarPorId(int id);
        Task<cartaoModel> Adicionar(cartaoModel cartao);
        Task<cartaoModel> Atualizar(cartaoModel cartao, int id);
        Task<bool> Apagar(int id);
    }
}
