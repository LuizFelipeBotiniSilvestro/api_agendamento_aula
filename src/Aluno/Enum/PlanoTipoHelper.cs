namespace SistemaAgendamento.Aluno;

public static class PlanoTipoHelper
{
    public static PlanoTipo Parse(object? input)
    {
        var valor = input?.ToString()?.Trim().ToUpper();

        return valor switch
        {
            "1" or "MENSAL"      => PlanoTipo.Mensal,
            "2" or "TRIMESTRAL"  => PlanoTipo.Trimestral,
            "3" or "ANUAL"       => PlanoTipo.Anual,
            _ => throw new ArgumentException("Plano inválido. Use: 1, 2, 3 ou Mensal, Trimestral, Anual.")
        };
    }

    public static string ToNome(PlanoTipo tipo) => tipo switch
    {
        PlanoTipo.Mensal => "Mensal",
        PlanoTipo.Trimestral => "Trimestral",
        PlanoTipo.Anual => "Anual",
        _ => "Desconhecido"
    };

    public static long ToCodigo(PlanoTipo tipo) => (long)tipo;
}
