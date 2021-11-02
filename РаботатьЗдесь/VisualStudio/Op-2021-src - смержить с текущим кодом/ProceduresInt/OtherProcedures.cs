// Decompiled with JetBrains decompiler
// Type: ProceduresInt.OtherProcedures
// Assembly: ProceduresInt, Version=1.0.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 343AFDB8-E3B9-460C-8512-A5A5044F200F
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\ProceduresInt.dll

using SpeakIfaceTest1;
using SpeakIfaceTest1.Lexicon;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ProceduresInt
{
  public static class OtherProcedures
  {
    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandCreateNotepadNote(Engine engine, string query, ArgumentCollection args)
    {
      engine.OperatorConsole.PrintTextLine(string.Format("Начата процедура CommandCreateNotepadNote(\"{0}\")", (object) args.Arguments[0].ArgumentValue), DialogConsoleColors.Сообщение);
      string title = args.Arguments[0].ArgumentQueryValue.Trim();
      string str1;
      string str2;
      bool flag;
      while (true)
      {
        str1 = OtherProcedures.ReplaceInvalidPathChars(title, '_');
        str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), str1 + ".txt");
        flag = File.Exists(str2);
        if (flag)
        {
          engine.OperatorConsole.SureConsoleCursorStart();
          engine.OperatorConsole.PrintTextLine(string.Format("Файл заметки {0} уже существует.", (object) str1), DialogConsoleColors.Предупреждение);
          engine.OperatorConsole.SureConsoleCursorStart();
          switch (engine.OperatorConsole.PrintДаНетОтмена("Изменить название заметки?"))
          {
            case SpeakDialogResult.Да:
              engine.OperatorConsole.SureConsoleCursorStart();
              string str3 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите новое название заметки:", true, true);
              if (!Dialogs.этоОтмена(str3))
              {
                title = string.Copy(str3);
                continue;
              }
              goto label_4;
            case SpeakDialogResult.Отмена:
              goto label_6;
            default:
              goto label_7;
          }
        }
        else
          goto label_7;
      }
label_4:
      return ProcedureResult.CancelledByUser;
label_6:
      return ProcedureResult.CancelledByUser;
label_7:
      StreamWriter streamWriter = new StreamWriter(str2, true, Encoding.GetEncoding(1251));
      if (!flag)
      {
        streamWriter.WriteLine(str1);
        streamWriter.WriteLine();
      }
      streamWriter.Close();
      Process.Start(str2);
      engine.OperatorConsole.PrintTextLine(string.Format("Заметка \"{0}\" создана", (object) str1), DialogConsoleColors.Успех);
      return ProcedureResult.Success;
    }

    private static string ReplaceInvalidPathChars(string title, char p)
    {
      StringBuilder stringBuilder = new StringBuilder(title);
      foreach (char oldChar in Path.GetInvalidFileNameChars())
        stringBuilder = stringBuilder.Replace(oldChar, p);
      return stringBuilder.ToString();
    }

    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandOpenNotepadNote(Engine engine, string query, ArgumentCollection args)
    {
      engine.OperatorConsole.PrintTextLine(string.Format("Начата процедура CommandOpenNotepadNote(\"{0}\")", (object) args.Arguments[0].ArgumentValue), DialogConsoleColors.Сообщение);
      string str1 = OtherProcedures.ReplaceInvalidPathChars(args.Arguments[0].ArgumentQueryValue.Trim(), '_');
      string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), str1 + ".txt");
      if (!File.Exists(str2))
      {
        engine.OperatorConsole.SureConsoleCursorStart();
        engine.OperatorConsole.PrintTextLine(string.Format("Файл заметки {0} не найден на Рабочем столе.", (object) str1), DialogConsoleColors.Предупреждение);
        return ProcedureResult.Error;
      }
      Process.Start(str2);
      engine.OperatorConsole.PrintTextLine(string.Format("Заметка \"{0}\" открыта", (object) str1), DialogConsoleColors.Успех);
      return ProcedureResult.Success;
    }
  }
}
