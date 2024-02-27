using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace WebCastr.Core.Models;

// ===================================
// Don't forget to update related DTOs
// ===================================

[Table(name: "playlist"), Index(nameof(Guid), IsUnique = true)]
public class Playlist
{
    /// <summary>
    /// Identifier of the playlist
    /// </summary>
    [Required, Column(name: "guid", TypeName = "GUID")]
    public Guid Id { get; set; } = Guid.NewGuid();
}
