

namespace CG.Blue.Data.Maps;

/// <summary>
/// This class is an EFCore configuration map for the <see cref="MimeTypeEntity"/>
/// entity type.
/// </summary>
internal class MimeTypeEntityMap : AuditedEntityMapBase<MimeTypeEntity>
{
    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="MimeTypeEntityMap"/>
    /// class.
    /// </summary>
    /// <param name="modelBuilder">The model builder to use with this map.</param>
    public MimeTypeEntityMap(
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
    /// This method configures the <see cref="MimeTypeEntity"/> entity.
    /// </summary>
    /// <param name="builder">The builder to use for the operation.</param>
    public override void Configure(
        EntityTypeBuilder<MimeTypeEntity> builder
        )
    {
        // Setup the table.
        builder.ToTable(
            "MimeTypes",
            "Blue"
            );

        // Setup the property.
        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        // Setup the primary key.
        builder.HasKey(e => new { e.Id });

        // Setup the column.
        builder.Property(e => e.Type)
            .HasMaxLength(127)
            .IsUnicode(false)
            .IsRequired();

        // Setup the column.
        builder.Property(e => e.SubType)
            .HasMaxLength(127)
            .IsUnicode(false)
            .IsRequired();

        // Setup the index.
        builder.HasIndex(e => new
        {
            e.Type,
            e.SubType
        },
        "IX_MimeTypes"
        ).IsUnique();
    }

    #endregion
}
