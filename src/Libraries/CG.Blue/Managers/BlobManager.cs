
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
    /// This field contains the repository for this manager.
    /// </summary>
    internal protected readonly IBlobRepository _fileTypeRepository = null!;

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
    /// <param name="fileTypeRepository">The file type repository to use
    /// with this manager.</param>
    /// <param name="logger">The logger to use with this manager.</param>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    public BlobManager(
        IOptions<BlueBllOptions> bllOptions,
        IBlobRepository fileTypeRepository,
        ILogger<IBlobManager> logger
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNull(bllOptions, nameof(bllOptions))
            .ThrowIfNull(fileTypeRepository, nameof(fileTypeRepository))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s)
        _blobStorageOptions = bllOptions.Value.BlobStorage;
        _fileTypeRepository = fileTypeRepository;
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
        MimeTypeModel mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNull(stream, nameof(stream))
            .ThrowIfNull(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Create the BLOB model.
            var blob = new BlobModel()
            {
                Id = Guid.NewGuid()
            };

            // Get the extension associated with the MIME type.
            var safeExt = mimeType.FileTypes.FirstOrDefault()?.Extension;

            // Is the extension missing?
            if (string.IsNullOrEmpty(safeExt))
            {
                // Panic!!
                throw new ArgumentException(
                    $"The mime type: '{mimeType.Type}/{mimeType.SubType}' does not have an extension!"
                    );
            }

            // Do we have BLOB storage options?
            if (_blobStorageOptions is not null)
            {
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

                // Should we encrypt the BLOB?
                blob.EncryptedAtRest = _blobStorageOptions.EncryptAtRest;
            }
            else
            {
                // Create a default path to our storage file.
                blob.LocalFilePath = Path.Combine(
                    "C:\\Blue\\",
                    blob.Id.ToFolderPath(
                        FolderLevels.Single
                        ),
                    blob.Id.ToFileName(
                        safeExt,
                        FolderLevels.Single
                        )
                    );

                // By default we don't encrypt the files.
                blob.EncryptedAtRest = false;
            }

            // Should we encrypt the file?
            if (blob.EncryptedAtRest)
            {
                // TODO : write the code for this.
                throw new NotImplementedException();
            }

            // Ensure the path exists.
            Directory.CreateDirectory(
                Path.GetDirectoryName(blob.LocalFilePath) ?? "C:\\Blue\\"
                );

            // Create the storage for the BLOB.
            using var fileStream = File.Create(blob.LocalFilePath);

            // Copy the bits.
            await stream.CopyToAsync(
                fileStream,
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
                "Failed to create a BLOB from a stream!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to create a BLOB from a stream!",
                innerException: ex
                );
        }
    }

    #endregion
}
