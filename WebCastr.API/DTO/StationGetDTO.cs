using WebCastr.API.Services.Liquidsoap.Enums;

namespace WebCastr.API.DTO;

public class StationGetDTO
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; } = "";
    public string ShortName { get; set; } = "";
    public string? Description { get; set; }
    public bool Enabled { get; set; } = false;
    public string TimeZone { get; set; } = "UTC";
    public AudioProcessingMethods AudioProcessingMethod { get; set; }
}
