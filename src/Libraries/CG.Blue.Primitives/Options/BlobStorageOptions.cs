
namespace CG.Blue.Options;

/// <summary>
/// This class contains configuration settings related to BLOB storage.
/// </summary>
public class BlobStorageOptions
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the backing for the <see cref="BlobStorageOptions.RootPath"/>
    /// property.
    /// </summary>
    internal protected string _rootPath = "C:\\Blue\\";

    #endregion

    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the root of the BLOB storage tree.
    /// </summary>
    [Required]
    [MaxLength(260)]
    public string RootPath 
    { 
        get {  return  _rootPath; }
        set
        {
            // Should we provide a default path?
            if (string.IsNullOrEmpty(value))
            {
                _rootPath = $"C:\\Blue\\";
            }

            // Should we properly end the path?
            else if (!value.EndsWith('\\'))
            {
                _rootPath = $"{value}\\";
            }

            // Should we just copy the value?
            else
            {
                _rootPath = value;
            }
        }
    }

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

    #endregion
}
