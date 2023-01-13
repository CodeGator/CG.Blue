
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// This class contains extension methods related to the <see cref="WebApplication"/>
/// type.
/// </summary>
public static class WebApplicationExtensions001
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method registers any middleware or startup code required for
    /// the <see cref="CG.Blue"/> service layer.
    /// </summary>
    /// <param name="webApplication">The web application builder to 
    /// use for the operation.</param>
    /// <returns>The value of the <paramref name="webApplication"/>
    /// parameter, for chaining calls together, Fluent style</returns>
    public static WebApplication UseBlueControllers(
        this WebApplication webApplication
        )
    {
        // Log what we are about to do.
        webApplication.Logger.LogDebug(
            "Mapping Blue controllers"
            );

        // Wire up controller mapping.
        webApplication.MapControllers();

        // Log what we are about to do.
        webApplication.Logger.LogDebug(
            "Adding ODATA query request"
            );

        // Use ODATA request middleware.
        webApplication.UseODataQueryRequest();

        // Log what we are about to do.
        webApplication.Logger.LogDebug(
            "Adding ODATA API versioning"
            );

        // Use API versioned ODATA batch middleware.
        webApplication.UseVersionedODataBatching();

        // Is this as development environment?
        if (webApplication.Environment.IsDevelopment())
        {
            // Log what we are about to do.
            webApplication.Logger.LogDebug(
                "Adding ODATA route debugging"
                );

            // Enable ODATA route debugging.
            webApplication.UseODataRouteDebug();

            // Log what we are about to do.
            webApplication.Logger.LogDebug(
                "Adding Swagger"
                );

            // Enable Swagger
            webApplication.UseSwagger();

            // Log what we are about to do.
            webApplication.Logger.LogDebug(
                "Adding Swagger UI"
                );

            // Enable Swagger UI.
            webApplication.UseSwaggerUI(options =>
            {
                var descriptions = webApplication.DescribeApiVersions();

                // build a swagger endpoint for each discovered API version
                foreach (var description in descriptions)
                {
                    var url = $"/swagger/{description.GroupName}/swagger.json";
                    var name = description.GroupName.ToUpperInvariant();
                    options.SwaggerEndpoint(url, name);
                }
            });
        }

        // Return the application.
        return webApplication;
    }

    #endregion
}
