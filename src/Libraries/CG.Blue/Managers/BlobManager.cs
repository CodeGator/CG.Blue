
namespace CG.Blue.Managers;

/// <summary>
/// This class is a default implementation of the <see cref="IBlobManager"/>
/// interface.
/// </summary>
internal class BlobManager : IBlobManager
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the repository for this manager.
    /// </summary>
    internal protected readonly BlobStorageOptions? _blobStorageOptions;

    /// <summary>
    /// This field contains the cryptographer for this manager.
    /// </summary>
    internal protected readonly ICryptographer _cryptographer = null!;

    /// <summary>
    /// This field contains the repository for this manager.
    /// </summary>
    internal protected readonly IBlobRepository _blobRepository = null!;

    /// <summary>
    /// This field contains the logger for this manager.
    /// </summary>
    internal protected readonly ILogger<IBlobManager> _logger = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlobManager"/>
    /// class.
    /// </summary>
    /// <param name="bllOptions">The BLL options to use with this manager.</param>
    /// <param name="cryptographer">The cryptographer to use with this 
    /// manager.</param>
    /// <param name="blobRepository">The BLOB repository to use with this 
    /// manager.</param>
    /// <param name="logger">The logger to use with this manager.</param>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    public BlobManager(
        IOptions<BlueBllOptions> bllOptions,
        ICryptographer cryptographer,
        IBlobRepository blobRepository,
        ILogger<IBlobManager> logger
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNull(bllOptions, nameof(bllOptions))
            .ThrowIfNull(cryptographer, nameof(cryptographer))
            .ThrowIfNull(blobRepository, nameof(blobRepository))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s)
        _blobStorageOptions = bllOptions.Value.BlobStorage;
        _cryptographer = cryptographer;
        _blobRepository = blobRepository;
        _logger = logger;
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <inheritdoc/>
    public virtual async Task<bool> AnyAsync(
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IBlobRepository.AnyAsync)
                );

            // Check the repository for the data.
            var result = await _blobRepository.AnyAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results,
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for BLOBs!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for BLOBs!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<long> CountAsync(
        CancellationToken cancellationToken = default
        )
    {
        try
        {

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IBlobRepository.CountAsync)
                );

            // Perform the search.
            var result = await _blobRepository.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to count BLOBs!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to count BLOBs!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<BlobModel> CreateAsync(
        Stream stream,
        string fileName,
        MimeTypeModel mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNull(stream, nameof(stream))
            .ThrowIfNull(fileName, nameof(fileName))
            .ThrowIfNull(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Creating a {name} instance",
                nameof(BlobModel)
                );

            // Create the BLOB model.
            var blob = new BlobModel()
            {
                Id = Guid.NewGuid(),
                OriginalFileName = fileName,
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = userName
            };

            // Log what we are about to do.
            _logger.LogTrace(
                "Getting a safe file extension"
                );

            // Get the extension associated with the MIME type.
            var safeExt = mimeType.FileTypes.FirstOrDefault()?.Extension;

            // Did we fail?
            if (string.IsNullOrEmpty(safeExt))
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"mime type: {mimeType} has no extension associated with it!"
                    );
            }

            // Log what we are about to do.
            _logger.LogTrace(
                "Checking for BLOB storage options"
                );

            // Do we have BLOB storage options?
            if (_blobStorageOptions is not null)
            {
                // Log what we are about to do.
                _logger.LogTrace(
                    "Calculating a local storage path"
                    );

                // Create a complete path to our storage file.
                blob.LocalFilePath = Path.Combine(
                    _blobStorageOptions.RootPath,
                    blob.Id.ToFolderPath(
                        _blobStorageOptions.FolderLevels
                        ),
                    blob.Id.ToFileName(
                        safeExt,
                        _blobStorageOptions.FolderLevels
                        )
                    );

                // Log what we are about to do.
                _logger.LogTrace(
                    "Deciding whether to encrypt the file"
                    );

                // Should we encrypt the BLOB?
                blob.EncryptedAtRest = _blobStorageOptions.EncryptAtRest;
            }
            else
            {
                // Log what we are about to do.
                _logger.LogTrace(
                    "Calculating a default local storage path"
                    );

                // Create a default path to our storage file.
                blob.LocalFilePath = Path.Combine(
                    "C:\\Blue\\",
                    blob.Id.ToFolderPath(
                        FolderLevels.One
                        ),
                    blob.Id.ToFileName(
                        safeExt,
                        FolderLevels.One
                        )
                    );

                // Log what we are about to do.
                _logger.LogTrace(
                    "Setting the file to not encrypted"
                    );

                // By default we don't encrypt the files.
                blob.EncryptedAtRest = false;
            }

            // Log what we are about to do.
            _logger.LogTrace(
                "Setting the length of the BLOB"
                );

            // Set the length of the BLOB.
            blob.Length = stream.Length;

            // Log what we are about to do.
            _logger.LogTrace(
                "Ensuring the local storage path exists"
                );

            // Ensure the storage path exists.
            Directory.CreateDirectory(
                Path.GetDirectoryName(blob.LocalFilePath) ?? "C:\\Blue\\"
                );

            // Log what we are about to do.
            _logger.LogTrace(
                "Creating the local storage file"
                );

            // Create the storage for the BLOB.
            using var fileStream = File.Create(blob.LocalFilePath);

            // Should we encrypt the file?
            if (blob.EncryptedAtRest)
            {
                // Log what we are about to do.
                _logger.LogTrace(
                    "Encrypting the BLOB bits"
                    );

                // Encrypt the bits.
                var encryptedStream = await _cryptographer.AesEncryptAsync(
                    stream,
                    cancellationToken
                    ).ConfigureAwait(false);

                // Log what we are about to do.
                _logger.LogTrace(
                    "Copying the BLOB bits to local storage"
                    );

                // Copy the bits.
                await encryptedStream.CopyToAsync(
                    fileStream,
                    cancellationToken
                    ).ConfigureAwait(false);
            }
            else
            {
                // Log what we are about to do.
                _logger.LogTrace(
                    "Copying the BLOB bits to local storage"
                    );

                // Copy the bits.
                await stream.CopyToAsync(
                    fileStream,
                    cancellationToken
                    ).ConfigureAwait(false);
            }

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IBlobRepository.CreateAsync)
                );

            // Create the entity.
            var result = await _blobRepository.CreateAsync(
                blob,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to create a BLOB from a stream!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to create a BLOB from a stream!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(
        BlobModel blob,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blob, nameof(blob))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Updating the {name} model stats",
                nameof(BlobModel)
                );

            // Ensure the stats are correct.
            blob.LastUpdatedOnUtc = DateTime.UtcNow;
            blob.LastUpdatedBy = userName;

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IBlobRepository.DeleteAsync)
                );

            // Perform the operation.
            await _blobRepository.DeleteAsync(
                blob,
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to delete a BLOB!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to delete a BLOB!",
                innerException: ex
                );
        }
    }

    #endregion
}
