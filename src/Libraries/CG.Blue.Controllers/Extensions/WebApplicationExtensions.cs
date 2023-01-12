﻿
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

        // Return the application.
        return webApplication;
    }

    #endregion
}
