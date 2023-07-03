using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisteminhaBancario.Models;

namespace SisteminhaBancario.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.HasKey(x => x.cpf);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);

            
        }
    }
}
