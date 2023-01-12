
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// This class contains extension methods related to the <see cref="WebApplicationBuilder"/>
/// type.
/// </summary>
public static class WebApplicationBuilderExtensions005
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method registers hosted services that are required for the 
    /// <see cref="CG.Blue"/> service layer.
    /// </summary>
    /// <param name="webApplicationBuilder">The web application builder to 
    /// use for the operation.</param>
    /// <param name="sectionName">The configuration section to use for the 
    /// operation. Defaults to <c>SVC</c>.</param>
    /// <param name="bootstrapLogger">The optional bootstrap logger to use 
    /// for the operation.</param>
    /// <returns>The value of the <paramref name="webApplicationBuilder"/>
    /// parameter, for chaining calls together, Fluent style</returns>
    public static WebApplicationBuilder AddBlueServices(
        this WebApplicationBuilder webApplicationBuilder,
        string sectionName = "SVC",
        ILogger? bootstrapLogger = null
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfNull(webApplicationBuilder, nameof(webApplicationBuilder))
            .ThrowIfNullOrEmpty(sectionName, nameof(sectionName));

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Configuring Blue hosted service options from the {section} section",
            sectionName
            );

        // Configure the hosted services options.
        webApplicationBuilder.Services.ConfigureOptions<BlueHostedServicesOptions>(
            webApplicationBuilder.Configuration.GetSection(sectionName),
            out var hostedServiceOptions
            );

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Adding a Blue HTTP client."
            );

        // Add the HTTP client.
        webApplicationBuilder.Services.AddHttpClient();

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Adding Blue hosted services."
            );

        // Add the hosted services.
        //webApplicationBuilder.Services.AddHostedService<WarmupService>();

        // Tell the world what we are about to do.
        //bootstrapLogger?.LogDebug(
        //    "Adding Blue SignalR services."
        //    );

        // Add SignalR
        //webApplicationBuilder.Services.AddSignalR(options =>
        //{
            // Is this a development environment?
        //    if (webApplicationBuilder.Environment.IsDevelopment())
        //    {
                // Enable better errors.
        //        options.EnableDetailedErrors = true;
        //    }
        //});

        // Tell the world what we are about to do.
        //bootstrapLogger?.LogDebug(
        //    "Adding the SignalR hubs."
        //    );

        // Add our SignalR hub.
        //webApplicationBuilder.Services.AddSingleton<SignalRHub>();

        // Return the application builder.
        return webApplicationBuilder;
    }

    #endregion
}

