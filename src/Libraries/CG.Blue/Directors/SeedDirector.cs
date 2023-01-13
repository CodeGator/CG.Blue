
namespace CG.Blue.Directors;

/// <summary>
/// This class is a default implementation of the <see cref="ISeedDirector"/>
/// interface.
/// </summary>
public class SeedDirector : 
    SeedDirectorBase<SeedDirector>, 
    ISeedDirector
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the mime type manager for this director.
    /// </summary>
    internal protected readonly IMimeTypeManager _mimeTypeManager = null!;

    /// <summary>
    /// This field contains the file type manager for this director.
    /// </summary>
    internal protected readonly IFileTypeManager _fileTypeManager = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="SeedDirector"/>
    /// class.
    /// </summary>
    /// <param name="fileTypeManager">The file type manager to use with 
    /// this director.</param>
    /// <param name="mimeTypeManager">The mime type manager to use with 
    /// this director.</param>
    /// <param name="logger">The logger to use with this director.</param>
    public SeedDirector(
        IFileTypeManager fileTypeManager,
        IMimeTypeManager mimeTypeManager,
        ILogger<SeedDirector> logger
        ) : base(logger)
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(fileTypeManager, nameof(fileTypeManager))
            .ThrowIfNull(mimeTypeManager, nameof(mimeTypeManager));

        // Save the reference(s).
        _fileTypeManager = fileTypeManager;
        _mimeTypeManager = mimeTypeManager;
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <inheritdoc/>
    public virtual async Task SeedMimeTypesFromIanaAsync(
        string userName,
        bool force = false,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Checking the force flag"
                );

            // Should we check for existing data?
            if (!force)
            {
                // Log what we are about to do.
                _logger.LogDebug(
                    "Checking for existing mime types"
                    );

                // Are there existing setting files?
                var hasExistingData = await _mimeTypeManager.AnyAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

                // Should we stop?
                if (hasExistingData)
                {
                    // Log what we didn't do.
                    _logger.LogWarning(
                        "Skipping seeding mime types because the 'force' flag " +
                        "was not specified and there are existing rows in the " +
                        "database."
                        );
                    return; // Nothing else to do!
                }
            }

            // Log what we are about to do.
            _logger.LogInformation(
                "Seeding directly from the IANA website. This may take a minute or two ..."
                );

            int docs = 0;
            long errors = 0;
            long skipped = 0;
            long rows = 0;

            // Log what we are about to do.
            _logger.LogDebug(
                "Creating an HTTP client handler"
                );

            // Create a handler.
            using var handler = new HttpClientHandler();
                        
            // Use default credentials.
            handler.UseDefaultCredentials = true;

            // Use cookies.
            handler.UseCookies = true;

            // Log what we are about to do.
            _logger.LogDebug(
                "Creating an HTTP client"
                );

            // Create an HTTP client.
            using var client = new HttpClient(handler);

            // Set the user agent.
            client.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.85 Safari/537.36"
                );

            // Set the base address.
            client.BaseAddress = new Uri("http://www.iana.org/assignments/media-types/");

            // We'll need several documents ...
            var endpoints = new string[]
            {
                "application.csv",
                "audio.csv",
                "font.csv",
                "image.csv",
                "message.csv",
                "model.csv",
                "multipart.csv",
                "text.csv",
                "video.csv"
            };

            // Log what we are about to do.
            _logger.LogDebug(
                "Looping through {count} IANA endpoints",
                endpoints.Count()
                );

            // Loop and process documents.
            foreach (var endpoint in endpoints)
            {
                try
                {
                    // Get a path to the csv file.
                    var path = Path.Combine(
                        Path.GetDirectoryName(
                            Environment.ProcessPath
                            ) ?? Environment.CurrentDirectory,
                        endpoint
                        );

                    // Do we have a copy of the file already?
                    string csv = "";
                    if (File.Exists(path))
                    {
                        // Get the information for the file.
                        var fi = new FileInfo(path);

                        // Is the file outdated?
                        if (DateTime.UtcNow.AddDays(-1) > fi.LastAccessTimeUtc)
                        {
                            // Log what we are about to do.
                            _logger.LogDebug(
                                "Fetching CSV text from remote {ep}",
                                endpoint
                                );

                            // Get the CSV.
                            csv = await client.GetStringAsync(
                                endpoint,
                                cancellationToken
                                ).ConfigureAwait(false);
                        }
                        else
                        {
                            // Log what we are about to do.
                            _logger.LogDebug(
                                "Fetching CSV text from local {ep}",
                                endpoint
                                );

                            // Read the CSV.
                            csv = await File.ReadAllTextAsync(
                                path,
                                cancellationToken
                                ).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        // Log what we are about to do.
                        _logger.LogDebug(
                            "Fetching CSV text from remote {ep}",
                            endpoint
                            );

                        // Get the CSV.
                        csv = await client.GetStringAsync(
                            endpoint,
                            cancellationToken
                            ).ConfigureAwait(false);
                    }

                    // Did we fail?
                    if (string.IsNullOrEmpty(csv))
                    {
                        // Log what happened.
                        _logger.LogWarning(
                            "Failed to fetch CSV text from {ep}",
                            endpoint
                            );

                        // Track the work.
                        errors++;

                        continue; // Nothing left to do.
                    }

                    // Write the document to disk.
                    await File.WriteAllTextAsync(
                        path,
                        csv,
                        cancellationToken
                        ).ConfigureAwait(false);

                    try
                    {
                        // Log what we are about to do.
                        _logger.LogDebug(
                            "Splitting lines for the CSV data"
                            );

                        // Parse the CSV into lines.
                        var lines = csv.Split(Environment.NewLine);

                        // Log what we are about to do.
                        _logger.LogDebug(
                            "Looping through {count} CSV lines",
                            lines.Count()
                            );

                        // Loop through the lines (skipping the header).
                        foreach (var line in lines.Skip(1))
                        {
                            // Log what we are about to do.
                            _logger.LogDebug(
                                "Splitting a CSV line into fields"
                                );

                            // Parse the line into fields.
                            var fields = line.Split(',');

                            // Skip any malformed lines.
                            if (3 != fields.Length)
                            {
                                // Log what we are about to do.
                                _logger.LogDebug(
                                    "Skipping a line, since the fields length is < 3"
                                    );

                                // Track the work.
                                skipped++;

                                continue; // Nothing left to do.
                            }

                            var parts = new string[0];

                            // Is the second field empty?
                            if (fields[1].Trim() == "")
                            {
                                // Log what we are about to do.
                                _logger.LogDebug(
                                    "Manually building the mime type"
                                    );

                                // Oddity in the iana.org docs to deal with.
                                parts = new string[]
                                {
                                    Path.GetFileNameWithoutExtension(endpoint),
                                    fields[0]
                                };
                            }
                            else
                            {
                                // Log what we are about to do.
                                _logger.LogDebug(
                                    "Splitting the mime type into parts"
                                    );

                                // Split the mimetype into parts.
                                parts = fields[1].Split('/');
                            }

                            // Skip any malformed fields.
                            if (2 != parts.Length)
                            {
                                // Log what we are about to do.
                                _logger.LogDebug(
                                    "Skipping a line, since the mime type parts < 2"
                                    );

                                // Track the work.
                                skipped++;

                                continue; // Nothing left to do.
                            }

                            // Log what we are about to do.
                            _logger.LogDebug(
                                "Checking for an existing mime type"
                                );

                            // Is the record already in the db?
                            if (await _mimeTypeManager.AnyAsync(
                                parts[0],
                                parts[1],
                                cancellationToken
                                ).ConfigureAwait(false))
                            {
                                // Log what we are about to do.
                                _logger.LogDebug(
                                    "Skipping mime type {p1}/{p2} because it's a duplicate",
                                    parts[0],
                                    parts[1]
                                    );

                                // Track the work.
                                skipped++;

                                continue; // Nothing left to do.
                            }

                            // Log what we are about to do.
                            _logger.LogDebug(
                                "Creating a new mime type"
                                );

                            // Add data to the table.
                            _ = await _mimeTypeManager.CreateAsync(
                                new MimeTypeModel
                                {
                                    Type = parts[0],
                                    SubType = parts[1]
                                },
                                "seed",
                                cancellationToken
                                ).ConfigureAwait(false);

                            // Track the work.
                            rows++;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log what happened.
                        _logger.LogWarning(
                            ex,
                            "Failed to fetch CSV text from {ep}",
                            endpoint
                            );

                        // Track the errors.
                        errors++;
                    }                    
                }
                catch (Exception ex)
                {
                    // Log what happened.
                    _logger.LogWarning(
                        ex,
                        "Failed to fetch CSV text from {ep}",
                        endpoint
                        );

                    // Track the errors.
                    errors++;
                }

                // Track the work.
                docs++;
            }

            // Tell the world what we did.
            _logger.LogInformation(
                "Finished seeding mime types directly from the IANA website. " +
                "docs: {docs}, rows: {rows}, skipped: {skipped}, errors: {errors}",
                docs,
                rows,
                skipped,
                errors
                );
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to seed mime types from IANA!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to seed mime types " +
                "from IANA!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task SeedMimeTypesAsync(
        List<MimeTypeModel> mimeTypes,
        string userName,
        bool force = false,        
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeTypes, nameof(mimeTypes))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Checking the force flag"
                );

            // Should we check for existing data?
            if (!force)
            {
                // Log what we are about to do.
                _logger.LogDebug(
                    "Checking for existing mime types"
                    );

                // Are there existing mime types?
                var hasExistingData = await _mimeTypeManager.AnyAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

                // Should we stop?
                if (hasExistingData)
                {
                    // Log what we didn't do.
                    _logger.LogWarning(
                        "Skipping seeding mime types because the 'force' flag " +
                        "was not specified and there are existing rows in the " +
                        "database."
                        );
                    return; // Nothing else to do!
                }
            }

            // Start by counting how many objects are already there.
            var originalCount = await _mimeTypeManager.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Seeding '{count}' mime types",
                mimeTypes.Count()
                );

            // Loop through the objects.
            foreach (var mimeType in mimeTypes)
            {
                // Log what we are about to do.
                _logger.LogDebug(
                    "Creating a mime type"
                    );

                // Create the mime type.
                _ = await _mimeTypeManager.CreateAsync(
                    mimeType,
                    userName,
                    cancellationToken
                    ).ConfigureAwait(false);
            }

            // Count how many objects are there now.
            var finalCount = await _mimeTypeManager.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Log what we did.
            _logger.LogInformation(
                "Seeded a total of {count} mime types",
                finalCount - originalCount
                );
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to seed one or more mime types!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to seed one or more " +
                "mime types!",
                innerException: ex
                );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    public virtual async Task SeedFileTypesAsync(
        List<FileTypeOptions> fileTypes,
        string userName,
        bool force = false,
        CancellationToken cancellationToken = default
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(fileTypes, nameof(fileTypes))
            .ThrowIfNullOrEmpty(userName, nameof(userName));

        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Checking the force flag"
                );

            // Should we check for existing data?
            if (!force)
            {
                // Log what we are about to do.
                _logger.LogDebug(
                    "Checking for existing file types"
                    );

                // Are there existing file types?
                var hasExistingData = await _fileTypeManager.AnyAsync(
                    cancellationToken
                    ).ConfigureAwait(false);

                // Should we stop?
                if (hasExistingData)
                {
                    // Log what we didn't do.
                    _logger.LogWarning(
                        "Skipping seeding file types because the 'force' flag " +
                        "was not specified and there are existing rows in the " +
                        "database."
                        );
                    return; // Nothing else to do!
                }
            }

            // Start by counting how many objects are already there.
            var originalMimeTypeCount = await _mimeTypeManager.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Start by counting how many objects are already there.
            var originalFileTypeCount = await _fileTypeManager.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Seeding '{count}' file types",
                fileTypes.Count()
                );

            // Loop through the objects.
            foreach (var fileType in fileTypes)
            {
                // Log what we are about to do.
                _logger.LogDebug(
                    "Seeding '{count}' extensions",
                    fileType.Extensions.Count()
                    );

                // Loop through the objects.
                foreach (var ext in fileType.Extensions)
                {
                    // Break up the mime type.
                    var parts = fileType.MimeType.Split('/');

                    // Sanity check the results.
                    if (parts.Length != 2)
                    {
                        // Log what we are about to do.
                        _logger.LogDebug(
                            "Skipping extension: {e} because mime type: {mt} is invalid!",
                            ext,
                            fileType.MimeType
                            );
                        continue; 
                    }

                    // Look for a matching mime type.
                    var mimeType = (await _mimeTypeManager.FindByTypesAsync(
                        parts[0],
                        parts[1],
                        cancellationToken
                        ).ConfigureAwait(false))
                        .FirstOrDefault();

                    // Did we fail?
                    if (mimeType is null)
                    {
                        // Log what we are about to do.
                        _logger.LogDebug(
                            "Creating missing mime type {mt} for extension: {e}",
                            fileType.MimeType,
                            ext
                            );

                        // Create the missing mime type.
                        mimeType = await _mimeTypeManager.CreateAsync(
                            new MimeTypeModel()
                            {
                                Type = parts[0],
                                SubType = parts[1]
                            },
                            userName,
                            cancellationToken
                            ).ConfigureAwait(false);
                    }

                    // Log what we are about to do.
                    _logger.LogDebug(
                        "Creating a file type: {e} for mime type: {mt}",
                        ext,
                        fileType.MimeType
                        );

                    // Create the file type.
                    _ = await _fileTypeManager.CreateAsync(
                        new FileTypeModel()
                        {
                            MimeType = mimeType,
                            Extension = ext
                        },
                        userName,
                        cancellationToken
                        ).ConfigureAwait(false);
                }
            }

            // Count how many objects are there now.
            var finalMimeTypeCount = await _mimeTypeManager.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Count how many objects are there now.
            var finalFileTypeCount = await _fileTypeManager.CountAsync(
                cancellationToken
                ).ConfigureAwait(false);

            // Log what we did.
            _logger.LogInformation(
                "Seeded a total of {count} file types and {count2} additional mime types",
                finalFileTypeCount - originalFileTypeCount,
                finalMimeTypeCount - originalMimeTypeCount                
                );
        }
        catch (Exception ex)
        {
            // Log what happened.
            _logger.LogError(
                ex,
                "Failed to seed one or more file types!"
                );

            // Provider better context.
            throw new DirectorException(
                message: $"The director failed to seed one or more " +
                "file types!",
                innerException: ex
                );
        }
    }

    #endregion

    // *******************************************************************
    // Protected methods.
    // *******************************************************************

    #region Protected methods

    /// <inheritdoc/>
    protected override async Task SeedFromConfiguration(
        string objectName,
        IConfiguration dataSection,
        string userName,
        bool force = false,
        CancellationToken cancellationToken = default
        )
    {
        // Log what we are about to do.
        _logger.LogTrace(
            "Performing a seeding operation for object: {name}",
            objectName
            );

        // Decide what to do with the incoming data.
        switch (objectName.ToLower().Trim())
        {
            case "filetypes":
                await SeedFileTypesAsync(
                    dataSection,
                    userName,
                    force,
                    cancellationToken
                    ).ConfigureAwait(false);
                break;
            default:
                throw new ArgumentException(
                    $"Don't know how to seed '{objectName}' types!"
                    );
        }
    }

    // *******************************************************************

    /// <inheritdoc/>
    protected override async Task BeforeSeedAsync(
        string userName,
        bool force = false,
        CancellationToken cancellationToken = default
        )
    {
        // Here we're seeding MIME types directly from the IANA website,
        //   instead of using a local JSON file. 

        // Log what we are about to do.
        _logger.LogTrace(
            "Deferring to the {name} method, for the seeder",
            nameof(SeedMimeTypesFromIanaAsync)
            );

        // Seed mime types.
        await SeedMimeTypesFromIanaAsync(
            userName,
            force,
            cancellationToken
            ).ConfigureAwait(false);
    }

    // *******************************************************************

    /// <summary>
    /// This method performs a seeding operation for <see cref="FileTypesOptions"/>
    /// objects, from the given configuration.
    /// </summary>
    /// <param name="dataSection">The data to use for the operation.</param>
    /// <param name="userName">The user name of the person performing the 
    /// operation.</param>
    /// <param name="force"><c>true</c> to force the seeding operation when data
    /// already exists in the associated table(s), <c>false</c> to stop the 
    /// operation whenever data is detected in the associated table(s).</param>

    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for the lifetime of the method.</param>
    /// <returns>A task to perform the operation.</returns>
    protected async virtual Task SeedFileTypesAsync(
        IConfiguration dataSection,
        string userName,
        bool force,
        CancellationToken cancellationToken = default
        )
    {
        // Log what we are about to do.
        _logger.LogDebug(
            "Binding the incoming seed data to our options"
            );

        // Bind the incoming data to our options.
        var options = new FileTypesOptions();
        dataSection.Bind(options);

        // Log what we are about to do.
        _logger.LogDebug(
            "Validating the incoming seed data"
            );

        // Validate the options.
        Guard.Instance().ThrowIfInvalidObject(options, nameof(options));

        // Log what we are about to do.
        _logger.LogTrace(
            "Deferring to the {name} method",
            nameof(ISeedDirector.SeedFileTypesAsync)
            );

        // Call the overload
        await SeedFileTypesAsync(
            options.FileTypes,
            userName,
            force,
            cancellationToken
            ).ConfigureAwait(false);

    }

    #endregion
}
