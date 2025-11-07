using System;

public sealed class PedidoInternacionalProcessor : PedidoProcessor
{
    public PedidoInternacionalProcessor() : base(""USD"")
    {
    }
    
    protected override decimal CalcularFrete(Pedido pedido)
    {
        // Frete mais caro para internacional
        Console.WriteLine(""Calculando frete internacional: $ 45,00"");
        return 45.00m;
    }
    
    protected override void AposReservaEstoque(Pedido pedido)
    {
        // Chamando implementação base primeiro
        base.AposReservaEstoque(pedido);
        
        // Adicionando rastreamento específico para internacional
        Console.WriteLine(""Rastreamento internacional configurado"");
        Console.WriteLine(""Código de rastreamento gerado: INT-"" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper());
    }
    
    protected override string GerarConfirmacao(ResultadoProcessamento resultado)
    {
        return $""Order processed successfully! Total: {Moeda} {resultado.Total:F2}"";
    }
}
