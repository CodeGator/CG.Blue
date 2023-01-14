
namespace CG.Blue.V1.Models;

/// <summary>
/// This class is a model that represents the meta-data for a Binary Large 
/// Object (BLOB)
/// </summary>
public class Blob
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the identifier for the BLOB.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// This property indicates whether the BLOB is encrypted, at rest.
    /// </summary>
    public bool EncryptedAtRest { get; set; }

    #endregion
}
