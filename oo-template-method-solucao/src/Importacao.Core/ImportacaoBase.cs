using System.Collections.Generic;

public class Registro
{
    public string Dados { get; set; } = string.Empty;
}

public class Relatorio
{
    public List<string> Erros { get; } = new List<string>();
    public List<string> Metricas { get; } = new List<string>();
    public bool Sucesso => Erros.Count == 0;
}

public abstract class ImportacaoBase
{
    public Relatorio Executar(string caminho)
    {
        var relatorio = new Relatorio();
        
        // Fluxo fixo do Template Method
        var fonte = AbrirFonte(caminho);
        var registros = LerRegistros(fonte);
        
        foreach (var registro in registros)
        {
            var erros = ValidarRegistro(registro);
            relatorio.Erros.AddRange(erros);
        }
        
        ConsolidarResultado(relatorio);
        PosConsolidacao(relatorio);
        
        return relatorio;
    }
    
    protected abstract object AbrirFonte(string caminho);
    protected abstract List<Registro> LerRegistros(object fonte);
    protected abstract List<string> ValidarRegistro(Registro registro);
    protected abstract void ConsolidarResultado(Relatorio relatorio);
    
    protected virtual void PosConsolidacao(Relatorio relatorio)
    {
        // Implementação padrão no-op
    }
}
