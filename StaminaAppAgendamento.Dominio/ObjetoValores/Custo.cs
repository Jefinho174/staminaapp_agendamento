using StaminaAppAgendamento.Core.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.ObjetoValores
{
    public class Custo : ObjetoValor
    {
        public decimal ValorCompra { get; private set; }
        public decimal IcmsSt { get; private set; }
        public decimal Frete { get; private set; }
        public decimal OutrasDespeses { get; private set; }
        public decimal Desconto { get; private set; }
    }
}