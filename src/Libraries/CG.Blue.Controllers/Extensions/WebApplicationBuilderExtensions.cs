﻿
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// This class contains extension methods related to the <see cref="WebApplicationBuilder"/>
/// type.
/// </summary>
public static class WebApplicationBuilderExtensions002
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method adds REST controllers for the <see cref="CG.Blue"/> 
    /// service layer.
    /// </summary>
    /// <param name="webApplicationBuilder">The web application builder to
    /// use for the operation.</param>
    /// <param name="sectionName">The configuration section to use for the 
    /// operation. Defaults to <c>CTRL</c>.</param>
    /// <param name="bootstrapLogger">The bootstrap logger to use for the 
    /// operation.</param>
    /// <returns>The value of the <paramref name="webApplicationBuilder"/>
    /// parameter, for chaining calls together, Fluent style.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever
    /// one or more arguments are missing, or invalid.</exception>
    public static WebApplicationBuilder AddBlueControllers(
        this WebApplicationBuilder webApplicationBuilder,
        string sectionName = "CTRL",
        ILogger? bootstrapLogger = null
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(webApplicationBuilder, nameof(webApplicationBuilder));

        // Tell the world what we are about to do.
        bootstrapLogger?.LogDebug(
            "Adding the Blue controller assembly"
            );

        // Add this controller assembly an application part.
        webApplicationBuilder.Services.AddControllers().AddApplicationPart(
            Assembly.GetExecutingAssembly()
        );

        // Return the application builder.
        return webApplicationBuilder;
    }

    #endregion
}
