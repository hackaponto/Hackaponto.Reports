using System.Text.Json.Serialization;

namespace Hackaponto.Reports.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClockingEventType
    {
        IN,
        OUT
    }


    public static class ClockingEventTypeExtensions
    {
        public static string ToPortuguese(this ClockingEventType clockingEventType)
        {
            return clockingEventType switch
            {
                ClockingEventType.IN => "Entrada",
                ClockingEventType.OUT => "Saída",
                _ => throw new InvalidDataException("Tipo de registro de ponto inválido."),
            };
        }
    }
}
