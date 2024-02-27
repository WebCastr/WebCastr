using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCastr.Core.Models;

// ===================================
// Don't forget to update related DTOs
// ===================================

[Table(name: "station"), Index(nameof(ShortName), IsUnique = true)]
public class Station
{
    /// <summary>
    /// Identifier of the station
    /// </summary>
    [Required, Column(name: "guid", TypeName = "GUID")]
    public Guid Id { get; set; } = Guid.NewGuid();

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
}
