using System;
using System.Collections.Generic;
using SQLite.Net.Interop;

namespace OCR.Core.ServiceContracts
{
    public interface IPreferenceService
    {
        bool ForceSave();
        string DbPath { get; set; }
        ISQLitePlatform SQLitePlatform { get; set; }
    }
}