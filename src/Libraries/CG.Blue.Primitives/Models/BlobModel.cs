
namespace CG.Blue.Models;

/// <summary>
/// This class is a model that represents the meta-data for a Binary Large 
/// Object (BLOB).
/// </summary>
public class BlobModel : AuditedModelBase
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
    /// This property contains the path to the associated local file.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.Blobs.FilePathLength)]
    public string LocalFilePath { get; set; } = null!;

    /// <summary>
    /// This property contains the original file name of the BLOB.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.Blobs.OriginalFileNameLength)]
    public string OriginalFileName { get; set; } = null!;

    /// <summary>
    /// This property contains the associated MIME type.
    /// </summary>
    public virtual MimeTypeModel? MimeType { get; set; }

    /// <summary>
    /// This property contains the length, in bytes, of the BLOB.
    /// </summary>
    public long Length { get; set; }

    /// <summary>
    /// This property indicates whether the BLOB is encrypted, at rest.
    /// </summary>
    public bool EncryptedAtRest { get; set; }

    /// <summary>
    /// This property contains the date/time when the BLOB was last read.
    /// </summary>
    public DateTime? LastReadOnUtc { get; set; }

    #endregion
}
