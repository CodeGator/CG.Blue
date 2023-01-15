
namespace CG.Blue.Repositories;

/// <summary>
/// This interface represents an object that manages the storage and retrieval
/// of <see cref="FileTypeModel"/> objects.
/// </summary>
public interface IFileTypeRepository
{
    /// <summary>
    /// This method indicates whether there are any <see cref="FileTypeModel"/> objects
    /// in the underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns <c>true</c> if there
    /// are any <see cref="FileTypeModel"/> objects; <c>false</c> otherwise.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<bool> AnyAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method counts the number of <see cref="FileTypeModel"/> objects in the 
    /// underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a count of the 
    /// number of <see cref="FileTypeModel"/> objects in the underlying storage.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<long> CountAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method creates a new <see cref="FileTypeModel"/> object in the 
    /// underlying storage.
    /// </summary>
    /// <param name="fileType">The model to create in the underlying storage.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly created
    /// <see cref="FileTypeModel"/> object.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<FileTypeModel> CreateAsync(
        FileTypeModel fileType,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method deletes an existing <see cref="FileTypeModel"/> object from the 
    /// underlying storage.
    /// </summary>
    /// <param name="fileType">The model to delete from the underlying storage.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task DeleteAsync(
        FileTypeModel fileType,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for all the <ee cref="FileTypeModel"/> objects.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a sequence of 
    /// <see cref="FileTypeModel"/> objects.</returns>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<IEnumerable<FileTypeModel>> FindAllAsync(
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method searches for a single matching <see cref="FileTypeModel"/> object using
    /// the given file extension.
    /// </summary>
    /// <param name="extension">The file extension to use for the search.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns a matching <see cref="FileTypeModel"/> 
    /// object, if one was found, or NULL otherwise.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<FileTypeModel?> FindByExtensionAsync(
        string extension,
        CancellationToken cancellationToken = default
        );

    /// <summary>
    /// This method updates an existing <see cref="FileTypeModel"/> object in the 
    /// underlying storage.
    /// </summary>
    /// <param name="fileType">The model to update in the underlying storage.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation that returns the newly updated
    /// <see cref="FileTypeModel"/> object, if a match was found, or <c>NULL</c> 
    /// otherwise.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    /// <exception cref="RepositoryException">This exception is thrown whenever the
    /// repository fails to complete the operation.</exception>
    Task<FileTypeModel?> UpdateAsync(
        FileTypeModel fileType,
        CancellationToken cancellationToken = default
        );
}
