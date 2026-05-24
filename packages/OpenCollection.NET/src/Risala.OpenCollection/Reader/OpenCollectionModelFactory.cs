using System;
using System.Collections.Generic;
using System.IO;
using Risala.OpenCollection.Reader.V1;
using SharpYaml.Serialization;

namespace Risala.OpenCollection.Reader;

/// <summary>
/// A factory class for loading OpenCollection models from various sources.
/// </summary>
public static class OpenCollectionModelFactory
{
    /// <summary>
    /// Reads the input string and parses it into an OpenCollection document.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>An OpenCollection document instance.</returns>
    public static OpenCollectionDocument Parse(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var stream = new YamlStream();
        using (var reader = new StringReader(input))
        {
            stream.Load(reader);
        }

        if (stream.Documents.Count == 0)
        {
            return new OpenCollectionDocument();
        }

        if (stream.Documents[0].RootNode is not YamlMappingNode root)
        {
            throw new InvalidOperationException("OpenCollection document root must be a YAML mapping.");
        }

        return OpenCollectionV1Deserializer.LoadOpenCollection(root);
    }
}
