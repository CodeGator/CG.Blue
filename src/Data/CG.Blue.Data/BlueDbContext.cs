
namespace CG.Blue.Data;

/// <summary>
/// This class is a data-context for the <see cref="CG.Blue"/> microservice.
/// </summary>
public class BlueDbContext : DbContext
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the collection of BLOB meta-data.
    /// </summary>
    public virtual DbSet<BlobEntity> Blobs { get; set; } = null!;

    /// <summary>
    /// This property contains the collection of file types.
    /// </summary>
    public virtual DbSet<FileTypeEntity> FileTypes { get; set; } = null!;

    /// <summary>
    /// This property contains the collection of MIME types.
    /// </summary>
    public virtual DbSet<MimeTypeEntity> MimeTypes { get; set; } = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlueDbContext"/>
    /// class.
    /// </summary>
    /// <param name="options">The options to use with this data-context.</param>
    public BlueDbContext(
        DbContextOptions<BlueDbContext> options
        ) : base(options)
    {

    }

    #endregion

    // *******************************************************************
    // Protected methods.
    // *******************************************************************

    #region Protected methods

    /// <summary>
    /// This method is called to create the data model.
    /// </summary>
    /// <param name="modelBuilder">The builder to use for the operation.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map the entities.
        modelBuilder.ApplyConfiguration(new BlobEntityMap(modelBuilder));
        modelBuilder.ApplyConfiguration(new FileTypeEntityMap(modelBuilder));
        modelBuilder.ApplyConfiguration(new MimeTypeEntityMap(modelBuilder));

        // Give the base class a chance.
        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
