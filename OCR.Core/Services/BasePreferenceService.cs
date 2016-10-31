using SQLite.Net.Interop;
using Version.Plugin.Abstractions;

namespace OCR.Core.Services
{
    public abstract class BasePreferenceService
    {
        protected BasePreferenceService(IVersion versionService)
        {
            AppVersion = versionService.Version;
        }

        public string DbPath { get; set; }
        public ISQLitePlatform SQLitePlatform { get; set; }
        public string AppVersion { get; }
    }
}