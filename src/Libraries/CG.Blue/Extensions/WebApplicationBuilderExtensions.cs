
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// This class contains extension methods related to the <see cref="WebApplicationBuilder"/>
/// type.
/// </summary>
public static class WebApplicationBuilderExtensions001
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method adds managers, directors, and related services, for 
    /// the <see cref="CG.Blue"/> business logic layer.
    /// </summary>
    /// <param name="webApplicationBuilder">The web application builder to
    /// use for the operation.</param>
    /// <param name="sectionName">The configuration section to use for the 
    /// operation. Defaults to <c>BLL</c>.</param>
    /// <param name="bootstrapLogger">The bootstrap logger to use for the 
    /// operation.</param>
    /// <returns>The value of the <paramref name="webApplicationBuilder"/>
    /// parameter, for chaining calls together, Fluent style.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever
    /// one or more arguments are missing, or invalid.</exception>
    public static WebApplicationBuilder AddBlueManagers(
        this WebApplicationBuilder webApplicationBuilder,
        string sectionName = "BLL",
        ILogger? bootstrapLogger = null
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(webApplicationBuilder, nameof(webApplicationBuilder));

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Configuring BLL options from the {section} section",
            sectionName
            );

        // Configure the BLL options.
        webApplicationBuilder.Services.ConfigureOptions<BlueBllOptions>(
            webApplicationBuilder.Configuration.GetSection(sectionName),
            out var bllOptions
            );

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Wiring up the Blue managers"
            );

        // Add the managers.
        webApplicationBuilder.Services.AddScoped<IBlobManager, BlobManager>();
        webApplicationBuilder.Services.AddScoped<IFileTypeManager, FileTypeManager>();
        webApplicationBuilder.Services.AddScoped<IMimeTypeManager, MimeTypeManager>();

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Wiring up the Blue directors"
            );

        // Add the directors.
        webApplicationBuilder.Services.AddScoped<IContentDirector, ContentDirector>();

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Wiring up the Blue factories"
            );

        // Add the factories.
        //webApplicationBuilder.Services.AddScoped<IProcessorFactory, ProcessorFactory>();

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Wiring up the shared cryptographers"
            );

        // Add the shared cryptographers
        webApplicationBuilder.AddCryptographyWithSharedKeys(
            sectionName: sectionName,
            bootstrapLogger: bootstrapLogger
            );

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Wiring up the Blue facades"
            );

        // Add the facades.
        webApplicationBuilder.Services.AddScoped<ISupportFacade, SupportFacade>();

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Wiring up the Blue API"
            );

        // Add the API.
        webApplicationBuilder.Services.AddScoped<IBlueApi, BlueApi>();

        // Return the application builder.
        return webApplicationBuilder;
    }

    #endregion
}
