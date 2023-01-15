
using CG.Seeding.Options;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

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
    /// This method adds middleware and startup logic for the <see cref="CG.Blue"/> 
    /// business logic layer.
    /// </summary>
    /// <param name="webApplication">The web application to use for the 
    /// operation.</param>
    /// <returns>The value of the <paramref name="webApplication"/>
    /// parameter, for chaining calls together, Fluent style.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever
    /// one or more arguments are missing, or invalid.</exception>
    public static WebApplication UseBlueManagers(
        this WebApplication webApplication
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(webApplication, nameof(webApplication));

        // Log what we are about to do.
        webApplication.Logger.LogDebug(
            "Fetching the BLL options, for the business layer."
            );

        // Get the BLL options.
        var bllOptions = webApplication.Services.GetRequiredService<
            IOptions<BlueBllOptions>
            >();

        // Do we have storage options?
        if (bllOptions.Value.BlobStorage is not null)
        {
            // Log what we are about to do.
            webApplication.Logger.LogDebug(
                "Fetching local storage root, for the business layer."
                );

            // Get the local storage root.
            var localStoragePath = bllOptions.Value.BlobStorage.LocalStoragePath;

            // Let's make a rooted version of that path, just in case the path
            //   we got from the options is relative.
            var rootedLocalStoragePath = Path.GetFullPath(localStoragePath);

            // Log what we are about to do.
            webApplication.Logger.LogDebug(
                "Ensuring we have access to the local storage root, for the business layer."
                );

            // Ensure the root path exists.
            Directory.CreateDirectory(
                rootedLocalStoragePath
                );

            // Should we drop the local storage tree on startup?
            if (bllOptions.Value.BlobStorage.DropLocalStorageOnStartup)
            {
                // Is this a development environment?
                if (webApplication.Environment.IsDevelopment())
                {
                    // Don't delete anything at the root level!
                    if (rootedLocalStoragePath.Length == "C:\\".Length ||
                        rootedLocalStoragePath.Length == "\\".Length)
                    {
                        // Log what we didn't do.
                        webApplication.Logger.LogWarning(
                            "We won't delete anything at the root level of a drive. " +
                            "Try moving the local storage root down a level."
                            );
                    }

                    // Don't delete ourselves!
                    else if (rootedLocalStoragePath == webApplication.Environment.ContentRootPath)
                    {
                        // Log what we didn't do.
                        webApplication.Logger.LogWarning(
                            "We won't delete anything from the websites content root. " +
                            "Try moving the local storage outside the website's content tree."
                            );
                    }

                    // Ok, the path is probably fine.
                    else
                    {
                        // Log what we are about to do.
                        webApplication.Logger.LogInformation(
                            "Dropping the local storage tree on startup, from: " +
                            "{path} downward",
                            rootedLocalStoragePath
                            );

                        // Recursively delete the local storage tree.
                        Directory.Delete(
                            rootedLocalStoragePath,
                            true
                            );
                    }                    
                }
                else
                {
                    // Log what we didn't do.
                    webApplication.Logger.LogWarning(
                        "Ignoring dropping local storage on startup because we " +
                        "aren't in a development environment."
                        );
                }
            }
            else
            {
                // Log what we didn't do.
                webApplication.Logger.LogWarning(
                    "Ignoring dropping local storage on startup because the " +
                    "DropLocalStorageOnStartup flag, in the {op} options, " +
                    "is either false, or missing.",
                    nameof(BlobStorageOptions)
                    );
            }
        }

        // Return the application.
        return webApplication;
    }

    #endregion
}
