using System;
using System.Collections.Generic;

namespace Sync.Core
{
    public abstract class SyncBase
    {
        public SyncStatus Sincronizar(Scope scope)
        {
            var dataSet = ExtrairDados(scope);
            var resultado = ProcessarDados(dataSet);
            return resultado;
        }

        protected abstract DataSet ExtrairDados(Scope scope);
        protected abstract SyncStatus ProcessarDados(DataSet dataSet);
    }

    public class Scope
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<string> Filtros { get; set; } = new List<string>();
    }

    public class DataSet
    {
        public List<object> Dados { get; set; } = new List<object>();
        public int TotalRegistros => Dados.Count;
        public string Tipo { get; set; } = "";
    }

    public class SyncStatus
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = "";
        public int RegistrosProcessados { get; set; }
        public int RegistrosComErro { get; set; }
        public DateTime DataSincronizacao { get; set; } = DateTime.Now;
    }
}
