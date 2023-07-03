using Microsoft.EntityFrameworkCore;
using SisteminhaBancario.Data;
using SisteminhaBancario.Models;
using SisteminhaBancario.Repositories.Interfaces;

namespace SisteminhaBancario.Repositories
{
    public class cartaoRepositorio : IcartaoRepositorio
    {
        private readonly SistemaBancarioDBContex _dbContext;
        public cartaoRepositorio(SistemaBancarioDBContex sistemaBancarioDBContex)
        {
            _dbContext = sistemaBancarioDBContex;
        }
        public async Task<cartaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Cartao.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<cartaoModel>> BuscarTodosCartoes()
        {
            return await _dbContext.Cartao.ToListAsync();
        }
        public async Task<cartaoModel> Adicionar(cartaoModel cartao)
        {
            await _dbContext.Cartao.AddAsync(cartao);
            await _dbContext.SaveChangesAsync();

            return cartao;
        }
        public async Task<cartaoModel> Atualizar(cartaoModel cartao, int id)
        {
            cartaoModel CartaoPorId = await BuscarPorId(id);

            if (CartaoPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }

            CartaoPorId.numero_cartao = cartao.numero_cartao;
            CartaoPorId.Id = cartao.Id;
            CartaoPorId.data_validade = cartao.data_validade;
            CartaoPorId.codigo_seguranca = cartao.codigo_seguranca;
            
            

            _dbContext.Cartao.Update(CartaoPorId);
            await _dbContext.SaveChangesAsync();

            return CartaoPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            cartaoModel CartaoPorId = await BuscarPorId(id);

            if (CartaoPorId == null)
            {
                throw new Exception($"Cartão de : {id} não foi encontrado");
            }
            _dbContext.Cartao.Remove(CartaoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<List<cartaoModel>> BuscarCartao()
        {
            throw new NotImplementedException();
        }
    }
}
