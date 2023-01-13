
namespace CG.Blue.Options;

/// <summary>
/// This class contains configuration settings for seeding file types.
/// </summary>
public class FileTypesOptions
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains a list of file types.
    /// </summary>
    public List<FileTypeOptions> FileTypes { get; set; } = new();

    #endregion
}


/// <summary>
/// This class contains configuration settings for seeding a file type.
/// </summary>
public class FileTypeOptions
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the complete mime type for the file type.
    /// </summary>
    [Required]
    public string MimeType { get; set; } = null!;

    /// <summary>
    /// This property contains a list of extensions for the file type.
    /// </summary>
    public List<string> Extensions { get; set; } = new();

    #endregion
}
