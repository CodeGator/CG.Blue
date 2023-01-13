
namespace CG.Blue.Configuration;

/// <summary>
/// This class is default implementation of the <see cref="IModelConfiguration"/>
/// for the <see cref="MimeTypeModel"/> model type.
/// </summary>
public class MimeTypeModelConfiguration : IModelConfiguration
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <inheritdoc/>
    public void Apply(
        ODataModelBuilder builder,
        ApiVersion apiVersion,
        string? routePrefix
        )
    {
        // Sanity check the route prefix.
        if (routePrefix != "odata")
        {
            return;
        }

        // Configure the version.
        switch (apiVersion.MajorVersion)
        {
            case 1:
            default:
                ConfigureV1(builder);
                break;
        }
    }

    #endregion

    // *******************************************************************
    // Private methods.
    // *******************************************************************

    #region Private methods

    /// <summary>
    /// This method performs a V1 configuration for the <see cref="MimeTypeModel"/>
    /// model type.
    /// </summary>
    /// <param name="builder">The builder to use for the operation.</param>
    /// <returns>An entity type configuration object.</returns>
    private static EntityTypeConfiguration<MimeTypeModel> ConfigureV1(
        ODataModelBuilder builder
        )
    {
        // Get the entity set.
        var mimeType = builder.EntitySet<MimeTypeModel>(
            "MimeType"
            ).EntityType;
         /*      
        // Define the key.
        mimeType.HasKey(p => p.Id);

        // Add the property
        mimeType.Property(x => x.Type)
            .IsRequired().Filter();

        // Add the property
        mimeType.Property(x => x.SubType)
            .IsRequired().Filter();
        
        // We allow these operations.
        mimeType.Count().Filter().OrderBy().Expand().Select();
        */
        // Return the results.
        return mimeType;
    }

    #endregion
}
