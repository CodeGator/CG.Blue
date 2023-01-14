
namespace CG.Blue.Directors;

/// <summary>
/// This class is a default implementation of the <see cref="IImportDirector"/>
/// interface.
/// </summary>
public class ImportDirector : IImportDirector
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the BLOB manager for this director.
    /// </summary>
    internal protected readonly IBlobManager _blobManager = null!;

    /// <summary>
    /// This field contains the cryptographer for this director.
    /// </summary>
    internal protected readonly ICryptographer _cryptographer = null!;

    /// <summary>
    /// This field contains the mime type manager for this director.
    /// </summary>
    internal protected readonly IMimeTypeManager _mimeTypeManager = null!;

    /// <summary>
    /// This field contains the logger for this director.
    /// </summary>
    internal protected readonly ILogger<IImportDirector> _logger = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="ImportDirector"/>
    /// class.
    /// </summary>
    /// <param name="blobManager">The BLOB manager to use with this director.</param>
    /// <param name="cryptographer">The cryptographer to use with this 
    /// director.</param>
    /// <param name="mimeTypeManager">The mime type manager to use with 
    /// this director.</param>
    /// <param name="logger">The logger to use with this director.</param>
    public ImportDirector(
        IBlobManager blobManager,
        ICryptographer cryptographer,
        IMimeTypeManager mimeTypeManager,
        ILogger<ImportDirector> logger
        ) 
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blobManager, nameof(blobManager))
            .ThrowIfNull(cryptographer, nameof(cryptographer))
            .ThrowIfNull(mimeTypeManager, nameof(mimeTypeManager))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s).
        _blobManager = blobManager;
        _cryptographer = cryptographer;
        _mimeTypeManager = mimeTypeManager;
        _logger = logger;
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <inheritdoc/>
    public virtual async Task<BlobModel> ImportAsync(
        Stream stream,
        string mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(stream, nameof(stream))
            .ThrowIfNullOrEmpty(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Look for a matching MIME type.
            var mimeTypeMatch = (await _mimeTypeManager.FindByTypeAsync(
                mimeType,
                cancellationToken
                ).ConfigureAwait(false))
                .FirstOrDefault();

            // If we didn't find a match use a default.
            if (mimeTypeMatch is null)
            {
                // Look for a default type.
                mimeTypeMatch = (await _mimeTypeManager.FindByTypesAsync(
                    "application",
                    "octet-stream",
                    cancellationToken
                    ).ConfigureAwait(false))
                    .FirstOrDefault();
            }

            // If we find anything, give up.
            if (mimeTypeMatch is null)
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"mime type: {mimeType} was not found and no default is available!"
                    );
            }

            // If the mime type has no extension, give up.
            if (!mimeTypeMatch.FileTypes.Any())
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"mime type: {mimeType} has no extension associated with it!"
                    );
            }

            // Create the BLOB.
            var blob = await _blobManager.CreateAsync(
                stream,
                mimeTypeMatch,
                userName,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return blob;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to import a BLOB!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to import a BLOB!",
                innerException: ex
                );
        }
    }

    #endregion
}
