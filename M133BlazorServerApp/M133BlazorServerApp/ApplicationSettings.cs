namespace M133BlazorServerApp
{
    public class ApplicationSettings
    {
        public static AppOptions AppOptions { get; set; } = new AppOptions();
    }
    public class AppOptions
    {
        public string? DatabaseConnectionString { get; set; }
    }
}
