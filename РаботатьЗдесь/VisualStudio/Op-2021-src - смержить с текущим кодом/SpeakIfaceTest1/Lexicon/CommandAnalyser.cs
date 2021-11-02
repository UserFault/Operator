// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Lexicon.CommandAnalyser
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using SpeakIfaceTest1;

namespace SpeakIfaceTest1.Lexicon
{
  public class CommandAnalyser
  {
    internal static ProcedureResult ProcessQuery(Engine engine, string query)
    {
      return engine.DoQuery(query);
    }
  }
}
