
namespace CG.Blue.Data.Maps;

/// <summary>
/// This class is an EFCore configuration map for the <see cref="BlobEntity"/>
/// entity type.
/// </summary>
internal class BlobEntityMap : AuditedEntityMapBase<BlobEntity>
{
    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlobEntityMap"/>
    /// class.
    /// </summary>
    /// <param name="modelBuilder">The model builder to use with this map.</param>
    public BlobEntityMap(
        ModelBuilder modelBuilder
        ) : base(modelBuilder)
    {

    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method configures the <see cref="BlobEntity"/> entity.
    /// </summary>
    /// <param name="builder">The builder to use for the operation.</param>
    public override void Configure(
        EntityTypeBuilder<BlobEntity> builder
        )
    {
        // Setup the table.
        builder.ToTable(
            "Blobs",
            "Blue"
            );

        // Setup the property.
        builder.Property(e => e.Id)
            .IsRequired();

        // Setup the primary key.
        builder.HasKey(e => new { e.Id });

        // Setup the column.
        builder.Property(e => e.LocalFilePath)
            .HasMaxLength(Globals.Models.Blobs.FilePathLength)
            .IsUnicode(false)
            .IsRequired();

        // Setup the column.
        builder.Property(e => e.EncryptedAtRest)
            .IsRequired();

        // Setup the index.
        builder.HasIndex(e => new
        {
            e.EncryptedAtRest,
            e.LocalFilePath
        },
        "IX_Blobs"
        );
    }

    #endregion
}
