namespace SistemaAgendamento.Aula;

public enum TipoAulaEnum
{
    Cross = 1,
    Musculacao = 2,
    Pilates = 3,
    Spinning = 4
}

public static class TipoAulaHelper
{
    public static long Parse(object? valor)
    {
        if (valor == null)
            throw new ArgumentException("O campo 'tp_aula' é obrigatório.");

        var str = valor.ToString()!.Trim().ToLower();

        return str switch
        {
            "1" or "cross" => (long)TipoAulaEnum.Cross,
            "2" or "musculacao" or "musculação" => (long)TipoAulaEnum.Musculacao,
            "3" or "pilates" => (long)TipoAulaEnum.Pilates,
            "4" or "spinning" => (long)TipoAulaEnum.Spinning,
            _ => throw new ArgumentException("O campo 'tp_aula' é inválido. Use 1–4 ou nomes válidos.")
        };
    }
}
