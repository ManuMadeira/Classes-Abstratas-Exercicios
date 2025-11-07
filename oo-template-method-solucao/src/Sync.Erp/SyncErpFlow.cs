using System;
using System.Collections.Generic;

public sealed class SyncErpFlow : SyncBase
{
    protected override DataSet ColetarBruto(Scope escopo)
    {
        Console.WriteLine($""Coletando dados brutos do ERP: {escopo.Fonte}"");
        return new DataSet
        {
            Registros = new List<object>
            {
                new { Codigo = ""ERP001"", Nome = ""Produto ERP 1"", Preco = 100.00m },
                new { Codigo = ""ERP002"", Nome = ""Produto ERP 2"", Preco = 200.00m }
            }
        };
    }
    
    protected override string GerarRelatorio(SyncStatus status)
    {
        return $""RELATÓRIO ERP\nProcessados: {status.RegistrosProcessados}\nInseridos: {status.RegistrosInseridos}\nAtualizados: {status.RegistrosAtualizados}"";
    }
}
