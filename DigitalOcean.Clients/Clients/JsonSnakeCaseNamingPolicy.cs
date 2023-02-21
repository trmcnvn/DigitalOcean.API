using System.Text;
using System.Text.Json;

namespace DigitalOcean.Clients.Clients;

public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        var stringBuilder = new StringBuilder();
        name = name.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            return string.Empty;
        }

        stringBuilder.Append(char.ToLowerInvariant(name[0]));

        foreach (var c in name[1..])
        {
            if (char.IsUpper(c))
            {
                stringBuilder.Append('_');
            }


            if (c == ' ')
            {
                break;
            }

            stringBuilder.Append(char.ToLowerInvariant(c));
        }

        return stringBuilder.ToString();
    }
}
