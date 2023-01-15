
namespace CG.Blue.Models;

/// <summary>
/// This class is a model that represents the bits for a Binary Large 
/// Object (BLOB).
/// </summary>
public class BlobBitsModel
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the unique identifier for the BLOB.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// This property contains the bits for the BLOB.
    /// </summary>
    [Required]
    public Stream Stream { get; set; } = null!;

    /// <summary>
    /// This property contains the MIME type for the BLOB.
    /// </summary>
    [MaxLength(Globals.Models.MimeTypes.TypeLength + Globals.Models.MimeTypes.SubTypeLength)]
    public string MimeType { get; set; } = null!;

    /// <summary>
    /// This property contains the file name for the BLOB.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.Blobs.OriginalFileNameLength)]
    public string OriginalFileName { get; set; } = null!;

    #endregion
}
