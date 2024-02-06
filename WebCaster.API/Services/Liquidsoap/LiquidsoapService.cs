using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WebCaster.API.Services.Liquidsoap.Options;

namespace WebCaster.API.Services.Liquidsoap;

public class LiquidsoapService
{
    #region Attributes

    private readonly LiquidsoapOptions _options;
    private readonly ILogger _logger;

    #endregion

    #region Properties

    /// <summary>
    /// Current version of Liquidsoap
    /// </summary>
    private Version _currentVersion = new(0,0,0);
    public Version CurrentVersion
    {
        get
        {
            if (_currentVersion.Major != 0)
                return _currentVersion;

            _currentVersion = GetCurrentVersionFromExecutable();

            return _currentVersion;
        }
    }

    public string Executable { get => _options.Executable; }

    #endregion

    #region Constructors

    public LiquidsoapService(IOptions<LiquidsoapOptions> options, ILogger<LiquidsoapService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Start Liquidsoap service
    /// </summary>
    public void Start()
    {
        _logger.LogInformation($"Liquidsoap service is starting...");

        _logger.LogInformation($"Liquidsoap command line is \"{Executable}\"");

        if (CurrentVersion >= _options.MinimalVersion)
            _logger.LogInformation($"Liquidsoap version {CurrentVersion.ToString()} >= minimal required version {_options.MinimalVersion.ToString()} ");
        else
        {
            _logger.LogError($"Liquidsoap version {CurrentVersion.ToString()} < minimal required version {_options.MinimalVersion.ToString()}. Please update Liquidsoap.");
            Environment.Exit(1);
        }

        _logger.LogInformation($"Liquidsoap service started");
    }

    private Version GetCurrentVersionFromExecutable()
    {
        using (Process process = new Process())
        {
            process.StartInfo.FileName = $"{Executable}";
            process.StartInfo.ArgumentList.Add("--version");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            Match m = Regex.Match(output, @"Liquidsoap (\d+\.\d+\.\d+)");
            if (!m.Success)
                throw new InvalidDataException("Liquidsoap version cannot be read from command line");

            _currentVersion = Version.Parse(m.Groups[1].Value);

            process.WaitForExit();
        }

        return _currentVersion;
    }

    #endregion
}
