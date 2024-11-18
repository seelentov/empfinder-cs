using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Empfinder.Factories;

public interface ISeleniumFactory : IFactory<ChromeDriver>
{

}

public class SeleniumFactory : ISeleniumFactory
{
    private readonly ChromeOptions _driverOptions;
    private ChromeDriver? _driver;
    public SeleniumFactory()
    {
        ChromeOptions options = new ChromeOptions();

        options.AddUserProfilePreference("profile.default_content_settings.images", 2);
        options.AddUserProfilePreference("profile.default_content_settings.stylesheets", 2);
        options.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
        options.AddUserProfilePreference("profile.managed_default_content_settings.stylesheets", 2);
        options.AddUserProfilePreference("cache.disk_cache_size", 0);
        options.AddUserProfilePreference("cache.memory_cache_size", 0);
        options.AddUserProfilePreference("cache.enable", false);
        options.AddUserProfilePreference("extensions.enabled", false);
        options.AddUserProfilePreference("privacy.clear_browsing_data_on_exit", true);

        options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36");
        options.AddArgument("--headless=new");
        options.AddArgument("disable-gpu");
        options.AddArgument("no-sandbox");
        options.AddArgument("--disable-extensions");
        options.AddArgument("--disable-features=NetworkService");
        options.AddArgument("--ignore-ssl-errors");
        options.AddArgument("--ignore-certificate-errors");

        _driverOptions = options;
        _driverOptions.PageLoadStrategy = PageLoadStrategy.Eager;
    }
    public ChromeDriver Get()
    {
        _driver ??= new ChromeDriver(_driverOptions);

        return _driver;
    }
}
