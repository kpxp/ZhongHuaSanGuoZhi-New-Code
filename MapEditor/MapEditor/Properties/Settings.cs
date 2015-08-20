namespace MapEditor.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\SaveTemplate.mdb;Persist Security Info=True"), SpecialSetting(SpecialSetting.ConnectionString), ApplicationScopedSetting]
        public string ScenarioTemplateConnectionString
        {
            get
            {
                return (string) this["ScenarioTemplateConnectionString"];
            }
        }
    }
}

