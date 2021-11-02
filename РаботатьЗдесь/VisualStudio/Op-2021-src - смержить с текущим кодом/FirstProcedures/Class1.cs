// Decompiled with JetBrains decompiler
// Type: FirstProcedures.Procedures
// Assembly: FirstProcedures, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: B0AAD4DC-71B5-43C5-8622-DE73DD6FE8B0
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\FirstProcedures.dll

using SpeakIfaceTest1;
using SpeakIfaceTest1.Lexicon;

namespace FirstProcedures
{
  public static class Procedures
  {
    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandHandlerExample(Engine engine, string query, ArgumentCollection args)
    {
      engine.OperatorConsole.PrintTextLine("Message from command handler function", DialogConsoleColors.Сообщение);
      return ProcedureResult.Success;
    }
  }
}
