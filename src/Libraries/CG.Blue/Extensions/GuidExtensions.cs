
namespace System;

/// <summary>
/// This class contains extension methods related to the <see cref="Guid"/>
/// type.
/// </summary>
internal static class GuidExtensions
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// Converts the given <see cref="Guid" /> to a folder path, using 
    /// the number of levels specified by the <paramref name="pathType"/>
    /// parameter.
    /// </summary>
    /// <param name="guid">The <see cref="Guid" /> to be converted.</param>
    /// <param name="pathType">The number of folder levels to use for the 
    /// operation.</param>
    /// <returns>A corresponding relative folder path.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever
    /// one or more arguments are missing, or invalid.</exception>
    public static string ToFolderPath(
        this Guid guid,
        FolderLevels pathType = FolderLevels.One
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfEmptyGuid(guid, nameof(guid));

        // Convert the GUID to bytes.
        var bytes = guid.ToByteArray();

        // Build the folder path.
        string folderPath = "";
        switch (pathType)
        {
            case FolderLevels.One:
                folderPath = string.Format(
                    "{0:X2}{1}",
                    bytes[0],
                    Path.DirectorySeparatorChar                   
                    );
                break;
            case FolderLevels.Two:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1] ,
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Three:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar                    
                    );
                break;
            case FolderLevels.Four:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Five:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Six:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Seven:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Eight:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Nine:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Ten:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}{18:X2}{19}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar,
                    bytes[9],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Eleven:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}{18:X2}{19}" +
                    "{20:X2}{21}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar,
                    bytes[9],
                    Path.DirectorySeparatorChar,
                    bytes[10],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Twelve:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}{18:X2}{19}" +
                    "{20:X2}{21}{22:X2}{23}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar,
                    bytes[9],
                    Path.DirectorySeparatorChar,
                    bytes[10],
                    Path.DirectorySeparatorChar,
                    bytes[11],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Thirteen:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}{18:X2}{19}" +
                    "{20:X2}{21}{22:X2}{23}{24:X2}{25}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar,
                    bytes[9],
                    Path.DirectorySeparatorChar,
                    bytes[10],
                    Path.DirectorySeparatorChar,
                    bytes[11],
                    Path.DirectorySeparatorChar,
                    bytes[12],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Fourteen:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}{18:X2}{19}" +
                    "{20:X2}{21}{22:X2}{23}{24:X2}{25}{26:X2}{27}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar,
                    bytes[9],
                    Path.DirectorySeparatorChar,
                    bytes[10],
                    Path.DirectorySeparatorChar,
                    bytes[11],
                    Path.DirectorySeparatorChar,
                    bytes[12],
                    Path.DirectorySeparatorChar,
                    bytes[13],
                    Path.DirectorySeparatorChar
                    );
                break;
            case FolderLevels.Fifteen:
                folderPath = string.Format(
                    "{0:X2}{1}{2:X2}{3}{4:X2}{5}{6:X2}{7}{8:X2}{9}" +
                    "{10:X2}{11}{12:X2}{13}{14:X2}{15}{16:X2}{17}{18:X2}{19}" +
                    "{20:X2}{21}{22:X2}{23}{24:X2}{25}{26:X2}{27}{28:X2}{29}",
                    bytes[0],
                    Path.DirectorySeparatorChar,
                    bytes[1],
                    Path.DirectorySeparatorChar,
                    bytes[2],
                    Path.DirectorySeparatorChar,
                    bytes[3],
                    Path.DirectorySeparatorChar,
                    bytes[4],
                    Path.DirectorySeparatorChar,
                    bytes[5],
                    Path.DirectorySeparatorChar,
                    bytes[6],
                    Path.DirectorySeparatorChar,
                    bytes[7],
                    Path.DirectorySeparatorChar,
                    bytes[8],
                    Path.DirectorySeparatorChar,
                    bytes[9],
                    Path.DirectorySeparatorChar,
                    bytes[10],
                    Path.DirectorySeparatorChar,
                    bytes[11],
                    Path.DirectorySeparatorChar,
                    bytes[12],
                    Path.DirectorySeparatorChar,
                    bytes[13],
                    Path.DirectorySeparatorChar,
                    bytes[14],
                    Path.DirectorySeparatorChar
                    );
                break;
        }        

        // Return the results.
        return folderPath;
    }

    // *******************************************************************

    /// <summary>
    /// Converts the given <see cref="Guid" /> to a file name using the 
    /// number of levels specified by the <paramref name="pathType"/>
    /// parameter.
    /// </summary>
    /// <param name="guid">The <see cref="Guid" /> to be converted.</param>
    /// <param name="extension">The extension to use for the file name.</param>
    /// <param name="pathType">The path type to use for the operation.</param>
    /// <returns>The corresponding file name.</returns>
    /// <exception cref="ArgumentException">This exception is thrown whenever
    /// one or more arguments are missing, or invalid.</exception>
    public static string ToFileName(
        this Guid guid, 
        string extension,
        FolderLevels pathType = FolderLevels.One
        )
    {
        // Validate the arguments before attempting to use them.
        Guard.Instance().ThrowIfEmptyGuid(guid, nameof(guid))
            .ThrowIfNullOrEmpty(extension, nameof(extension));

        // Convert the GUID to bytes.
        var bytes = guid.ToByteArray();

        // Create a 'safe' extension.
        var safeExtension = extension[0] == '.' ? extension[1..] : extension;

        // Build the file name.
        string fileName = "";
        switch (pathType)
        {
            case FolderLevels.One:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}{9:X2}{10:X2}{11:X2}{12:X2}{13:X2}" +
                    "{14:X2}.{15}",
                    bytes[1],
                    bytes[2],
                    bytes[3],
                    bytes[4],
                    bytes[5],
                    bytes[6],
                    bytes[7],
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Two:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}{9:X2}{10:X2}{11:X2}{12:X2}{13:X2}" +
                    ".{14}",
                    bytes[2], 
                    bytes[3],
                    bytes[4],
                    bytes[5],
                    bytes[6],
                    bytes[7],
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Three:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}{9:X2}{10:X2}{11:X2}{12:X2}.{13}",
                    bytes[3], 
                    bytes[4],
                    bytes[5],
                    bytes[6],
                    bytes[7],
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Four:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}{9:X2}{10:X2}{11:X2}.{12}",
                    bytes[4], 
                    bytes[5],
                    bytes[6],
                    bytes[7],
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Five:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}{9:X2}{10:X2}.{11}",
                    bytes[5], 
                    bytes[6],
                    bytes[7],
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Six:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}{9:X2}.{10}",
                    bytes[6],
                    bytes[7],
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Seven:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}{8:X2}.{9}",
                    bytes[7], 
                    bytes[8],
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Eight:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}" +
                    "{7:X2}.{8}",
                    bytes[8], 
                    bytes[9],
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Nine:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}{6:X2}.{7}",
                    bytes[9], 
                    bytes[10],
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Ten:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}.{6}",
                    bytes[10], 
                    bytes[11],
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Eleven:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}.{5}",
                    bytes[11], 
                    bytes[12],
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Twelve:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}{3:X2}.{4}",
                    bytes[12], 
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Thirteen:
                fileName = string.Format(
                    "{0:X2}{1:X2}{2:X2}.{3}",
                    bytes[13],
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Fourteen:
                fileName = string.Format(
                    "{0:X2}{1:X2}.{2}",
                    bytes[14],
                    bytes[15],
                    safeExtension
                    );
                break;
            case FolderLevels.Fifteen:
                fileName = string.Format(
                    "{0:X2}.{1}",
                    bytes[15],
                    safeExtension
                    );
                break;
        }        

        // Return the results.
        return fileName;
    }

    #endregion
}
