using LocalWeatherApp.Interfaces;

namespace LocalWeatherApp.Wrapper
{
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        private readonly IConfiguration _configuration;

        public ConfigurationWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string key)
        {
            return _configuration.GetValue<string>(key) ?? "";
        }
    }
}
