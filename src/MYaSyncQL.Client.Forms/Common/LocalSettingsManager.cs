using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.Common {
    public class LocalSettingsManager {

        private static string SettingsPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\.penCsharpener\MYaSyncQL.Client.Forms\settings.json");
        public UserSettings Local { get; set; } = new UserSettings();

        public LocalSettingsManager() {

        }

        public void LoadSettings() {
            CreateDir();
            if (File.Exists(SettingsPath)) {
                var json = File.ReadAllText(SettingsPath);
                Local = JsonConvert.DeserializeObject<UserSettings>(json);
            }
        }

        public void SaveSettings() {
            try {
                CreateDir();
                var json = JsonConvert.SerializeObject(Local, Formatting.Indented);
                File.WriteAllText(SettingsPath, json);
            } catch { }
        }

        private void CreateDir() {
            try {
                var path = Path.GetDirectoryName(SettingsPath);
                if (!Directory.Exists(path)) {
                    var dir = Directory.CreateDirectory(path);
                    dir.Attributes = FileAttributes.Hidden;
                }
            } catch { }
        }

}
}
