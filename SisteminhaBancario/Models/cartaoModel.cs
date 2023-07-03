namespace SisteminhaBancario.Models
{
    public class cartaoModel
    {

        public int Id { get; set; }

        public int cpf_pessoa { get; set; }

        public int numero_cartao { get; set; }

        public int data_validade { get; set; }

        public int codigo_seguranca { get; set; }

        public int? PessoaId { get; set; }


        public virtual PessoaModel? Pessoa { get; set; }
    }
}
