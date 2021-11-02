// Decompiled with JetBrains decompiler
// Type: ProceduresInt.ProcedureProcedures
// Assembly: ProceduresInt, Version=1.0.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 343AFDB8-E3B9-460C-8512-A5A5044F200F
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\ProceduresInt.dll

using SpeakIfaceTest1;
using SpeakIfaceTest1.Lexicon;
using System;
using System.Collections.Generic;

namespace ProceduresInt
{
  public static class ProcedureProcedures
  {
    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandCreateProcedure(Engine engine, string query, ArgumentCollection args)
    {
      string text = string.Format("Начата процедура CommandCreateProcedure(\"{0}\")", (object) args.Arguments[0].ArgumentValue);
      engine.OperatorConsole.PrintTextLine(text, DialogConsoleColors.Сообщение);
      Procedure p = new Procedure();
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("1. Название Команды", DialogConsoleColors.Сообщение);
      FuncArgument funcArgument = args.Arguments[0];
      string str1 = funcArgument.ArgumentQueryValue.Trim();
      engine.OperatorConsole.PrintTextLine(string.Format("Название новой Команды: {0}", (object) str1), DialogConsoleColors.Сообщение);
      if (!funcArgument.АвтоподстановкаМеста)
        ;
      bool flag1 = false;
      do
      {
        if (string.IsNullOrEmpty(str1))
        {
          engine.OperatorConsole.PrintTextLine("Пустая строка недопустима для названия Команды!", DialogConsoleColors.Предупреждение);
        }
        else
        {
          List<Procedure> proceduresByTitle = engine.DbGetProceduresByTitle(str1);
          flag1 = proceduresByTitle.Count > 0;
          if (flag1)
          {
            engine.OperatorConsole.PrintTextLine("Команды с таким названием уже существуют:", DialogConsoleColors.Предупреждение);
            foreach (Procedure procedure in proceduresByTitle)
              engine.OperatorConsole.PrintProcedureShortLine(proceduresByTitle[0]);
            engine.OperatorConsole.PrintTextLine("Дубликаты Команд недопустимы!", DialogConsoleColors.Предупреждение);
            proceduresByTitle.Clear();
          }
        }
        if (str1 == string.Empty || flag1)
          str1 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите новое название Команды:", false, true);
        else
          goto label_15;
      }
      while (!Dialogs.этоОтмена(str1));
      return ProcedureResult.CancelledByUser;
label_15:
      p.Title = str1;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("2. Описание Команды", DialogConsoleColors.Сообщение);
      string текстОтветаПользователя1 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите краткое описание Команды:", true, true);
      if (Dialogs.этоОтмена(текстОтветаПользователя1))
        return ProcedureResult.CancelledByUser;
      p.Description = текстОтветаПользователя1;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("3. Регекс Команды", DialogConsoleColors.Сообщение);
      string[] lines1 = new string[6]
      {
        " - Команда будет выбрана для исполнения, если ее Регекс опознает текст, введенный Пользователем",
        " - Простой Регекс содержит текст Команды и аргументы. Аргумент обозначается словом с знаком % перед ним.",
        "   Например: Открыть сайт %Аргумент",
        " - Сложный Регекс это специально форматированный текст. ",
        " - Обратитесь к документации, чтобы узнать больше о Регексе Команды",
        string.Empty
      };
      engine.OperatorConsole.PrintTextLines(lines1, DialogConsoleColors.Сообщение);
      string текстОтветаПользователя2 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите регекс для Команды:", true, true);
      if (Dialogs.этоОтмена(текстОтветаПользователя2))
        return ProcedureResult.CancelledByUser;
      p.Regex = текстОтветаПользователя2;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("4. Адрес Процедуры Команды", DialogConsoleColors.Сообщение);
      string[] lines2 = new string[9]
      {
        " - Описывает командную строку исполняемого файла или путь к Процедуре Команды в Сборке Процедур",
        " - Для исполняемых файлов, используемых в качестве Процедур, путь может содержать аргументы.",
        "   Например: C:\\Program Files\\Windows Media Player\\wmplayer.exe %место",
        "   Аргументы идентифицируются по своим именам, заданным в Регексе Команды.",
        " - Для Процедур из СборкиПроцедур прописывается путь в формате СборкаПроцедур.Класс.Функция().",
        "   Аргументы идентифицируются внутри кода функции Процедуры, по своим именам, заданным в Регексе Команды.",
        "   Например: ProceduresInt.ProcedureProcedures.CommandCreateProcedure()",
        " - Обратитесь к документации, чтобы узнать больше о Адресе Процедуры Команды",
        string.Empty
      };
      engine.OperatorConsole.PrintTextLines(lines2, DialogConsoleColors.Сообщение);
      string текстОтветаПользователя3 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите адрес Процедуры для Команды:", true, true);
      if (Dialogs.этоОтмена(текстОтветаПользователя3))
        return ProcedureResult.CancelledByUser;
      p.Path = текстОтветаПользователя3;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("5. Вес Команды", DialogConsoleColors.Сообщение);
      string[] lines3 = new string[5]
      {
        " - Вес определяет порядок выбора для исполнения одной из Команд, подходящих по Регексу",
        " - Команда с наибольшим Весом будет выполнена последней",
        " - Вес должен быть больше 0,0 и меньше 1,0",
        " - Для новой Команды рекомендуется значение 0,5",
        string.Empty
      };
      engine.OperatorConsole.PrintTextLines(lines3, DialogConsoleColors.Сообщение);
      string str2 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите Вес Команды:", true, true);
      if (Dialogs.этоОтмена(str2))
        return ProcedureResult.CancelledByUser;
      bool flag2;
      do
      {
        flag2 = Procedure.IsValidVesFormat(str2, engine.OperatorConsole.RuCulture);
        if (!flag2)
        {
          engine.OperatorConsole.PrintTextLine("Это значение Веса является недопустимым!", DialogConsoleColors.Предупреждение);
          str2 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите новое значение Веса для Команды:", true, true);
          if (Dialogs.этоОтмена(str2))
            return ProcedureResult.CancelledByUser;
        }
      }
      while (!flag2);
      p.Ves = double.Parse(str2, (IFormatProvider) engine.OperatorConsole.RuCulture);
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("6. Подтвердите создание Команды", DialogConsoleColors.Сообщение);
      engine.OperatorConsole.PrintProcedureForm(p);
      SpeakDialogResult speakDialogResult = engine.OperatorConsole.PrintДаНетОтмена("Желаете создать новую Команду?");
      if (speakDialogResult == SpeakDialogResult.Отмена || speakDialogResult == SpeakDialogResult.Нет)
        return ProcedureResult.CancelledByUser;
      engine.DbInsertProcedure(p);
      engine.OperatorConsole.PrintTextLine(string.Format("Команда \"{0}\" создана успешно", (object) p.Title), DialogConsoleColors.Успех);
      return ProcedureResult.Success;
    }

    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandListProcedures(Engine engine, string query, ArgumentCollection args)
    {
      engine.OperatorConsole.PrintTextLine("Начата процедура CommandListProcedures()", DialogConsoleColors.Сообщение);
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("Список всех Команд Оператора:", DialogConsoleColors.Сообщение);
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintListOfProcedures();
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("Выведен список Команд", DialogConsoleColors.Успех);
      return ProcedureResult.Success;
    }
  }
}
