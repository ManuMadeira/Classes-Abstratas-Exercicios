using Sync.Core;

namespace Sync.Marketplace
{
    public class SyncMarketplaceFlow : SyncBase
    {
        protected override DataSet ExtrairDados(Scope scope)
        {
            Console.WriteLine($"Extraindo dados do Marketplace de {scope.DataInicio} até {scope.DataFim}");
            return new DataSet 
            { 
                Tipo = "Marketplace",
                Dados = new List<object> { "Pedido1", "Pedido2", "Pedido3", "Pedido4" }
            };
        }

        protected override SyncStatus ProcessarDados(DataSet dataSet)
        {
            Console.WriteLine($"Processando {dataSet.TotalRegistros} registros do Marketplace");
            return new SyncStatus 
            { 
                Sucesso = true,
                Mensagem = "Sincronização Marketplace concluída com sucesso",
                RegistrosProcessados = dataSet.TotalRegistros,
                RegistrosComErro = 0
            };
        }
    }
}
