
namespace CG.Blue.Managers;

/// <summary>
/// This interface represents an object that manages operations related to
/// <see cref="BlobModel"/> objects.
/// </summary>
public interface IBlobManager
{
    /// <summary>
    /// This method indicates whether there are any <see cref="BlobModel"/> objects
    /// in the underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns <c>true</c> if there
    /// are any <see cref="BlobModel"/> objects; <c>false</c> otherwise.</returns>
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task<bool> AnyAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method counts the number of <see cref="BlobModel"/> objects in the 
    /// underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a count of the 
    /// number of <see cref="BlobModel"/> objects in the underlying storage.</returns>
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task<long> CountAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method creates a new <see cref="BlobModel"/> object in the 
    /// underlying storage.
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
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task<BlobModel> CreateAsync(
        Stream stream,
        string fileName,
        MimeTypeModel mimeType,
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
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task DeleteAsync(
        BlobModel blob,
        string userName,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for a single matching <see cref="BlobModel"/> object using
    /// the given identifier.
    /// </summary>
    /// <param name="id">The identifier to use for the search.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a matching <see cref="BlobModel"/> 
    /// object, if one was found, or <c>NULL</c> otherwise.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
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
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task<BlobBitsModel?> FindBitsByIdAsync(
        Guid id,
        string userName,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method updates an existing <see cref="BlobModel"/> object in the 
    /// underlying storage.
    /// </summary>
    /// <param name="blob">The model to update in the underlying storage.</param>
    /// <param name="userName">The user name of the person performing the 
    /// operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly updated
    /// <see cref="BlobModel"/> object.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="ManagerException">This exception is thrown whenever the
    /// manager fails to complete the operation.</exception>
    Task<BlobModel> UpdateAsync(
        BlobModel blob,
        string userName,
        CancellationToken cancellationToken = default
        );
}
