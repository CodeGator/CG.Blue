
namespace CG.Blue.Managers;

/// <summary>
/// This class is a default implementation of the <see cref="IMimeTypeManager"/>
/// interface.
/// </summary>
internal class MimeTypeManager : IMimeTypeManager
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the repository for this manager.
    /// </summary>
    internal protected readonly IMimeTypeRepository _mimeTypeRepository = null!;

    /// <summary>
    /// This field contains the logger for this manager.
    /// </summary>
    internal protected readonly ILogger<IMimeTypeManager> _logger = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="MimeTypeManager"/>
    /// class.
    /// </summary>
    /// <param name="mimeTypeRepository">The mime type repository to use
    /// with this manager.</param>
    /// <param name="logger">The logger to use with this manager.</param>
    /// <exception cref="ArgumentException">This exception is thrown whenever one
    /// or more arguments are missing, or invalid.</exception>
    public MimeTypeManager(
        IMimeTypeRepository mimeTypeRepository,
        ILogger<IMimeTypeManager> logger
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeTypeRepository, nameof(mimeTypeRepository))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s)
        _mimeTypeRepository = mimeTypeRepository;
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
                nameof(IMimeTypeRepository.AnyAsync)
                );

            // Perform the search.
            return await _mimeTypeRepository.AnyAsync(
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for mime types!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for mime types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<bool> AnyAsync(
        string type,
        string subType,
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.AnyAsync)
                );

            // Perform the search.
            return await _mimeTypeRepository.AnyAsync(
                type,
                subType,
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for mime types!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for mime types!",
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
                nameof(IMimeTypeRepository.CountAsync)
                );

            // Perform the search.
            return await _mimeTypeRepository.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to count mime types!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to count mime types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<MimeTypeModel> CreateAsync(
        MimeTypeModel mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Updating the {name} model stats",
                nameof(MimeTypeModel)
                );

            // Ensure the stats are correct.
            mimeType.CreatedOnUtc = DateTime.UtcNow;
            mimeType.CreatedBy = userName;
            mimeType.LastUpdatedBy = null;
            mimeType.LastUpdatedOnUtc = null;

            // types are always lower case.
            mimeType.Type = mimeType.Type.ToLower().Trim();

            // sub-types are always lower case.
            mimeType.SubType = mimeType.SubType.ToLower().Trim();

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.CreateAsync)
                );

            // Perform the operation.
            return await _mimeTypeRepository.CreateAsync(
                mimeType,
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to create a new mime type!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to create a new mime type!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(
        MimeTypeModel mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Updating the {name} model stats",
                nameof(MimeTypeModel)
                );

            // Ensure the stats are correct.
            mimeType.LastUpdatedOnUtc = DateTime.UtcNow;
            mimeType.LastUpdatedBy = userName;

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.DeleteAsync)
                );

            // Perform the operation.
            await _mimeTypeRepository.DeleteAsync(
                mimeType,
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to delete a mime type!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to delete a mime type!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<IEnumerable<MimeTypeModel>> FindAllAsync(
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.FindAllAsync)
                );

            // Perform the operation.
            var mimeTypes = await _mimeTypeRepository.FindAllAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return mimeTypes;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for mime types!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for mime types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<IEnumerable<MimeTypeModel>> FindByTypesAsync(
        string type,
        string subType,
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.FindByTypesAsync)
                );

            // Perform the operation.
            var mimeTypes = await _mimeTypeRepository.FindByTypesAsync(
                type,
                subType,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return mimeTypes;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for matching mime types by the given " +
                "type: '{type}' and subtype: '{subType}'!",
                type,
                subType
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for matching mime " +
                $"types by the given type: '{type}' and subtype: '{subType}'!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<IEnumerable<MimeTypeModel>> FindByTypeAsync(
        string mimeType,
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            // Split the mime type into parts.
            var parts = mimeType.Split('/');

            // Sanity check the results.
            if (parts.Length != 2)
            {
                // Panic!!
                throw new ArgumentException(
                    "The mime type was invalid!"
                    );
            }

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.FindByTypesAsync)
                );

            // Perform the operation.
            var mimeTypes = await _mimeTypeRepository.FindByTypesAsync(
                parts[0],
                parts[1],
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return mimeTypes;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for matching mime types by the given " +
                "mime type: '{type}'!",
                mimeType
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for matching mime " +
                $"types by the given mime type: '{mimeType}'!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<IEnumerable<MimeTypeModel>> FindByExtensionAsync(
        string extension,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNullOrEmpty(extension, nameof(extension));

        try
        {
            // Should we add a leading '.' character?
            if (!extension.StartsWith('.'))
            {
                extension = $".{extension}";
            }

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.FindByExtensionAsync)
                );

            // Perform the operation.
            var mimeTypes = await _mimeTypeRepository.FindByExtensionAsync(
                extension,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return mimeTypes;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for matching mime types by the given " +
                "extension: '{ext}'",
                extension
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for matching " +
                $"mime types by the given extension: '{extension}'!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<MimeTypeModel?> FindByIdAsync(
        int id,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfZero(id, nameof(id));

        try
        {
            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.FindByExtensionAsync)
                );

            // Perform the operation.
            var mimeType = await _mimeTypeRepository.FindByIdAsync(
                id,
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return mimeType;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for a matching mime type by the " +
                "given id: '{id}'",
                id
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to search for a matching " +
                $"mime type by the given id: '{id}'!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<MimeTypeModel> UpdateAsync(
        MimeTypeModel mimeType,
        string userName,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeType, nameof(mimeType))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Updating the {name} model stats",
                nameof(MimeTypeModel)
                );

            // Ensure the stats are correct.
            mimeType.LastUpdatedOnUtc = DateTime.UtcNow;
            mimeType.LastUpdatedBy = userName;

            // types are always lower case.
            mimeType.Type = mimeType.Type.ToLower().Trim();

            // sub-types are always lower case.
            mimeType.SubType = mimeType.SubType.ToLower().Trim();

            // Log what we are about to do.
            _logger.LogTrace(
                "Deferring to {name}",
                nameof(IMimeTypeRepository.UpdateAsync)
                );

            // Perform the operation.
            return await _mimeTypeRepository.UpdateAsync(
                mimeType,
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to update a mime type!"
                );

            // Provider better context.
            throw new ManagerException(
                message: $"The manager failed to update a mime type!",
                innerException: ex
                );
        }
    }

    #endregion
}
