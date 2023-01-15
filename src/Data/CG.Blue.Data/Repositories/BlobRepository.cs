
namespace CG.Blue.Data.Repositories;

/// <summary>
/// This class is an EFCORE implementation of the <see cref="IBlobRepository"/>
/// interface.
/// </summary>
internal class BlobRepository : 
    RepositoryBase<BlobRepository, BlueDbContext>, 
    IBlobRepository
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
    /// This constructor creates a new instance of the <see cref="BlobRepository"/>
    /// class.
    /// </summary>
    /// <param name="mapper">The auto-mapper to use with this repository.</param>
    /// <param name="dbContext">The data-context to use with this repository.</param>
    /// <param name="logger">The logger to use with this repository.</param>
    public BlobRepository(
        IMapper mapper,
        BlueDbContext dbContext,        
        ILogger<BlobRepository> logger
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
                "Searching for BLOBs"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.Blobs.AnyAsync(
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
                "Failed to search for BLOBs!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for BLOBs!",
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
                "Searching for BLOBs"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.Blobs.CountAsync(
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
                "Failed to count BLOBs!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to count BLOBs!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<BlobModel> CreateAsync(
        BlobModel blob,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blob, nameof(blob));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Converting a {entity} model to an entity",
                nameof(BlobModel)
                );

            // Convert the model to an entity.
            var entity = _mapper.Map<BlobEntity>(
                blob
                );

            // Did we fail?
            if (entity is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(BlobModel)} model to an entity."
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Adding the {entity} to the {ctx} data-context.",
                nameof(BlobModel),
                nameof(BlueDbContext)
                );

            // If we leave this property set EFCORE will try to add the object to
            //   the data-context, which will fail because the mime type likely 
            //   already exists. 
            entity.MimeType = null;

            // Add the entity to the data-store.
            _dbContext.Blobs.Attach(entity);

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

            // Look for the new entity (with mime type).
            var newEntity = await _dbContext.Blobs.Where(x =>
                x.Id == entity.Id
                ).Include(x => x.MimeType)
                .FirstOrDefaultAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Should never happen, but, pffft, check it anyway.
            if (newEntity is null)
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"The BLOB: {entity.Id} was not found!"
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Converting a {entity} entity to a model",
                nameof(BlobModel)
                );

            // Convert the entity to a model.
            var result = _mapper.Map<BlobModel>(
                newEntity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(BlobEntity)} entity to a model."
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
                "Failed to create a BLOB!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to create a BLOB!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(
        BlobModel blob,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blob, nameof(blob));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "looking for the tracked {entity} instance from the {ctx} data-context",
                nameof(BlobEntity),
                nameof(BlueDbContext)
                );

            // Find the tracked entity (if any).
            var entity = await _dbContext.Blobs.FindAsync(
                blob.Id,
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
                nameof(BlobEntity),
                nameof(BlueDbContext)
                );

            // Delete from the data-store.
            _dbContext.Blobs.Remove(
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
                "Failed to delete a BLOB!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to delete a BLOB!",
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
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "looking for the tracked {entity} instance from the {ctx} data-context",
                nameof(BlobEntity),
                nameof(BlueDbContext)
                );

            // Find the tracked entity (if any).
            var entity = await _dbContext.Blobs.Where(x =>
                x.Id == id
                ).Include(x => x.MimeType)
                .FirstOrDefaultAsync(
                    cancellationToken
                    );

            // Did we fail?
            if (entity is null)
            {
                return null; // Nothing to do!
            }

            // Convert the entity to a model.
            var result = _mapper.Map<BlobModel>(
                entity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(BlobEntity)} entity to a model."
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
                "Failed to search for a BLOB by id!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for a BLOB by id!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<BlobModel?> UpdateAsync(
        BlobModel blob,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blob, nameof(blob));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Looking for a matching {entity} entity in the {ctx} data-context.",
                nameof(BlobModel),
                nameof(BlueDbContext)
                );

            // Look for the given entity.
            var entity = await _dbContext.Blobs.Where(x =>
                x.Id == blob.Id
                ).FirstOrDefaultAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Did we fail?
            if (entity is null)
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"The BLOB: {blob.Id} was not found!"
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Updating a {entity} entity in the {ctx} data-context.",
                nameof(FileTypeEntity),
                nameof(BlueDbContext)
                );

            // Update the editable properties.
            entity.LastReadOnUtc = blob.LastReadOnUtc;
            entity.LastUpdatedOnUtc = blob.LastUpdatedOnUtc;
            entity.LastUpdatedBy = blob.LastUpdatedBy ?? "anonymous";

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
                nameof(BlobEntity)
                );

            // Convert the entity to a model.
            var result = _mapper.Map<BlobModel>(
                entity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(BlobModel)} entity " +
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
                "Failed to update BLOB meta-data!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to update BLOB meta-data!",
                innerException: ex
                );
        }
    }

    #endregion
}
