namespace CQRS_Training.Data;

public static class Common
{
    private static IConfigurationSection settings => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Settings");

    public static string GetSettings(string variable)
    {
        return Environment.GetEnvironmentVariable(variable) ?? settings[variable];
    }
}