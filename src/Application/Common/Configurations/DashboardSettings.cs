namespace SmartGenealogy.Application.Common.Configurations;

/// <summary>
/// Configuration wrapper for the dashboard section
/// </summary>
public class DashboardSettings
{
    /// <summary>
    /// Dashboard key constraint
    /// </summary>
    public const string Key = nameof(DashboardSettings);

    /// <summary>
    /// Specifies whether to enable the loading screen
    /// </summary>
    public bool EnableLoadingScreen { get; set; } = true;

    /// <summary>
    /// Specifies whether to enable the loading screen on navigation transitions
    /// </summary>
    public bool EnableLoadingTransitionScreen { get; set; } = false;

    /// <summary>
    /// Specifies the duration of the loading screen in milliseconds
    /// </summary>
    public int LoadingScreenDuration { get; set; } = 1000;

    /// <summary>
    /// Specifies the duration of the loading screen on navigation in milliseconds
    /// </summary>
    public int LoadingTransitionScreenDuration { get; set; } = 600;

    /// <summary>
    /// Current application version
    /// </summary>
    public string Version { get; set; } = "1.0.0";

    /// <summary>
    /// Application framework
    /// </summary>
    public string App { get; set; } = "Blazor";

    /// <summary>
    /// The application name / title
    /// </summary>
    public string AppName { get; set; } = "Smart Genealogy";

    /// <summary>
    /// Application framework including the version
    /// </summary>
    public string AppFlavor { get; set; } = "Blazor .NET 8.0";

    /// <summary>
    /// Application .NET version
    /// </summary>
    public string AppFlavorSubscript { get; set; } = ".NET 8";

    /// <summary>
    /// The name of the company
    /// </summary>
    public string Company { get; set; } = "AW Web Solutions";

    /// <summary>
    /// Copyright watermark
    /// </summary>
    public string Copyright { get; set; } = "@2023 Copyright";
}