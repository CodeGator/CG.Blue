
namespace CG.Blue.Host.Themes;

/// <summary>
/// This class represents the default MudBlazor UI theme.
/// </summary>
public class BlueTheme : DefaultTheme<BlueTheme>
{
    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="BlueTheme"/>
    /// class.
    /// </summary>
    public BlueTheme()
    {
        // Create the Purple default palette
        Palette.Primary = Colors.Orange.Darken2;
        Palette.Secondary = Colors.Green.Default;
        Palette.Tertiary = Colors.Purple.Default;
        Palette.AppbarBackground = Colors.Blue.Default;
    }

    #endregion
}
