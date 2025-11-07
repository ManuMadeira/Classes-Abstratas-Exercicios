using System;

public sealed class PedidoNacionalProcessor : PedidoProcessor
{
    public PedidoNacionalProcessor() : base("BRL")
    {
    }
    
    protected override decimal CalcularFrete(Pedido pedido)
    {
        // Frete fixo para pedidos nacionais
        Console.WriteLine("Calculando frete nacional: R$ 15,00");
        return 15.00m;
    }
    
    protected override string GerarConfirmacao(ResultadoProcessamento resultado)
    {
        return $"Pedido processado com sucesso! Total: {Moeda} {resultado.Total:F2}";
    }
}