using System;

public sealed class UsPaymentFlow : PaymentFlow
{
    public UsPaymentFlow() : base(""USD"", ""en-US"")
    {
    }
    
    protected override decimal CalcularImpostos(Pedido pedido)
    {
        // Regras fiscais americanas
        var subtotal = CalcularSubtotal(pedido);
        var salesTax = subtotal * 0.08m; // Sales Tax 8%
        
        Console.WriteLine($""Impostos calculados (US): Sales Tax {salesTax:F2}"");
        return salesTax;
    }
    
    protected override void AntesDeRegistrar(Pedido pedido, decimal subtotal, decimal impostos)
    {
        // Chamando implementação base
        base.AntesDeRegistrar(pedido, subtotal, impostos);
        
        // Adicionando logging de compliance específico para EUA
        Console.WriteLine(""US Compliance Check: Audit trail initialized"");
        Console.WriteLine($""Transaction details - Subtotal: {subtotal:F2}, Tax: {impostos:F2}"");
    }
    
    protected override string FormatarRecibo(ResultadoProcessamento resultado)
    {
        return $""US RECEIPT\nTotal: {Moeda} {resultado.Total:F2}\nLocation: {Localidade}\nZip Code: [Postal Code]"";
    }
}
