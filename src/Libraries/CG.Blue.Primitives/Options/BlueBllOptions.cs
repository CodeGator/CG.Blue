
namespace CG.Blue.Options;

/// <summary>
/// This class contains configuration settings for the <see cref="CG.Blue"/>
/// business logic layer.
/// </summary>
public class BlueBllOptions
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains options for BLOB storage.
    /// </summary>
    public BlobStorageOptions? BlobStorage { get; set; }

    #endregion
}
