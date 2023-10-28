using System.Text.Json;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using SmartGenealogy.Application.Common.Interfaces.Serialization;

namespace SmartGenealogy.Infrastructure.Persistence.Conversions;

public class StringListConverter : ValueConverter<List<string>, string>
{
    public StringListConverter() : base(v => JsonSerializer.Serialize(v, DefaultJsonSerializerOptions.Options),
        v => JsonSerializer.Deserialize<List<string>>(string.IsNullOrEmpty(v) ? "[]" : v,
            DefaultJsonSerializerOptions.Options) ?? new List<string>())
    {
    }
}