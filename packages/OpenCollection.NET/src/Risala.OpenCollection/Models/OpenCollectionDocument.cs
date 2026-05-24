namespace Risala.OpenCollection;

/// <summary>
/// Describes an OpenCollection object (OpenCollection document). See: https://spec.opencollection.com
/// </summary>
public record OpenCollectionDocument : IOpenCollectionElement
{
    /// <summary>
    /// The version of the OpenCollection.
    /// </summary>
    public string? OpenCollection { get; set; }

    /// <summary>
    /// Info about the collection.
    /// </summary>
    public OpenCollectionInfo? Info { get; set; }

    /// <summary>
    /// Parameter-less constructor.
    /// </summary>
    public OpenCollectionDocument() { }

    /// <summary>
    /// Initializes a copy of an <see cref="OpenCollectionDocument"/> object.
    /// </summary>
    public OpenCollectionDocument(OpenCollectionDocument? document)
    {
        OpenCollection = document?.OpenCollection ?? OpenCollection;
        Info = document?.Info != null ? new OpenCollectionInfo(document.Info) : null;
    }
}
