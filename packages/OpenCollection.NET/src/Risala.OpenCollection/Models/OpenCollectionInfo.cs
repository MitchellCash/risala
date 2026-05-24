namespace Risala.OpenCollection;

/// <summary>
/// OpenCollection Info Object, it provides the metadata about the OpenCollection.
/// </summary>
public record OpenCollectionInfo : IOpenCollectionElement
{
    /// <summary>
    /// The name of the collection.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// A short summary of the collection.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// The version of the collection.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Parameter-less constructor.
    /// </summary>
    public OpenCollectionInfo() { }

    /// <summary>
    /// Initializes a copy of an <see cref="OpenCollectionInfo"/> object.
    /// </summary>
    public OpenCollectionInfo(OpenCollectionInfo info)
    {
        Name = info?.Name ?? Name;
        Summary = info?.Summary ?? Summary;
        Version = info?.Version ?? Version;
    }
}
