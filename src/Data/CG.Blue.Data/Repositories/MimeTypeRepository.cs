
using System.Runtime.CompilerServices;

namespace CG.Blue.Data.Repositories;

/// <summary>
/// This class is an EFCORE implementation of the <see cref="IMimeTypeRepository"/>
/// interface.
/// </summary>
internal class MimeTypeRepository : 
    RepositoryBase<MimeTypeRepository, BlueDbContext>,
    IMimeTypeRepository
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
    /// This constructor creates a new instance of the <see cref="MimeTypeRepository"/>
    /// class.
    /// </summary>
    /// <param name="mapper">The auto-mapper to use with this repository.</param>
    /// <param name="dbContext">The data-context to use with this repository.</param>
    /// <param name="logger">The logger to use with this repository.</param>
    public MimeTypeRepository(
        IMapper mapper,
        BlueDbContext dbContext,
        ILogger<MimeTypeRepository> logger
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
                "Searching for mime types"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.MimeTypes.AnyAsync(
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
                "Failed to search for mime types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for mime types!",
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
            _logger.LogDebug(
                "Searching for mime types"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.MimeTypes.AnyAsync(x =>
                x.Type == type && x.SubType == subType,
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
                "Failed to search for mime types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for mime types!",
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
                "Searching for mime types"
                );

            // Search for any entities in the data-store.
            var data = await _dbContext.MimeTypes.CountAsync(
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
                "Failed to count mime types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to count mime types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<MimeTypeModel> CreateAsync(
        MimeTypeModel mimeType,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeType, nameof(mimeType));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Converting a {entity} model to an entity",
                nameof(MimeTypeModel)
                );

            // Convert the model to an entity.
            var entity = _mapper.Map<MimeTypeEntity>(
                mimeType
                );

            // Did we fail?
            if (entity is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(MimeTypeModel)} model to an entity."
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Adding the {entity} to the {ctx} data-context.",
                nameof(MimeTypeModel),
                nameof(BlueDbContext)
                );

            // Add the entity to the data-store.
            _dbContext.MimeTypes.Attach(entity);

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
                nameof(MimeTypeModel)
                );

            // Convert the entity to a model.
            var result = _mapper.Map<MimeTypeModel>(
                entity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(MimeTypeModel)} entity " +
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
                "Failed to create a mime type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to create a mime type!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(
        MimeTypeModel mimeType,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeType, nameof(mimeType));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "looking for the tracked {entity} instance from the {ctx} data-context",
                nameof(MimeTypeEntity),
                nameof(BlueDbContext)
                );

            // Find the tracked entity (if any).
            var entity = await _dbContext.MimeTypes.FindAsync(
                mimeType.Id,
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
                nameof(MimeTypeEntity),
                nameof(BlueDbContext)
                );

            // Delete from the data-store.
            _dbContext.MimeTypes.Remove(
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
                "Failed to delete a mime type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to delete a mime type!",
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
            List<MimeTypeEntity> data = new();

            // Log what we are about to do.
            _logger.LogDebug(
                "Searching for matching mime type(s)."
                );            

            // Search for all mime types.
            if (string.IsNullOrEmpty(type) && string.IsNullOrEmpty(subType)) 
            {
                data = await _dbContext.MimeTypes
                    .OrderBy(x => x.Type)
                    .ThenBy(x => x.SubType)
                    .Include(x => x.FileTypes)
                    .ToListAsync(
                        cancellationToken
                        ).ConfigureAwait(false);
            }

            // Search for mime types that match the type.
            else if (!string.IsNullOrEmpty(type) && string.IsNullOrEmpty(subType))
            {
                data = await _dbContext.MimeTypes.Where(x => 
                    x.Type == type
                    ).OrderBy(x => x.Type)
                    .ThenBy(x => x.SubType)
                    .Include(x => x.FileTypes)
                    .ToListAsync(
                        cancellationToken
                        ).ConfigureAwait(false);
            }

            // Search for mime types that match the sub-type.
            else if (string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(subType))
            {
                data = await _dbContext.MimeTypes.Where(x => 
                    x.SubType == subType
                    ).OrderBy(x => x.Type)
                    .ThenBy(x => x.SubType)
                    .Include(x => x.FileTypes)
                    .ToListAsync(
                        cancellationToken
                        ).ConfigureAwait(false);
            }

            // Search for mime types that match the type and sub-type.
            else
            {
                data = await _dbContext.MimeTypes.Where(x => 
                    x.Type == type && 
                    x.SubType == subType
                    ).OrderBy(x => x.Type)
                    .ThenBy(x => x.SubType)
                    .Include(x => x.FileTypes)
                    .ToListAsync(
                        cancellationToken
                        ).ConfigureAwait(false);
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Converting the {entity} entities to models",
                nameof(MimeTypeModel)
                );

            // Convert the entities to models.
            var models = data.Select(x => 
                _mapper.Map<MimeTypeModel>(x)
                );

            // Return the result.
            return models;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for mime types by type and/or sub-type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for mime " +
                "types by type and/or sub-type!",
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
            _logger.LogDebug(
                "Searching for file types."
                );

            // Perform the mime type search.
            var mimeTypes = await _dbContext.MimeTypes
                .Include(x => x.FileTypes)
                .ToListAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Convert the entities to models.
            var result = mimeTypes.Select(x =>
                _mapper.Map<MimeTypeModel>(x)
                );

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for mime types!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for mime types!",
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
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNullOrEmpty(extension, nameof(extension));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Searching for matching mime types."
                );

            // Get the matching mime types.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var mimeTypes = await _dbContext.MimeTypes.Join(
                _dbContext.FileTypes, 
                x => x.Id,
                y => y.MimeType.Id,
                (x,y) => x
                ).Where(x => x.FileTypes.Any(y => y.Extension == extension))
                .Include(x => x.FileTypes)
                .OrderBy(x => x.Type).ThenBy(x => x.SubType)
                .ToListAsync(
                    cancellationToken
                    );
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // Convert the entity to a model.
            var result = mimeTypes.Select(x => 
                _mapper.Map<MimeTypeModel>(x)
                );

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for mime types by extension!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for mime " +
                "types by extension!",
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
            _logger.LogDebug(
                "Searching for file types."
                );

            // Perform the mime type search.
            var mimeType = await _dbContext.MimeTypes.Where(x => 
                x.Id == id
                ).Include(x => x.FileTypes)
                .FirstOrDefaultAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Did we fail?
            if (mimeType is null)
            {
                return null;
            }

            // Convert the entity to a model.
            var result = _mapper.Map<MimeTypeModel>(
                mimeType
                );

            // Return the results.
            return result;
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to search for a mime type by id!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to search for a mime " +
                "type by id!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task<MimeTypeModel> UpdateAsync(
        MimeTypeModel mimeType,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeType, nameof(mimeType));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Looking for a matching {entity} entity in the {ctx} data-context.",
                nameof(MimeTypeEntity),
                nameof(BlueDbContext)
                );

            // Look for the given entity.
            var entity = await _dbContext.MimeTypes.Where(x =>
                x.Id == mimeType.Id
                ).FirstOrDefaultAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

            // Did we fail?
            if (entity is null)
            {
                // Panic!!
                throw new KeyNotFoundException(
                    $"The file type: {mimeType.Id} was not found!"
                    );
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Updating a {entity} entity in the {ctx} data-context.",
                nameof(MimeTypeModel),
                nameof(BlueDbContext)
                );

            // Update the editable properties.
            entity.Type = mimeType.Type;
            entity.SubType = mimeType.SubType;
            entity.LastUpdatedOnUtc = mimeType.LastUpdatedOnUtc;
            entity.LastUpdatedBy = mimeType.LastUpdatedBy ?? "anonymous";

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

            // Convert the entity to a model.
            var result = _mapper.Map<MimeTypeModel>(
                entity
                );

            // Did we fail?
            if (result is null)
            {
                // Panic!!
                throw new AutoMapperMappingException(
                    $"Failed to map the {nameof(MimeTypeModel)} entity to a model."
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
                "Failed to update a mime type!"
                );

            // Provider better context.
            throw new RepositoryException(
                message: $"The repository failed to update a mime type!",
                innerException: ex
                );
        }
    }

    #endregion
}
