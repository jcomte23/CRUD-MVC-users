using DotNetEnv;

namespace CRUD_MVC_users.Config;

public static class EnvConfig
{
    public static void Load()
    {
        Env.Load();
    }

    public static string GetConnectionString()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";

        return $"server={dbHost};port={dbPort};database={dbName};user={dbUser};password={dbPassword};";
    }
}