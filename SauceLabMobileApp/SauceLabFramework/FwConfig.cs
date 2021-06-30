using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SauceLabFramework
{
    public class FwConfig
    {
        private static FwDTO _configuration;
        private static readonly string _workspaceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static FwDTO Configuration => _configuration ?? throw new NullReferenceException(" _configuration is null. Call FW.SetConfig() First.");

        public static void SetConfig()
        {
            if (_configuration == null)
            {
                var jsonStr = File.ReadAllText(_workspaceDirectory + "/JsonFiles/App-setting.json");
                _configuration = JsonConvert.DeserializeObject<FwDTO>(jsonStr);
            }
        }
    }
}
