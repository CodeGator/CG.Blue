
namespace CG.Blue.Options;

/// <summary>
/// This class contains configuration settings related to BLOB storage.
/// </summary>
public class BlobStorageOptions
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the path to the local storage tree.
    /// </summary>
    [Required]
    [MaxLength(260)]
    public string LocalStoragePath { get; set; } = null!;

    /// <summary>
    /// This property indicates whether or not BLOBS should be encrypted 
    /// at rest, when they are imported.
    /// </summary>
    public bool EncryptAtRest { get; set; }

    /// <summary>
    /// This property contains the default number of folders to create
    /// for each BLOB file, when they are imported.
    /// </summary>
    public FolderLevels FolderLevels { get; set; }

    /// <summary>
    /// This property indicates 
    /// </summary>
    public bool DropLocalStorageOnStartup { get; set; }

    #endregion
}
