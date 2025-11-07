using Xunit;

public class ImportacaoTests
{
    [Fact]
    public void ImportacaoAlunos_Executar_DeveProcessarComSucesso()
    {
        // Arrange
        var importador = new ImportacaoAlunos();
        
        // Act
        var relatorio = importador.Executar(""alunos.csv"");
        
        // Assert
        Assert.NotNull(relatorio);
        Assert.Contains(""Totais por categoria"", relatorio.Metricas[1]);
    }
    
    [Fact] 
    public void ImportacaoProdutos_Executar_DeveCapturarErros()
    {
        // Arrange
        var importador = new ImportacaoProdutos();
        
        // Act
        var relatorio = importador.Executar(""produtos.csv"");
        
        // Assert
        Assert.NotNull(relatorio);
        Assert.NotEmpty(relatorio.Erros);
    }
}
