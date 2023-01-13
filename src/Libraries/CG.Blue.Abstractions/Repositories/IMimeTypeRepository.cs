
using CG.Blue.Managers;

namespace CG.Blue.Repositories;

/// <summary>
/// This interface represents an object that manages the storage and retrieval
/// of <see cref="MimeTypeModel"/> objects.
/// </summary>
public interface IMimeTypeRepository
{
    /// <summary>
    /// This method indicates whether there are any <see cref="MimeTypeModel"/> objects
    /// in the underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns <c>true</c> if there
    /// are any <see cref="MimeTypeModel"/> objects; <c>false</c> otherwise.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<bool> AnyAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method indicates whether there are any <see cref="MimeTypeModel"/> objects
    /// in the underlying storage that match the given type / subtype.
    /// </summary>
    /// <param name="type">The MIME type to use for the search.</param>
    /// <param name="subType">The MIME sub-type to use for the search.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns <c>true</c> if there
    /// are any <see cref="MimeTypeModel"/> objects; <c>false</c> otherwise.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<bool> AnyAsync(
        string type,
        string subType,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method counts the number of <see cref="MimeTypeModel"/> objects in the 
    /// underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a count of the 
    /// number of <see cref="MimeTypeModel"/> objects in the underlying storage.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<long> CountAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method creates a new <see cref="MimeTypeModel"/> object in the 
    /// underlying storage.
    /// </summary>
    /// <param name="mimeType">The model to create in the underlying storage.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly created
    /// <see cref="MimeTypeModel"/> object.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<MimeTypeModel> CreateAsync(
        MimeTypeModel mimeType,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method deletes an existing <see cref="MimeTypeModel"/> object from the 
    /// underlying storage.
    /// </summary>
    /// <param name="mimeType">The model to delete from the underlying storage.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task DeleteAsync(
        MimeTypeModel mimeType,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for a sequence of <see cref="MimeTypeModel"/> objects.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the results of the search.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<IEnumerable<MimeTypeModel>> FindAllAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for matching <see cref="MimeTypeModel"/> objects using
    /// the given type and/or subtype.
    /// </summary>
    /// <param name="type">The MIME type to use for the search.</param>
    /// <param name="subType">The MIME sub-type to use for the search.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the results of the search.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<IEnumerable<MimeTypeModel>> FindByTypesAsync(
        string type,
        string subType,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for a single matching <see cref="MimeTypeModel"/> object using
    /// the given file extension.
    /// </summary>
    /// <param name="extension">The file extension to use for the search.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a matching <see cref="MimeTypeModel"/> 
    /// object, if one was found, or NULL otherwise.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<MimeTypeModel?> FindByExtensionAsync(
        string extension,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for a single matching <see cref="MimeTypeModel"/> object using
    /// the given identifier.
    /// </summary>
    /// <param name="id">The identifier to use for the search.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a matching <see cref="MimeTypeModel"/> 
    /// object, if one was found, or NULL otherwise.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<MimeTypeModel?> FindByIdAsync(
        int id,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method updates an existing <see cref="MimeTypeModel"/> object in the 
    /// underlying storage.
    /// </summary>
    /// <param name="mimeType">The model to update in the underlying storage.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly updated
    /// <see cref="MimeTypeModel"/> object.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<MimeTypeModel> UpdateAsync(
        MimeTypeModel mimeType,
        CancellationToken cancellationToken = default
        );
}
