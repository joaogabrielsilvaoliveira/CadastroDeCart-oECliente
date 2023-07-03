using Microsoft.EntityFrameworkCore;
using SisteminhaBancario.Data;
using SisteminhaBancario.Models;
using SisteminhaBancario.Repositories.Interfaces;

namespace SisteminhaBancario.Repositories
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly SistemaBancarioDBContex _dbContext;
        public PessoaRepositorio(SistemaBancarioDBContex sistemaBancarioDBContex)
        {
            _dbContext = sistemaBancarioDBContex;
        }
        public async Task<PessoaModel> BuscarPorId(int id)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.cpf == id);
        }
        public async Task<List<PessoaModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }
        public async Task<PessoaModel> Adicionar(PessoaModel pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }
        public async Task<PessoaModel> Atualizar(PessoaModel pessoa, int id)
        {
            PessoaModel pessoaPorId = await BuscarPorId(id);
            
            if (pessoaPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }

            pessoaPorId.Nome= pessoa.Nome;
            pessoaPorId.cpf = pessoa.cpf;

            _dbContext.Pessoa.Update(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return pessoaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            PessoaModel pessoaPorId = await BuscarPorId(id);

            if (pessoaPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }
            _dbContext.Pessoa.Remove(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        

        

        
    }
}
