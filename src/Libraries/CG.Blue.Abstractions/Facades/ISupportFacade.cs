
namespace CG.Blue.Facades;

/// <summary>
/// This interface represents an object that contains support objects for
/// the <see cref="CG.Blue"/> microservice.
/// </summary>
public interface ISupportFacade 
{
    /// <summary>
    /// This property contains an object that performs file type operations.
    /// </summary>
    IFileTypeManager FileTypes { get; }

    /// <summary>
    /// This property contains an object that performs mime type operations.
    /// </summary>
    IMimeTypeManager MimeTypes { get; }
}
