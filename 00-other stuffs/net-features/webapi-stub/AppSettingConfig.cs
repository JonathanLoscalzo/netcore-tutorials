namespace webapi_stub
{
    public class AppSettingConfig
    {
        public DatabaseConfiguration Database { get; set; }
    }

    public class DatabaseConfiguration
    {
        public string DatabaseName { get; set; }
        public string ServerHost { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}