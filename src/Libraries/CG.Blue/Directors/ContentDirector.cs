
namespace CG.Blue.Directors;

/// <summary>
/// This class is a default implementation of the <see cref="IContentDirector"/>
/// interface.
/// </summary>
public class ContentDirector : IContentDirector
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
    /// This field contains the mime type manager for this director.
    /// </summary>
    internal protected readonly IMimeTypeManager _mimeTypeManager = null!;

    /// <summary>
    /// This field contains the logger for this director.
    /// </summary>
    internal protected readonly ILogger<IContentDirector> _logger = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="ContentDirector"/>
    /// class.
    /// </summary>
    /// <param name="blobManager">The BLOB manager to use with this director.</param>
    /// <param name="mimeTypeManager">The mime type manager to use with 
    /// this director.</param>
    /// <param name="logger">The logger to use with this director.</param>
    public ContentDirector(
        IBlobManager blobManager,
        IMimeTypeManager mimeTypeManager,
        ILogger<ContentDirector> logger
        ) 
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blobManager, nameof(blobManager))
            .ThrowIfNull(mimeTypeManager, nameof(mimeTypeManager))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s).
        _blobManager = blobManager;
        _mimeTypeManager = mimeTypeManager;
        _logger = logger;
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <inheritdoc/>
    public virtual async Task<BlobModel> CreateAsync(
        Stream stream,
        string fileName,
        string mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(stream, nameof(stream))
            .ThrowIfNullOrEmpty(fileName, nameof(fileName))
            .ThrowIfNullOrEmpty(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Looking for a matching MIME type: '{mt}'",
                mimeType
                );

            // Look for a matching MIME type.
            var mimeTypeMatch = (await _mimeTypeManager.FindByTypeAsync(
                mimeType,
                cancellationToken
                ).ConfigureAwait(false))
                .FirstOrDefault();

            // If we didn't find a match use a default.
            if (mimeTypeMatch is null)
            {
                // Log what we are about to do.
                _logger.LogTrace(
                    "Looking for a default MIME type: application/octet-stream"
                    );

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

            // Log what we are about to do.
            _logger.LogTrace(
                "Creating the BLOB"
                );

            // Create the BLOB's meta-data.
            var blob = await _blobManager.CreateAsync(
                stream,
                fileName,
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
                "Failed to create a BLOB!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to create a BLOB!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<BlobModel?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfEmptyGuid(id, nameof(id));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Looking for matching BLOB meta-data"
                );

            // Look for matching BLOB meta-data.
            var blobMetaData = await _blobManager.FindByIdAsync(
                id,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return blobMetaData;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for BLOB meta-data by id!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to search for BLOB meta-data by id!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<BlobBitsModel?> FindBitsByIdAsync(
        Guid id,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfEmptyGuid(id, nameof(id))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Look for matching BLOB bits.
            var blobBits = await _blobManager.FindBitsByIdAsync(
                id,
                userName,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return blobBits;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for BLOB bits by id!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to search for BLOB bits by id!",
                innerException: ex
                );
        }
    }

    #endregion
}
