using System;
using System.Collections.Generic;
using System.Linq;

public class Pedido
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public decimal Subtotal { get; set; }
    public string Tipo { get; set; } = ""Nacional"";
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}

public class ItemPedido
{
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}

public class ResultadoProcessamento
{
    public bool Sucesso { get; set; }
    public decimal Total { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public List<string> Logs { get; } = new List<string>();
}

public abstract class PedidoProcessor
{
    protected PedidoProcessor(string moeda)
    {
        if (string.IsNullOrEmpty(moeda))
            throw new ArgumentException(""Moeda não pode ser vazia"", nameof(moeda));
            
        Moeda = moeda;
    }
    
    protected string Moeda { get; }
    
    public ResultadoProcessamento Processar(Pedido pedido)
    {
        var resultado = new ResultadoProcessamento();
        
        // Fluxo fixo do Template Method
        ValidarItens(pedido);
        ReservarEstoque(pedido);
        var frete = CalcularFrete(pedido);
        var total = CalcularTotal(pedido, frete);
        PersistirPedido(pedido);
        
        resultado.Total = total;
        resultado.Sucesso = true;
        
        AposReservaEstoque(pedido);
        resultado.Mensagem = GerarConfirmacao(resultado);
        
        return resultado;
    }
    
    protected virtual void ValidarItens(Pedido pedido)
    {
        if (pedido.Itens == null || pedido.Itens.Count == 0)
            throw new InvalidOperationException(""Pedido sem itens"");
            
        Console.WriteLine(""Itens validados com sucesso"");
    }
    
    protected virtual void ReservarEstoque(Pedido pedido)
    {
        Console.WriteLine(""Estoque reservado"");
    }
    
    protected abstract decimal CalcularFrete(Pedido pedido);
    
    protected virtual decimal CalcularTotal(Pedido pedido, decimal frete)
    {
        var subtotal = pedido.Itens.Sum(i => i.Quantidade * i.Preco);
        return subtotal + frete;
    }
    
    protected virtual void PersistirPedido(Pedido pedido)
    {
        Console.WriteLine($""Pedido {pedido.Id} persistido"");
    }
    
    protected virtual void AposReservaEstoque(Pedido pedido)
    {
        // Implementação padrão no-op
    }
    
    protected abstract string GerarConfirmacao(ResultadoProcessamento resultado);
}
