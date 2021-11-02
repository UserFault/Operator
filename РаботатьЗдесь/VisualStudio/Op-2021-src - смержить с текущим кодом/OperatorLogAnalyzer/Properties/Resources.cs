// Decompiled with JetBrains decompiler
// Type: OperatorLogAnalyzer.Properties.Resources
// Assembly: OperatorLogAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A7DBDED-B46A-481E-8C85-402E4F6C7D7A
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\OperatorLogAnalyzer.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace OperatorLogAnalyzer.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Resources.resourceMan == null)
          Resources.resourceMan = new ResourceManager("OperatorLogAnalyzer.Properties.Resources", typeof (Resources).Assembly);
        return Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Resources.resourceCulture;
      }
      set
      {
        Resources.resourceCulture = value;
      }
    }

    internal Resources()
    {
    }
  }
}
