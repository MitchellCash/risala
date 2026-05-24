using SharpYaml.Serialization;

namespace Risala.OpenCollection.Reader.V1;

internal static partial class OpenCollectionV1Deserializer
{
    public static OpenCollectionDocument LoadOpenCollection(YamlMappingNode node)
    {
        var openCollectionDoc = new OpenCollectionDocument();

        foreach (var entry in node.Children)
        {
            if (entry.Key is not YamlScalarNode key)
            {
                continue;
            }

            switch (key.Value)
            {
                case "opencollection":
                    openCollectionDoc.OpenCollection = (entry.Value as YamlScalarNode)?.Value;
                    break;
                case "info" when entry.Value is YamlMappingNode infoNode:
                    openCollectionDoc.Info = OpenCollectionV1Deserializer.LoadInfo(infoNode);
                    break;
            }
        }

        return openCollectionDoc;
    }
}
