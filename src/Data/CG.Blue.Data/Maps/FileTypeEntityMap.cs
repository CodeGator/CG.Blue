
namespace CG.Blue.Data.Maps;

/// <summary>
/// This class is an EFCore configuration map for the <see cref="FileTypeEntity"/>
/// entity type.
/// </summary>
internal class FileTypeEntityMap : AuditedEntityMapBase<FileTypeEntity>
{
    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="FileTypeEntityMap"/>
    /// class.
    /// </summary>
    /// <param name="modelBuilder">The model builder to use with this map.</param>
    public FileTypeEntityMap(
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
    /// This method configures the <see cref="FileTypeEntity"/> entity.
    /// </summary>
    /// <param name="builder">The builder to use for the operation.</param>
    public override void Configure(
        EntityTypeBuilder<FileTypeEntity> builder
        )
    {
        // Setup the table.
        builder.ToTable(
            "FileTypes",
            "Blue"
            );

        // Setup the property.
        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        // Setup the primary key.
        builder.HasKey(e => new { e.Id });

        // Setup the column.
        builder.Property(e => e.Extension)
            .HasMaxLength(260)
            .IsUnicode(false)
            .IsRequired();

        // Setup the relationship.
        _modelBuilder.Entity<FileTypeEntity>()
            .HasOne(e => e.MimeType)
            .WithMany(e => e.FileTypes)
            .HasForeignKey(e => e.MimeTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Setup the index.
        builder.HasIndex(e => new
        {
            e.Extension
        },
        "IX_FileTypes"
        );
    }

    #endregion
}
