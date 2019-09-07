using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public string Cep { get; private set; }  
        public string Cidade { get; private set; }  
        public string Bairro { get; private set; }  
        public string Rua { get; private set; }  
        public int Numero { get; private set; }  
        public string Complemento { get; private set; } 
        public string Observacao { get; private set; }

        public Endereco(string cep, string cidade, string bairro, string rua, int numero, string complemento, string observacao)
        {
            Cep = cep;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Observacao = observacao;

            AddNotifications(new Contract()
                .HasMaxLen(Cep, 20, "Endereco.Cep", "Cep deve conter até 20 caracteres")
                .HasMaxLen(Cidade, 50, "Endereco.Cidade", "Cidade deve conter até 50 caracteres")
                .HasMaxLen(Bairro, 50, "Endereco.Bairro", "Bairro deve conter até 50 caracteres")
                .HasMaxLen(Rua, 50, "Endereco.Rua", "Rua deve conter até 50 caracteres")
                .HasMaxLen(Complemento, 100, "Endereco.Complemento", "Complemento deve conter até 50 caracteres")
            );
        }
    }
}