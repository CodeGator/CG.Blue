

namespace CG.Blue.Facades;

/// <summary>
/// This class is a default implementation of the <see cref="ISupportFacade"/>
/// interface.
/// </summary>
internal class SupportFacade : ISupportFacade
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the mime type manager for this wrapper.
    /// </summary>
    internal protected readonly IMimeTypeManager _mimeTypeManager;

    /// <summary>
    /// This field contains the file type manager for this wrapper.
    /// </summary>
    internal protected readonly IFileTypeManager _fileTypeManager;

    #endregion

    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties
        
    /// <inheritdoc/>
    public virtual IFileTypeManager FileTypes => _fileTypeManager;

    /// <inheritdoc/>
    public virtual IMimeTypeManager MimeTypes => _mimeTypeManager;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="SupportFacade"/>
    /// class.
    /// </summary>
    /// <param name="mimeTypeManager">The mime type manager to use with 
    /// this wrapper.</param>
    /// <param name="fileTypeManager">The file type manager to use with 
    /// this wrapper.</param>
    public SupportFacade(
        IMimeTypeManager mimeTypeManager,
        IFileTypeManager fileTypeManager
        )
    {
        // Validate the parameters before attempting to use them.
        Guard.Instance().ThrowIfNull(mimeTypeManager, nameof(mimeTypeManager))
            .ThrowIfNull(fileTypeManager, nameof(fileTypeManager));

        // Save the reference(s).
        _mimeTypeManager = mimeTypeManager; 
        _fileTypeManager = fileTypeManager;
    }

    #endregion
}
