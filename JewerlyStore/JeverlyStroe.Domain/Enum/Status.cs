using System.ComponentModel;

namespace JeverlyStroe.Domain.Enum;

public enum Status
{
    [Description("Не рассмотрено")]
    NotConsidered=0,
    [Description("Одобрено")]
    Approved=1,
    [Description("Отказано")]
    Denied=2
}