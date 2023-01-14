﻿
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

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlueApi"/>
    /// class.
    /// </summary>
    /// <param name="supportFacade">The support wrapper to use with this API.</param>
    public BlueApi(
        ISupportFacade supportFacade
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(supportFacade, nameof(supportFacade));

        // Save the reference(s).
        _supportFacade = supportFacade;
    }

    #endregion
}