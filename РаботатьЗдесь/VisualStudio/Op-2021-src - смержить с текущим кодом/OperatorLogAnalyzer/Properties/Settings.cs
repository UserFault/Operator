// Decompiled with JetBrains decompiler
// Type: OperatorLogAnalyzer.Properties.Settings
// Assembly: OperatorLogAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A7DBDED-B46A-481E-8C85-402E4F6C7D7A
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\OperatorLogAnalyzer.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace OperatorLogAnalyzer.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings settings = Settings.defaultInstance;
        return settings;
      }
    }
  }
}
