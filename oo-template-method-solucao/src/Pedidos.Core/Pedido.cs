public class Pedido
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public decimal Subtotal { get; set; }
    public string Tipo { get; set; } = "Nacional";
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}

public class ItemPedido
{
    public string Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}

public class ResultadoProcessamento
{
    public bool Sucesso { get; set; }
    public decimal Total { get; set; }
    public string Mensagem { get; set; }
    public List<string> Logs { get; } = new List<string>();
}