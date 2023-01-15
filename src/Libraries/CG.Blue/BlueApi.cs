
namespace CG.Blue;

/// <summary>
/// This class is a default implementation of the <see cref="IBlueApi"/>
/// interface.
/// </summary>
internal class BlueApi : IBlueApi
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the content director for this api.
    /// </summary>
    internal protected readonly IContentDirector _contentDirector = null!;

    /// <summary>
    /// This field contains the support wrapper for this api.
    /// </summary>
    internal protected readonly ISupportFacade _supportFacade = null!;

    #endregion

    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <inheritdoc/>
    public virtual ISupportFacade Support => _supportFacade;

    /// <inheritdoc/>
    public virtual IContentDirector Content => _contentDirector;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlueApi"/>
    /// class.
    /// </summary>
    /// <param name="contentDirector">The content director to use with this API.</param>
    /// <param name="supportFacade">The support wrapper to use with this API.</param>
    public BlueApi(
        IContentDirector contentDirector,
        ISupportFacade supportFacade        
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(contentDirector, nameof(contentDirector))
            .ThrowIfNull(supportFacade, nameof(supportFacade));

        // Save the reference(s).
        _contentDirector = contentDirector;
        _supportFacade = supportFacade;
    }

    #endregion
}
