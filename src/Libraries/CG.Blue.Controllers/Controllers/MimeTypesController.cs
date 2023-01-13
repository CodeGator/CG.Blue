
namespace CG.Blue.Controllers;

/// <summary>
/// This class is a REST controller for <see cref="MimeTypeModel"/> resources.
/// </summary>
[Route("odata/[controller]")]
[ApiController]
[ApiVersion(1.0)]
public class MimeTypesController : ODataController
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
    /// This field contains the logger for this controller.
    /// </summary>
    internal protected readonly ILogger<MimeTypesController> _logger = null!;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="MimeTypesController"/>
    /// </summary>
    /// <param name="blueApi">The API to use with this controller.</param>
    /// <param name="logger">The logger to use with this controller.</param>
    public MimeTypesController(
        IBlueApi blueApi,
        ILogger<MimeTypesController> logger
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(blueApi, nameof(blueApi))
            .ThrowIfNull(logger, nameof(logger));

        // Save the reference(s).
        _blueApi = blueApi;
        _logger = logger;
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method gets a collection of <see cref="MimeTypeModel"/> objects.
    /// </summary>
    /// <returns>A task to perform the operation that returns a collection of <see cref="MimeTypeModel"/>
    /// objects.</returns>
    [HttpGet]
    [EnableQuery]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual async Task<IActionResult> GetAsync(
        ODataQueryOptions<MimeTypeModel> options
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Starting {name} method",
                nameof(GetAsync)
                );

            // Get the mime types.
            var data = await _blueApi.Support.MimeTypes.FindAllAsync()
                .ConfigureAwait(false);

            // Return the results.
            return Ok(data);
        }
        catch (Exception ex)
        {
            // Log the error in detail.
            _logger.LogError(
                ex,
                "Failed to render a collection of mime types!"
                );

            // Return an overview of the problem.
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                detail: "The controller failed to render a collection " +
                "of mime types!"
                );
        }
    }

    #endregion
}
