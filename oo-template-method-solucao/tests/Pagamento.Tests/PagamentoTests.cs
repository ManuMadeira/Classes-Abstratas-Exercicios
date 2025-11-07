using Xunit;

public class PagamentoTests
{
    [Fact]
    public void UsPaymentFlow_Processar_DeveChamarAntesDeRegistrarComBase()
    {
        // Arrange
        var pagamento = new UsPaymentFlow();
        var pedido = new Pedido
        {
            Itens = new List<ItemPedido>
            {
                new ItemPedido { Produto = ""Produto Teste"", Quantidade = 1, Preco = 100.00m }
            }
        };
        
        // Act
        var resultado = pagamento.Processar(pedido);
        
        // Assert
        Assert.NotNull(resultado);
        Assert.True(resultado.Sucesso);
        Assert.Contains(""USD"", resultado.Mensagem);
    }
}
