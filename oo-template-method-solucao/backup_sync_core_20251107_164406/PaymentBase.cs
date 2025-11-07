using System;

namespace Sync.Core
{
    public abstract class PaymentFlow
    {
        public abstract void ProcessarPagamento(Pedido pedido);
        public abstract ResultadoProcessamento VerificarStatus(Pedido pedido);
    }

    public class Pedido
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Moeda { get; set; }
    }

    public class ResultadoProcessamento
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public string CodigoTransacao { get; set; }
    }
}
