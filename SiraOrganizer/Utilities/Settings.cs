using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SiraOrganizer.Utilities
{
    public class Settings
    {
        private static readonly string _defaultDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Beat Saber";

        [JsonPropertyName("beatSaberDirectory")]
        public string BeatSaberDirectory { get; set; } = _defaultDirectory;

        public async void Load()
        {
            if (File.Exists("settings.json"))
            {
                string json = await File.ReadAllTextAsync("settings.json");
                Settings settings = JsonSerializer.Deserialize<Settings>(json);
                BeatSaberDirectory = settings.BeatSaberDirectory ?? _defaultDirectory;
            }
        }

        public async void Save()
        {
            string json = JsonSerializer.Serialize(this);
            await File.WriteAllTextAsync("settings.json", json);
        }
    }
}