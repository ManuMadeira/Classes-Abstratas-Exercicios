using Xunit;

public class PedidosTests
{
    [Fact]
    public void PedidoInternacionalProcessor_Processar_DeveChamarBaseEAplicarRastreamento()
    {
        // Arrange
        var processador = new PedidoInternacionalProcessor();
        var pedido = new Pedido
        {
            Itens = new List<ItemPedido>
            {
                new ItemPedido { Produto = ""Produto Teste"", Quantidade = 2, Preco = 50.00m }
            }
        };
        
        // Act
        var resultado = processador.Processar(pedido);
        
        // Assert
        Assert.NotNull(resultado);
        Assert.True(resultado.Sucesso);
        Assert.Contains(""USD"", resultado.Mensagem);
    }
}
