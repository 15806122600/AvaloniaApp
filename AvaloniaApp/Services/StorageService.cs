using System;
using System.IO;
using System.Text.Json;

namespace AvaloniaApp.Services
{
    public class StorageService
    {
        private static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AvaloniaApp");
        private static readonly string FilePath = Path.Combine(FolderPath, "login_config.json");

        public static string DbConnectionString => $"Filename={Path.Combine(FolderPath, "MyData.db")};Connection=Shared";

        public class LoginConfig
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public bool IsRemembered { get; set; }
        }

        public void SaveLoginConfig(string username, string password, bool isRemembered)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                var config = new LoginConfig
                {
                    Username = username,
                    Password = isRemembered ? password : string.Empty,
                    IsRemembered = isRemembered
                };

                var json = JsonSerializer.Serialize(config);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                // Handle or log error
                Console.WriteLine($"Error saving config: {ex.Message}");
            }
        }

        public LoginConfig LoadLoginConfig()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<LoginConfig>(json) ?? new LoginConfig();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading config: {ex.Message}");
            }
            return new LoginConfig();
        }
    }
}
