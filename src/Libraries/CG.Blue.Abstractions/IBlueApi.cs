
namespace CG.Blue;

/// <summary>
/// This interface represents the API for the <see cref="CG.Blue"/> microservice.
/// </summary>
public interface IBlueApi
{
    /// <summary>
    /// This property contains an object that contains support objects.
    /// </summary>
    ISupportFacade Support { get; }
}
