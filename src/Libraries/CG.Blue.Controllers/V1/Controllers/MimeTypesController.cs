
namespace CG.Blue.V1.Controllers;

/// <summary>
/// This class is a REST controller for <see cref="MimeType"/> resources.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion(1.0)]
public class MimeTypesController : ControllerBase
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
    /// <param name="mapper">The auto mapper to use with this controller.</param>
    /// <param name="logger">The logger to use with this controller.</param>
    public MimeTypesController(
        IBlueApi blueApi,
        IMapper mapper,
        ILogger<MimeTypesController> logger
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
    /// This method gets a collection of <see cref="MimeType"/> objects.
    /// </summary>
    /// <returns>A task to perform the operation that returns the results
    /// of the action.</returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual async Task<IActionResult> GetAsync()
    {
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Starting {name} method",
                nameof(GetAsync)
                );

            // Log what we are about to do.
            _logger.LogDebug(
                "Searching for matching mime types"
                );

            // Get the mime type models.
            var data = await _blueApi.Support.MimeTypes.FindAllAsync()
                .ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Shaping the outgoing data"
                );

            // Convert the data.
            var result = data.Select(x => 
                _mapper.Map<MimeType>(x)
                );

            // Return the results.
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Log the error in detail.
            _logger.LogError(
                ex,
                "Failed to search for mime types!"
                );

            // Return an overview of the problem.
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                detail: "The controller failed to search for mime types!"
                );
        }
    }

    // *******************************************************************

    /// <summary>
    /// This method gets a single <see cref="MimeType"/> object, by matching
    /// the type and subtype to the given key.
    /// </summary>
    /// <returns>A task to perform the operation that returns the results
    /// of the action.</returns>
    [HttpGet("{key}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual async Task<IActionResult> GetAsync(
        string key
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Starting {name} method",
                nameof(GetAsync)
                );

            // Sanity check the model state.
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Splitting the incoming key"
                );

            // Unescape and split the key.
            var parts = Uri.UnescapeDataString(key).Split('/');

            // Sanity check the results.
            if (parts.Length != 2)
            {
                return BadRequest();
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Searching for a matching mime type"
                );

            // Get the mime type models.
            var data = await _blueApi.Support.MimeTypes.FindByTypesAsync(
                parts[0],
                parts[1]
                ).ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Shaping the outgoing data"
                );

            // Convert the data.
            var result = data.Select(x =>
                _mapper.Map<MimeType>(x)
                );

            // Return the results.
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Log the error in detail.
            _logger.LogError(
                ex,
                "Failed to search for mime types that match: '{key}'!",
                key
                );

            // Return an overview of the problem.
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                detail: "The controller failed to search for mime types " +
                $"that match: {key}!"
                );
        }
    }

    // *******************************************************************

    /// <summary>
    /// This method gets a collection of <see cref="MimeType"/> objects, 
    /// by matching their file extension to the given value.
    /// </summary>
    /// <returns>A task to perform the operation that returns the results
    /// of the action.</returns>
    [HttpGet("ByExt/{extension}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual async Task<IActionResult> GetByExtAsync(
        string extension
        )
    {
        try
        {
            // Log what we are about to do.
            _logger.LogDebug(
                "Starting {name} method",
                nameof(GetByExtAsync)
                );

            // Sanity check the model state.
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Log what we are about to do.
            _logger.LogDebug(
                "Searching for matching mime types"
                );

            // Get the mime type models.
            var data = await _blueApi.Support.MimeTypes.FindByExtensionAsync(
                Uri.UnescapeDataString(extension)
                ).ConfigureAwait(false);

            // Log what we are about to do.
            _logger.LogDebug(
                "Shaping the outgoing data"
                );

            // Convert the data.
            var result = data.Select(x =>
                _mapper.Map<MimeType>(x)
                );

            // Return the results.
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Log the error in detail.
            _logger.LogError(
                ex,
                "Failed to search for mime types that match the " +
                "extension: '{ext}'!",
                extension
                );

            // Return an overview of the problem.
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                detail: "The controller failed to search for mime types " +
                $"that match the extension: '{extension}'!"
                );
        }
    }

    #endregion
}
