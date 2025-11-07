using System;
using System.Linq;

public abstract class PaymentFlow
{
    protected PaymentFlow(string moeda, string localidade)
    {
        if (string.IsNullOrEmpty(moeda))
            throw new ArgumentException(""Moeda não pode ser vazia"", nameof(moeda));
        if (string.IsNullOrEmpty(localidade))
            throw new ArgumentException(""Localidade não pode ser vazia"", nameof(localidade));
            
        Moeda = moeda;
        Localidade = localidade;
    }
    
    protected string Moeda { get; }
    protected string Localidade { get; }
    
    public ResultadoProcessamento Processar(Pedido pedido)
    {
        var resultado = new ResultadoProcessamento();
        
        // Fluxo fixo do Template Method
        ValidarPedido(pedido);
        var subtotal = CalcularSubtotal(pedido);
        var impostos = CalcularImpostos(pedido);
        var total = AplicarDescontos(subtotal, impostos);
        
        AntesDeRegistrar(pedido, subtotal, impostos);
        RegistrarPagamento(pedido, total);
        AposRegistrar(resultado);
        
        resultado.Total = total;
        resultado.Sucesso = true;
        resultado.Mensagem = FormatarRecibo(resultado);
        
        return resultado;
    }
    
    protected virtual void ValidarPedido(Pedido pedido)
    {
        if (pedido == null)
            throw new ArgumentNullException(nameof(pedido));
        Console.WriteLine(""Pedido validado"");
    }
    
    protected virtual decimal CalcularSubtotal(Pedido pedido)
    {
        return pedido.Itens.Sum(i => i.Quantidade * i.Preco);
    }
    
    protected abstract decimal CalcularImpostos(Pedido pedido);
    
    protected virtual decimal AplicarDescontos(decimal subtotal, decimal impostos)
    {
        return subtotal + impostos; // Sem descontos por padrão
    }
    
    protected virtual void AntesDeRegistrar(Pedido pedido, decimal subtotal, decimal impostos)
    {
        // Implementação padrão no-op
    }
    
    protected virtual void RegistrarPagamento(Pedido pedido, decimal total)
    {
        Console.WriteLine($""Pagamento de {Moeda} {total:F2} registrado"");
    }
    
    protected virtual void AposRegistrar(ResultadoProcessamento resultado)
    {
        // Implementação padrão no-op
    }
    
    protected abstract string FormatarRecibo(ResultadoProcessamento resultado);
}
