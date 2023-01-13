
namespace CG.Blue.Data.Entities;

/// <summary>
/// This class is an entity that represents a file type.
/// </summary>
public class FileTypeEntity : AuditedEntityBase
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// This property contains the identifier for the associated MIME type
    /// entity.
    /// </summary>
    public int? MimeTypeId { get; set; }

    /// <summary>
    /// This property contains the associated MIME type entity.
    /// </summary>
    public virtual MimeTypeEntity? MimeType { get; set; } 

    /// <summary>
    /// This property contains the extension for the entity.
    /// </summary>
    public string Extension { get; set; } = null!;

    #endregion
}
