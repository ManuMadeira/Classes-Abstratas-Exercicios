using System;

public sealed class BrPaymentFlow : PaymentFlow
{
    public BrPaymentFlow() : base(""BRL"", ""pt-BR"")
    {
    }
    
    protected override decimal CalcularImpostos(Pedido pedido)
    {
        // Regras fiscais brasileiras
        var subtotal = CalcularSubtotal(pedido);
        var icms = subtotal * 0.18m; // ICMS 18%
        var pisCofins = subtotal * 0.09m; // PIS/COFINS 9%
        
        Console.WriteLine($""Impostos calculados (BR): ICMS {icms:F2}, PIS/COFINS {pisCofins:F2}"");
        return icms + pisCofins;
    }
    
    protected override string FormatarRecibo(ResultadoProcessamento resultado)
    {
        return $""RECIBO BRASILEIRO\nTotal: {Moeda} {resultado.Total:F2}\nLocalidade: {Localidade}\nCPF/CNPJ: [Documento Fiscal]"";
    }
}
