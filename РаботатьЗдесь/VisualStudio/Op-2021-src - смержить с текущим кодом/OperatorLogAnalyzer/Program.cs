// Decompiled with JetBrains decompiler
// Type: OperatorLogAnalyzer.Program
// Assembly: OperatorLogAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A7DBDED-B46A-481E-8C85-402E4F6C7D7A
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\OperatorLogAnalyzer.exe

using System;
using System.Windows.Forms;

namespace OperatorLogAnalyzer
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
