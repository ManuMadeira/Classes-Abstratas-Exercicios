using Xunit;

public class SyncTests
{
    [Fact]
    public void SyncMarketplaceFlow_Executar_DeveChamarPosAplicacaoComBase()
    {
        // Arrange
        var sync = new SyncMarketplaceFlow();
        var scope = new Scope { Fonte = ""Amazon"" };
        
        // Act
        var status = sync.Executar(scope);
        
        // Assert
        Assert.NotNull(status);
        Assert.True(status.Sucesso);
        Assert.True(status.RegistrosProcessados > 0);
    }
}
