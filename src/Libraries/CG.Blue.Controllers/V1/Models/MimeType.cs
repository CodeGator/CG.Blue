
namespace CG.Blue.V1.Models;

/// <summary>
/// This class is a model that represents a Multipurpose Internet Mail 
/// Extension (MIME) type.
/// </summary>
public class MimeType
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the key for the MIME type.
    /// </summary>
    [Required]
    [MaxLength(Globals.Models.MimeTypes.TypeLength + Globals.Models.MimeTypes.SubTypeLength + 1)]
    public string Key { get; set; } = null!;

    /// <summary>
    /// This property contains a list of file extensions that are 
    /// associated with the MIME type.
    /// </summary>
    public List<string> Extensions { get; set; } = new();

    #endregion
}
