
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
    /// This property indicates whether the BLOB is encrypted, at rest.
    /// </summary>
    public bool EncryptedAtRest { get; set; }

    #endregion
}
