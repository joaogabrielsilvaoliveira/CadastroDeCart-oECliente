using Microsoft.EntityFrameworkCore;
using SisteminhaBancario.Data.Map;
using SisteminhaBancario.Models;
using System.Security.Cryptography.X509Certificates;

namespace SisteminhaBancario.Data
{
    public class SistemaBancarioDBContex : DbContext
    {
        public SistemaBancarioDBContex(DbContextOptions<SistemaBancarioDBContex> options)
            : base(options)
        {
        }

            public DbSet<PessoaModel> Pessoa { get; set; }
            public DbSet<cartaoModel> Cartao { get; set; }

           public DbSet<contaModel> Conta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new cartaoMap());


            base.OnModelCreating(modelBuilder);
        }
    }
    }

