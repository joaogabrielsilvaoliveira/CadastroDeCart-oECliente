using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisteminhaBancario.Models;

namespace SisteminhaBancario.Data.Map
{
    public class cartaoMap : IEntityTypeConfiguration<cartaoModel>
    {
        public void Configure(EntityTypeBuilder<cartaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.cpf_pessoa).IsRequired().HasMaxLength(255);
            builder.Property(x => x.numero_cartao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.data_validade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.codigo_seguranca).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PessoaId);

            builder.HasOne(x => x.Pessoa);
        }
    }
}