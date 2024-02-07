using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using WebCastr.API.Enums;

namespace WebCastr.API.Models;

[Table(name: "mount_point")]
public class MountPoint
{
    /// <summary>
    /// Unique identifier of the mount point
    /// </summary>
    [Column(name: "id")]
    public int Id { get; set; }

    /// <summary>
    /// Display name of the mount point
    /// </summary>
    [MaxLength(100), Required, Column(name: "name", TypeName = "VARCHAR(100)")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Full url of the mount point
    /// </summary>
    [MaxLength(250), Required, Column(name: "url", TypeName = "VARCHAR(255)")]
    public string Url { get; set; } = "";

    /// <summary>
    /// Full url of the mount point (station url + mount point url)
    /// </summary>
    [MaxLength(500), Required, Column(name: "path", TypeName = "VARCHAR(500)")]
    public string Path { get; set; } = "";

    /// <summary>
    /// Encoding format of the stream
    /// </summary>
    [Required, Column("format")]
    public MountPointFormats Format { get; set; }

    /// <summary>
    /// Bitrate of the stream
    /// </summary>
    [Required, Column("bitrate")]
    public int Bitrate {  get; set; }

    /// <summary>
    /// Sample rate of the stream
    /// </summary>
    [Required, Column("samplerate")]
    public int SampleRate { get; set; }

    /// <summary>
    /// Number of channels of the stream
    /// </summary>
    [Required, Column("channels")]
    public MountPointChannels Channels { get; set; }
}
