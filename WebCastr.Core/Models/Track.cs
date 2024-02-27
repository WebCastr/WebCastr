using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCastr.Core.Models;

// ===================================
// Don't forget to update related DTOs
// ===================================

[Table(name: "track"), Index(nameof(Guid), IsUnique = true)]
public class Track
{
    /// <summary>
    /// Identifier of the track
    /// </summary>
    [Required, Column(name: "guid", TypeName = "GUID")]
    public Guid Id { get; set; } = Guid.NewGuid();
}
