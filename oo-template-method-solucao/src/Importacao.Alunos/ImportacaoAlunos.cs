using System;
using System.Collections.Generic;

public sealed class ImportacaoAlunos : ImportacaoBase
{
    protected override object AbrirFonte(string caminho)
    {
        Console.WriteLine($"Abrindo arquivo de alunos: {caminho}");
        return new { Caminho = caminho };
    }
    
    protected override List<Registro> LerRegistros(object fonte)
    {
        Console.WriteLine("Lendo registros de alunos...");
        return new List<Registro>
        {
            new Registro { Dados = "João,25,Engenharia" },
            new Registro { Dados = "Maria,22,Medicina" },
            new Registro { Dados = "Pedro,30," } // Dados inválidos para teste
        };
    }
    
    protected override List<string> ValidarRegistro(Registro registro)
    {
        var erros = new List<string>();
        var campos = registro.Dados.Split(',');
        
        if (campos.Length != 3)
            erros.Add($"Número incorreto de campos: {registro.Dados}");
        
        if (campos.Length > 1 && !int.TryParse(campos[1], out _))
            erros.Add($"Idade inválida: {campos[1]}");
            
        if (campos.Length > 2 && string.IsNullOrEmpty(campos[2]))
            erros.Add($"Curso não informado: {registro.Dados}");
            
        return erros;
    }
    
    protected override void ConsolidarResultado(Relatorio relatorio)
    {
        relatorio.Metricas.Add($"Total de erros: {relatorio.Erros.Count}");
    }
    
    protected override void PosConsolidacao(Relatorio relatorio)
    {
        // Chamando a implementação base primeiro
        base.PosConsolidacao(relatorio);
        
        // Adicionando lógica específica - totais por categoria
        relatorio.Metricas.Add("Totais por categoria: Engenharia=1, Medicina=1");
        Console.WriteLine("Cálculo de totais por categoria concluído");
    }
}