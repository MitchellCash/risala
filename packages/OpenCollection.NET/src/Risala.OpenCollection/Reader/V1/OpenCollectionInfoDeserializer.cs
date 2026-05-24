using SharpYaml.Serialization;

namespace Risala.OpenCollection.Reader.V1;

internal static partial class OpenCollectionV1Deserializer
{
    public static OpenCollectionInfo LoadInfo(YamlMappingNode node)
    {
        var info = new OpenCollectionInfo();

        foreach (var entry in node.Children)
        {
            if (entry.Key is not YamlScalarNode key)
            {
                continue;
            }

            switch (key.Value)
            {
                case "name":
                    info.Name = (entry.Value as YamlScalarNode)?.Value;
                    break;
                case "summary":
                    info.Summary = (entry.Value as YamlScalarNode)?.Value;
                    break;
                case "version":
                    info.Version = (entry.Value as YamlScalarNode)?.Value;
                    break;
            }
        }

        return info;
    }
}
