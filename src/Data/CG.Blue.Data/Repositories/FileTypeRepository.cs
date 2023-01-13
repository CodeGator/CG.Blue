
namespace CG.Blue.Data.Repositories;

/// <summary>
/// This class is an EFCORE implementation of the <see cref="IFileTypeRepository"/>
/// interface.
/// </summary>
internal class FileTypeRepository : 
    RepositoryBase<FileTypeRepository, BlueDbContext>, 
    IFileTypeRepository
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the auto-mapper for this repository.
    /// </summary>
    internal protected readonly IMapper _mapper;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="FileTypeRepository"/>
    /// class.
    /// </summary>
    /// <param name="mapper">The auto-mapper to use with this repository.</param>
    /// <param name="dbContext">The data-context to use with this repository.</param>
    /// <param name="logger">The logger to use with this repository.</param>
    public FileTypeRepository(
        IMapper mapper,
        BlueDbContext dbContext,        
        ILogger<FileTypeRepository> logger
        ) : base(
            dbContext,
            logger
            )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mapper, nameof(mapper));

        // Save the reference(s).
        _mapper = mapper;
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
            _logger.LogDebug(
                "Searching for file types"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.FileTypes.AnyAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return data;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for file types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for file types!",
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
            _logger.LogDebug(
                "Searching for file types"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.FileTypes.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Return the results.
            return data;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to count file types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to count file types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<FileTypeModel> CreateAsync(
        FileTypeModel fileType,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(fileType, nameof(fileType));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Converting a {entity} model to an entity",
                nameof(FileTypeModel)
                );

            // Convert the model to an entity.
            var entity = _mapper.Map<FileTypeEntity>(
                fileType
                );

            // Did we fail?
            if (entity is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(FileTypeModel)} model to an entity."
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Adding the {entity} to the {ctx} data-context.",
                nameof(FileTypeModel),
                nameof(BlueDbContext)
                );

            // If we leave this property set EFCORE will try to add the object to
            //   the data-context, which will fail because the mime type likely 
            //   already exists. 
            entity.MimeType = null;

            // Add the entity to the data-store.
            _dbContext.FileTypes.Attach(entity);

            // Mark the entity as added so EFCORE will insert it.
            _dbContext.Entry(entity).State = EntityState.Added;
            
            // Log what we are about to do.
            _logger.LogDebug(
                "Saving changes to the {ctx} data-context",
                nameof(BlueDbContext)
                );

            // Save the changes.
            await _dbContext.SaveChangesAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Converting a {entity} entity to a model",
                nameof(FileTypeModel)
                );

            // Convert the entity to a model.
            var result = _mapper.Map<FileTypeModel>(
                entity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(FileTypeModel)} entity to a model."
                    );
            }

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to create a file type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to create a file type!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(
        FileTypeModel fileType,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(fileType, nameof(fileType));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "looking for the tracked {entity} instance from the {ctx} data-context",
                nameof(FileTypeEntity),
                nameof(BlueDbContext)
                );

            // Find the tracked entity (if any).
            var entity = await _dbContext.FileTypes.FindAsync(
                fileType.Id,
                cancellationToken
                );

            // Did we fail?
            if (entity is null)
            {
                return; // Nothing to do!
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Deleting an {entity} instance from the {ctx} data-context",
                nameof(FileTypeEntity),
                nameof(BlueDbContext)
                );

            // Delete from the data-store.
            _dbContext.FileTypes.Remove(
                entity
                );

            // Log what we are about to do.
            _logger.LogDebug(
                "Saving changes to the {ctx} data-context",
                nameof(BlueDbContext)
                );

            // Save the changes.
            await _dbContext.SaveChangesAsync(
                cancellationToken
                ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to delete a file type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to delete a file type!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<IEnumerable<FileTypeModel>> FindAllAsync(
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Searching file types."
                );

            // Perform the file type search.
            var fileTypes = await _dbContext.FileTypes
                .AsNoTracking()
                .ToListAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Convert the entities to a models.
            var models = fileTypes.Select(x =>
                _mapper.Map<FileTypeModel>(x)
                );

            // Return the results.
            return models;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for file types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for a file types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<FileTypeModel?> FindByExtensionAsync(
        string extension,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNullOrEmpty(extension, nameof(extension));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Searching for a matching file type."
                );

            // Perform the file type search.
            var fileType = await _dbContext.FileTypes.Where(x => 
                x.Extension == extension
                ).AsNoTracking()
                .FirstOrDefaultAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Did we fail?
            if (fileType is null)
            {
                return null; // Not found!
            }

            // Convert the entity to a model.
            var result = _mapper.Map<FileTypeModel>(
                fileType
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(FileTypeModel)} entity " +
                    "to a model."
                    );
            }

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for a file type by extension!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for a file " +
                "type by extension!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<FileTypeModel> UpdateAsync(
        FileTypeModel fileType,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(fileType, nameof(fileType));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Looking for a matching {entity} entity in the {ctx} data-context.",
                nameof(FileTypeEntity),
                nameof(BlueDbContext)
                );

            // Look for the given entity.
            var entity = await _dbContext.FileTypes.Where(x =>
                x.Id == fileType.Id
                ).FirstOrDefaultAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Did we fail?
            if (entity is null)
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"The file type: {fileType.Id} was not found!"
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Updating a {entity} entity in the {ctx} data-context.",
                nameof(FileTypeEntity),
                nameof(BlueDbContext)
                );

            // If we leave this property set EFCORE will try to update the object
            //   in the data-context, which will fail and isn't what we want to do
            //   in this context anyway.
            entity.MimeType = null;

            // Update the editable properties.
            entity.Extension = fileType.Extension;
            entity.LastUpdatedOnUtc = fileType.LastUpdatedOnUtc;
            entity.LastUpdatedBy = fileType.LastUpdatedBy ?? "anonymous";

            // We never change these 'read only' properties.
            _dbContext.Entry(entity).Property(x => x.Id).IsModified = false;
            _dbContext.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
            _dbContext.Entry(entity).Property(x => x.CreatedOnUtc).IsModified = false;

            // Log what we are about to do.
            _logger.LogDebug(
                "Saving changes to the {ctx} data-context",
                nameof(BlueDbContext)
                );

            // Save the changes.
            await _dbContext.SaveChangesAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Converting a {entity} entity to a model",
                nameof(FileTypeModel)
                );

            // Convert the entity to a model.
            var result = _mapper.Map<FileTypeModel>(
                entity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(FileTypeModel)} entity " +
                    "to a model."
                    );
            }

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to update a file type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to update a file type!",
                innerException: ex
                );
        }
    }

    #endregion
}
