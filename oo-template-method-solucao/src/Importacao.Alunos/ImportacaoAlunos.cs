public sealed class ImportacaoAlunos : ImportacaoOrquestrador
{
    protected override List<string> ValidarRegistro(Registro registro)
    {
        var erros = new List<string>();
        // Validações específicas para alunos
        if (string.IsNullOrEmpty(registro.Matricula))
            erros.Add("Matrícula é obrigatória");
        return erros;
    }
    
    protected override void PosConsolidacao(Relatorio relatorio)
    {
        base.PosConsolidacao(relatorio); // Chama implementação base
        // Adiciona totais por categoria
        relatorio.AdicionarMetrica("Total por curso calculado");
    }
}