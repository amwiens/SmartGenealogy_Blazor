namespace SmartGenealogy.Infrastructure.Constants.Localization;

public static class LocalizationConstants
{
    public const string ResourcesPath = "Resources";
    public static readonly LanguageCode[] SupportedLanguages =
    {
        new LanguageCode
        {
            Code = "en-US",
            DisplayName = "English"
        }
    };
}

public class LanguageCode
{
    public string DisplayName { get; set; } = "en-US";

    public string Code { get; set; } = "English";
}