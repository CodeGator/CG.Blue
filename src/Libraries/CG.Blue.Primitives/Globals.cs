
namespace CG.Blue;

/// <summary>
/// This class contains global compile-time constants for the <see cref="CG.Blue"/>
/// microservice.
/// </summary>
public static class Globals
{
    /// <summary>
    /// This class contains model property sizes.
    /// </summary>
    public static class Models
    {
        /// <summary>
        /// This class contains sizes for <see cref="MimeTypeModel"/> properties.
        /// </summary>
        public static class MimeTypes
        {
            /// <summary>
            /// This constant represents the length of the <see cref="MimeTypeModel.Type"/> 
            /// property.
            /// </summary>
            public const int TypeLength = 127;

            /// <summary>
            /// This constant represents the length of the <see cref="MimeTypeModel.SubType"/> 
            /// property.
            /// </summary>
            public const int SubTypeLength = 127;
        }

        /// <summary>
        /// This class contains sizes for <see cref="FileTypeModel"/> properties.
        /// </summary>
        public static class FileTypes
        {
            /// <summary>
            /// This constant represents the length of the <see cref="FileTypeModel.Extension"/> 
            /// property.
            /// </summary>
            public const int ExtensionLength = 260;
        }
    }
}
