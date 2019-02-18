using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uiza.Net.Enums
{
    /// <summary>
    ///
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StorageInputTypes
    {
        /// <summary>
        ///
        /// </summary>
        [EnumMember(Value = "s3")]
        S3,

        /// <summary>
        ///
        /// </summary>
        [EnumMember(Value = "ftp")]
        Ftp
    }
}