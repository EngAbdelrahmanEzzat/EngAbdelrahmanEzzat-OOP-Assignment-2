using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsLab
{
    public class AppConfig
    {
        public static int LoadCount;
        public string DbConnection { get; set; }
        public string Theme { get; set; }
        private static readonly Lazy<AppConfig> _lazy = new Lazy<AppConfig>(() => new AppConfig());
        public static AppConfig Instance => _lazy.Value;


        private AppConfig()
        {
            LoadCount++;
            Console.WriteLine($"[AppConfig] Loading settings from disk... (load #{LoadCount})");
            Thread.Sleep(300);
            DbConnection = "Server=localhost;Db=School";
            Theme = "Light";
        }
    }
    public class DatabaseService
    {


        public void Connect() => Console.WriteLine($"Connecting to {AppConfig.Instance.DbConnection}");
    }
    public class UiService
    {


        public void Render() => Console.WriteLine($"UI is using theme: {AppConfig.Instance.Theme}");
    }
}
