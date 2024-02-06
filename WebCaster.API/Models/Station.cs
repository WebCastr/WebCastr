using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCaster.API.Services.Liquidsoap.Enums;

namespace WebCaster.API.Models;

[Table(name: "station"), Index(nameof(ShortName), IsUnique = true), Index(nameof(Guid), IsUnique = true)]
public class Station
{
    /// <summary>
    /// Identifier of the station
    /// </summary>
    [Column(name: "id")]
    public int Id { get; set; }

    /// <summary>
    /// GUID of the station
    /// </summary>
    [Required, Column(name: "guid", TypeName = "GUID")]
    public Guid Guid { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Display name of the station
    /// </summary>
    [MaxLength(100), Required, Column(name: "name", TypeName = "VARCHAR(100)")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Short name of the station (URL-friendly)
    /// </summary>
    [MaxLength(100), Required, Column(name: "short_name", TypeName = "VARCHAR(100)")]
    public string ShortName { get; set; } = "";

    /// <summary>
    /// Description of the station
    /// </summary>
    [MaxLength(255), Column(name: "description", TypeName = "VARCHAR(255)")]
    public string? Description { get; set; }

    [Column(name: "enabled")]
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Url of the station
    /// </summary>
    [MaxLength(250), Required, Column(name: "url", TypeName = "VARCHAR(250)")]
    public string Url { get; set; } = "";

    /// <summary>
    /// Time zone of the station (default is UTC)
    /// </summary>
    [MaxLength(250), Required, Column(name: "timezone", TypeName = "VARCHAR(250)")]
    public string TimeZone { get; set; } = "UTC";

    /// <summary>
    /// Base directory name of the station
    /// </summary>
    [NotMapped]
    public string BaseDir { get => ShortName + Path.DirectorySeparatorChar; }

    [Required, Column(name: "audio_processing_method")]
    public AudioProcessingMethods AudioProcessingMethod { get; set; }

    /// <summary>
    /// Mount points of the station
    /// </summary>
    [Column(name: "mount_points")]
    public List<MountPoint> MountPoints { get; set; } = new List<MountPoint>();
}
