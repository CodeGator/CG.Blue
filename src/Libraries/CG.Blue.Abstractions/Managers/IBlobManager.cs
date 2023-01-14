
namespace CG.Blue.Managers;

/// <summary>
/// This interface represents an object that manages operations related to
/// <see cref="BlobModel"/> objects.
/// </summary>
public interface IBlobManager
{
    /// <summary>
    /// This method creates a new <see cref="FileTypeModel"/> object in the 
    /// underlying storage.
    /// </summary>
    /// <param name="stream">The stream to use for the operation.</param>
    /// <param name="mimeType">The mime type to use for the operation.</param>
    /// <param name="userName">The user name of the person performing the 
    /// operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly created
    /// <see cref="BlobModel"/> object.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task<BlobModel> CreateAsync(
        Stream stream,
        MimeTypeModel mimeType,
        string userName,
        CancellationToken cancellationToken = default
        );
}
