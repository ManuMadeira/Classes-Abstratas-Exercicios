using Sync.Core;

namespace Sync.Erp
{
    public class SyncErpFlow : SyncBase
    {
        protected override DataSet ExtrairDados(Scope scope)
        {
            Console.WriteLine($"Extraindo dados do ERP de {scope.DataInicio} até {scope.DataFim}");
            return new DataSet 
            { 
                Tipo = "ERP",
                Dados = new List<object> { "Produto1", "Produto2", "Produto3" }
            };
        }

        protected override SyncStatus ProcessarDados(DataSet dataSet)
        {
            Console.WriteLine($"Processando {dataSet.TotalRegistros} registros do ERP");
            return new SyncStatus 
            { 
                Sucesso = true,
                Mensagem = "Sincronização ERP concluída com sucesso",
                RegistrosProcessados = dataSet.TotalRegistros,
                RegistrosComErro = 0
            };
        }
    }
}
