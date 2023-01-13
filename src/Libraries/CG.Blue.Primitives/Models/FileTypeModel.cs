
namespace CG.Blue.Models;

/// <summary>
/// This class is a model that represents a file type.
/// </summary>
public class FileTypeModel : AuditedModelBase
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the unique identifier for the file type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This property contains the associated MIME type.
    /// </summary>
    [Required]
    public virtual MimeTypeModel? MimeType { get; set; }

    /// <summary>
    /// This property contains the extension for the file type.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.FileTypes.ExtensionLength)]
    public string Extension { get; set; } = null!;

    #endregion
}
