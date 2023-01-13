
namespace CG.Blue.Data.Entities;

/// <summary>
/// This class is an entity that represents a Multipurpose Internet Mail 
/// Extension (MIME) type.
/// </summary>
public class MimeTypeEntity : AuditedEntityBase
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
    /// This property contains the type for the entity.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// This property contains the sub-type for the entity.
    /// </summary>
    public string SubType { get; set; } = null!;

    /// <summary>
    /// This property contains the associated file type entities.
    /// </summary>
    public virtual ICollection<FileTypeEntity> FileTypes { get; set; }
        = new HashSet<FileTypeEntity>();

    #endregion
}
