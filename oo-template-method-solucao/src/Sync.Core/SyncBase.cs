using System;
using System.Collections.Generic;

public class Scope
{
    public string Fonte { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; } = DateTime.Now;
}

public class SyncStatus
{
    public int RegistrosProcessados { get; set; }
    public int RegistrosInseridos { get; set; }
    public int RegistrosAtualizados { get; set; }
    public List<string> Erros { get; } = new List<string>();
    public bool Sucesso => Erros.Count == 0;
}

public class DataSet
{
    public List<object> Registros { get; set; } = new List<object>();
}

public abstract class SyncBase
{
    public SyncStatus Executar(Scope escopo)
    {
        var status = new SyncStatus();
        
        // Fluxo fixo do Template Method
        var dadosBrutos = ColetarBruto(escopo);
        var dadosNormalizados = NormalizarReconciliar(dadosBrutos, status);
        AplicarDiferencas(dadosNormalizados, status);
        PosAplicacao(status);
        var relatorio = GerarRelatorio(status);
        
        Console.WriteLine(relatorio);
        return status;
    }
    
    protected abstract DataSet ColetarBruto(Scope escopo);
    
    protected virtual DataSet NormalizarReconciliar(DataSet dadosBrutos, SyncStatus status)
    {
        Console.WriteLine(""Normalizando e reconciliando dados..."");
        status.RegistrosProcessados = dadosBrutos.Registros.Count;
        return dadosBrutos;
    }
    
    protected virtual void AplicarDiferencas(DataSet dadosNormalizados, SyncStatus status)
    {
        Console.WriteLine(""Aplicando diferenças no catálogo..."");
        status.RegistrosInseridos = dadosNormalizados.Registros.Count / 2;
        status.RegistrosAtualizados = dadosNormalizados.Registros.Count / 2;
    }
    
    protected virtual void PosAplicacao(SyncStatus status)
    {
        // Implementação padrão no-op
    }
    
    protected abstract string GerarRelatorio(SyncStatus status);
}
