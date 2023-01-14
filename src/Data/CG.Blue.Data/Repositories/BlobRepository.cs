
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


    #endregion
}
