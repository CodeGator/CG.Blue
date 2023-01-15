
namespace CG.Blue.Directors;

/// <summary>
/// This interface represents an object that performs operations related to
/// digital content.
/// </summary>
public interface IContentDirector
{
    /// <summary>
    /// This method creates a BLOB from the given stream.
    /// </summary>
    /// <param name="stream">The stream to use for the operation.</param>
    /// <param name="fileName">The file name to use for the operation.</param>
    /// <param name="mimeType">The mime type to use for the operation.</param>
    /// <param name="userName">The user name of the person performing the 
    /// operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly created
    /// <see cref="BlobModel"/> object.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="DirectorException">This exception is thrown whenever the
    /// director fails to complete the operation.</exception>
    Task<BlobModel> CreateAsync(
        Stream stream,
        string fileName,
        string mimeType,
        string userName,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method deletes an existing <see cref="BlobModel"/> object from the 
    /// underlying storage.
    /// </summary>
    /// <param name="blob">The model to delete from the underlying storage.</param>
    /// <param name="userName">The user name of the person performing the 
    /// operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="DirectorException">This exception is thrown whenever the
    /// director fails to complete the operation.</exception>
    Task DeleteAsync(
        BlobModel blob,
        string userName,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for BLOB meta-data, using the given identifier.
    /// </summary>
    /// <param name="id">The identifier to use for the operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the matching 
    /// <see cref="BlobModel"/> object, if a match was found, or <c>NULL</c>
    /// otherwise.
    /// </returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="DirectorException">This exception is thrown whenever the
    /// director fails to complete the operation.</exception>
    Task<BlobModel?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for BLOB bits, using the given identifier.
    /// </summary>
    /// <param name="id">The identifier to use for the operation.</param>
    /// <param name="userName">The user name of the person performing the 
    /// operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the matching 
    /// <see cref="BlobBitsModel"/> object, if a match was found, or <c>NULL</c>
    /// otherwise.
    /// </returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="DirectorException">This exception is thrown whenever the
    /// director fails to complete the operation.</exception>
    Task<BlobBitsModel?> FindBitsByIdAsync(
        Guid id,
        string userName,
        CancellationToken cancellationToken = default
        );
}
