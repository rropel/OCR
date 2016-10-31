using System;
using Foundation;
using OCR.Core.Helpers;
using OCR.Core.ServiceContracts;
using OCR.Core.Services;
using Version.Plugin.Abstractions;

namespace OCR.UI.iOS.Services
{
    public class PreferenceService : BasePreferenceService, IPreferenceService
    {
        public PreferenceService(IVersion versionService) : base(versionService)
        {
        }

        public bool ForceSave()
        {
            return NSUserDefaults.StandardUserDefaults.Synchronize();
        }
    }
}