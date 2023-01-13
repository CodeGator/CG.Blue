
namespace CG.Blue.Models;

/// <summary>
/// This class is a model that represents a MIME type.
/// </summary>
public class MimeTypeModel : AuditedModelBase
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the unique identifier for the MIME type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This property contains the MIME type.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.MimeTypes.TypeLength)]
    public string Type { get; set; } = null!;

    /// <summary>
    /// This property contains the MIME sub-type.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.MimeTypes.SubTypeLength)]
    public string SubType { get; set; } = null!;

    /// <summary>
    /// This property contains the associated file types.
    /// </summary>
    public virtual ICollection<FileTypeModel> FileTypes { get; set; } 
        = new HashSet<FileTypeModel>();

    #endregion
}
