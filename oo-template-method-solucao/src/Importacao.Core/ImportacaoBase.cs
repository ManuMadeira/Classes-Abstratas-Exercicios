public abstract class ImportacaoOrquestrador
{
    public Relatorio Executar(string caminho)
    {
        // Fluxo fixo: Abrir → Ler → Validar → Registrar → Consolidar
        var fonte = AbrirFonte(caminho);
        var registros = LerRegistros(fonte);
        var relatorio = new Relatorio();
        
        foreach (var registro in registros)
        {
            var erros = ValidarRegistro(registro);
            if (erros.Any())
                relatorio.AdicionarErros(erros);
        }
        
        ConsolidarResultado(relatorio);
        PosConsolidacao(relatorio);
        return relatorio;
    }
    
    protected abstract List<string> ValidarRegistro(Registro registro);
    protected virtual void PosConsolidacao(Relatorio relatorio) { }
} 