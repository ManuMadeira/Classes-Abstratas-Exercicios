using Sync.Core;

namespace Pagamento.US
{
    public class UsPaymentFlow : PaymentFlow
    {
        public override void ProcessarPagamento(Pedido pedido)
        {
            // Implementação específica para pagamentos nos EUA
            Console.WriteLine("Processando pagamento em USD: $" + pedido.Valor);
        }

        public override ResultadoProcessamento VerificarStatus(Pedido pedido)
        {
            // Implementação específica para verificação nos EUA
            return new ResultadoProcessamento 
            { 
                Sucesso = true,
                Mensagem = "Pagamento em USD processado com sucesso",
                CodigoTransacao = "US" + DateTime.Now.Ticks
            };
        }
    }
}
