
namespace CG.Blue.V1.Controllers;

/// <summary>
/// This class is a REST controller for file resources.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion(1.0)]
public class BlobsController : ControllerBase
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the api for this controller.
    /// </summary>
    internal protected readonly IBlueApi _blueApi = null!;

    /// <summary>
    /// This field contains the auto mapper for this controller.
    /// </summary>
    internal protected readonly IMapper _mapper = null!;

    /// <summary>
    /// This field contains the logger for this controller.
    /// </summary>
    internal protected readonly ILogger<BlobsController> _logger = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlobsController"/>
    /// </summary>
    /// <param name="blueApi">The API to use with this controller.</param>
    /// <param name="mapper">The auto mapper to use with this controller.</param>
    /// <param name="logger">The logger to use with this controller.</param>
    public BlobsController(
        IBlueApi blueApi,
        IMapper mapper,
        ILogger<BlobsController> logger
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blueApi, nameof(blueApi))
            .ThrowIfNull(mapper, nameof(mapper))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s).
        _blueApi = blueApi;
        _mapper = mapper;
        _logger = logger;
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method posts a file to the API.
    /// </summary>
    /// <returns>A task to perform the operation that returns the results
    /// of the action.</returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual async Task<IActionResult> PostAsync(
        List<IFormFile> files
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Starting {name} method",
                nameof(PostAsync)
                );

            // Sanity check the model state.
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Looping through {count} files",
                files.Count
                );

            // Loop through the files.
            var blobs = new List<BlobModel>();
            foreach (var file in files)
            {
                // Log what we are about to do.
                _logger.LogDebug(
                    "Importing a file"
                    );

                // Import the BLOB.
                var blob = await _blueApi.Imports.ImportAsync(
                    file.OpenReadStream(),
                    file.FileName,
                    file.ContentType,
                    User.Identity?.Name ?? "anonymous"
                    ).ConfigureAwait(false);

                // Add to the list.
                blobs.Add(blob);
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Shaping the outgoing data"
                );

            // Convert the data.
            var result = blobs.Select(x => 
                _mapper.Map<Blob>(x)
                );

            // Return the results.
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Log the error in detail.
            _logger.LogError(
                ex,
                "Failed to import one or more BLOBs!"
                );

            // Return an overview of the problem.
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                detail: "The controller failed to import one or more BLOBs!"
                );
        }
    }

    #endregion
}
