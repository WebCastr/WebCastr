namespace WebCastr.API.Services.Liquidsoap.Options;

public class LiquidsoapOptions
{
    /// <summary>
    /// Minimal version of Liquidsoap supported by Webcaster
    /// </summary>
    public Version MinimalVersion { get; } = new Version(2, 2, 0);

    public string Executable { get; set; } = "";
}
