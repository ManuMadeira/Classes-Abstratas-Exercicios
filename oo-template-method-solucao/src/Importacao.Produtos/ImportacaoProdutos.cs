using System;
using System.Collections.Generic;

public sealed class ImportacaoProdutos : ImportacaoBase
{
    protected override object AbrirFonte(string caminho)
    {
        Console.WriteLine($""Abrindo arquivo de produtos: {caminho}"");
        return new { Caminho = caminho };
    }
    
    protected override List<Registro> LerRegistros(object fonte)
    {
        Console.WriteLine(""Lendo registros de produtos..."");
        return new List<Registro>
        {
            new Registro { Dados = ""Notebook,2500.00,10"" },
            new Registro { Dados = ""Mouse,50.00,-5"" }, // Quantidade inválida
            new Registro { Dados = ""Teclado,150.00"" } // Dados incompletos
        };
    }
    
    protected override List<string> ValidarRegistro(Registro registro)
    {
        var erros = new List<string>();
        var campos = registro.Dados.Split(',');
        
        if (campos.Length != 3)
            erros.Add($""Número incorreto de campos: {registro.Dados}"");
        
        if (campos.Length > 1 && !decimal.TryParse(campos[1], out _))
            erros.Add($""Preço inválido: {campos[1]}"");
            
        if (campos.Length > 2 && (!int.TryParse(campos[2], out var quantidade) || quantidade < 0))
            erros.Add($""Quantidade inválida: {campos[2]}"");
            
        return erros;
    }
    
    protected override void ConsolidarResultado(Relatorio relatorio)
    {
        relatorio.Metricas.Add(""Processamento de produtos concluído"");
    }
}
