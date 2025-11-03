using System.Text.Json;
using System.Text.Json.Serialization;

namespace investTools.Web.Utils;

public class JsonStringConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;
            
        var value = reader.GetString();
        return DateTime.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value == null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value.Value.ToString("dd/MM/yyyy"));
    }
}