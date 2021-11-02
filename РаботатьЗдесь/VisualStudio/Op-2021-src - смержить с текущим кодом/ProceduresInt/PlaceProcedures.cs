// Decompiled with JetBrains decompiler
// Type: ProceduresInt.PlaceProcedures
// Assembly: ProceduresInt, Version=1.0.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 343AFDB8-E3B9-460C-8512-A5A5044F200F
// Assembly location: C:\Users\Администратор\ЛокальныеИнструменты\Operator\ProceduresInt.dll

using SpeakIfaceTest1;
using SpeakIfaceTest1.Lexicon;
using System.Collections.Generic;

namespace ProceduresInt
{
  public static class PlaceProcedures
  {
    private static string[] ВопросыПадежныхФорм = new string[6]
    {
      "И.п. Это что?",
      "Р.п. Владелец чего?",
      "Д.п. Дали чему?",
      "В.п. Обвинили что?",
      "Тв.п. Творимый чем?",
      "Пр.п. Рассказ о чем?"
    };

    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandCreatePlace(Engine engine, string query, ArgumentCollection args)
    {
      engine.OperatorConsole.PrintTextLine(string.Format("Начата процедура CommandCreatePlace(\"{0}\")", (object) args.Arguments[0].ArgumentValue), DialogConsoleColors.Сообщение);
      string str1 = string.Empty;
      Place p = new Place();
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("1. Название Места", DialogConsoleColors.Сообщение);
      FuncArgument funcArgument = args.Arguments[0];
      string str2 = funcArgument.ArgumentQueryValue.Trim();
      engine.OperatorConsole.PrintTextLine(string.Format("Название нового Места: {0}", (object) str2), DialogConsoleColors.Сообщение);
      if (funcArgument.АвтоподстановкаМеста)
      {
        engine.OperatorConsole.PrintTextLine("Место с таким названием уже существует:", DialogConsoleColors.Предупреждение);
        engine.OperatorConsole.PrintPlaceShortLine(funcArgument.AssociatedPlace);
        return ProcedureResult.Error;
      }
      bool flag = false;
      do
      {
        if (string.IsNullOrEmpty(str2))
        {
          engine.OperatorConsole.PrintTextLine("Пустая строка недопустима для названия Места!", DialogConsoleColors.Предупреждение);
        }
        else
        {
          List<Place> placesByTitle = engine.DbGetPlacesByTitle(str2);
          flag = placesByTitle.Count > 0;
          if (flag)
          {
            engine.OperatorConsole.PrintTextLine("Места с таким названием уже существуют:", DialogConsoleColors.Предупреждение);
            foreach (Place place in placesByTitle)
              engine.OperatorConsole.PrintPlaceShortLine(placesByTitle[0]);
            engine.OperatorConsole.PrintTextLine("Дубликаты Мест недопустимы!", DialogConsoleColors.Предупреждение);
            placesByTitle.Clear();
          }
        }
        if (str2 == string.Empty || flag)
          str2 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите новое название Места:", false, true);
        else
          goto label_16;
      }
      while (!Dialogs.этоОтмена(str2));
      return ProcedureResult.CancelledByUser;
label_16:
      p.Title = str2;
      if (!PlaceProcedures.ВводитьСловоформыМеста(engine, p))
        return ProcedureResult.CancelledByUser;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("3. Описание Места", DialogConsoleColors.Сообщение);
      string текстОтветаПользователя1 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите краткое описание Места:", true, true);
      if (Dialogs.этоОтмена(текстОтветаПользователя1))
        return ProcedureResult.CancelledByUser;
      p.Description = текстОтветаПользователя1;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("4. Адрес Места", DialogConsoleColors.Сообщение);
      string текстОтветаПользователя2 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите адрес Места:", true, true);
      if (Dialogs.этоОтмена(текстОтветаПользователя2))
        return ProcedureResult.CancelledByUser;
      p.Path = текстОтветаПользователя2;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("5. Класс Места", DialogConsoleColors.Сообщение);
      string текстОтветаПользователя3 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите класс Места:", true, true);
      if (Dialogs.этоОтмена(текстОтветаПользователя3))
        return ProcedureResult.CancelledByUser;
      p.PlaceTypeExpression = текстОтветаПользователя3;
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("6. Подтвердите создание Места", DialogConsoleColors.Сообщение);
      engine.OperatorConsole.PrintPlaceForm(p);
      SpeakDialogResult speakDialogResult = engine.OperatorConsole.PrintДаНетОтмена("Желаете создать новое Место?");
      if (speakDialogResult == SpeakDialogResult.Отмена || speakDialogResult == SpeakDialogResult.Нет)
        return ProcedureResult.CancelledByUser;
      engine.DbInsertPlace(p);
      engine.OperatorConsole.PrintTextLine(string.Format("Место \"{0}\" создано успешно", (object) p.Title), DialogConsoleColors.Успех);
      return ProcedureResult.Success;
    }

    private static bool ВводитьСловоформыМеста(Engine engine, Place p)
    {
      string str1 = string.Empty;
      engine.OperatorConsole.SureConsoleCursorStart();
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("2. Словоформы Места", DialogConsoleColors.Сообщение);
      string str2;
      while (true)
      {
        do
        {
          engine.OperatorConsole.SureConsoleCursorStart();
          engine.OperatorConsole.PrintTextLine("Нужно ввести все падежные формы названия места для всех синонимов.", DialogConsoleColors.Сообщение);
          switch (engine.OperatorConsole.PrintДаНетОтмена("Желаете ввести сразу все словоформы одной строкой?"))
          {
            case SpeakDialogResult.Да:
              engine.OperatorConsole.PrintTextLine("Нужно ввести падежные формы (И,Р,Д,В,Т,П) разделяя их запятыми.", DialogConsoleColors.Сообщение);
              engine.OperatorConsole.PrintTextLine("Пример: место, места, месту, места, местом, месте", DialogConsoleColors.Сообщение);
              str2 = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, "Введите строку словоформ названия Места:", true, true);
              continue;
            case SpeakDialogResult.Нет:
              goto label_3;
            default:
              goto label_5;
          }
        }
        while (Dialogs.этоОтмена(str2));
        goto label_6;
label_3:
        str2 = PlaceProcedures.ВводитьСловоформыПоОтдельности(engine);
        if (string.IsNullOrEmpty(str2))
          break;
label_6:
        if (!Place.checkSynonimString(str2))
        {
          engine.OperatorConsole.SureConsoleCursorStart();
          engine.OperatorConsole.PrintTextLine("Ошибка! Строка словоформ имеет неправильный формат.", DialogConsoleColors.Предупреждение);
        }
        else
          goto label_8;
      }
      return false;
label_5:
      return false;
label_8:
      p.Synonim = str2;
      return true;
    }

    private static string ВводитьСловоформыПоОтдельности(Engine engine)
    {
      string str = string.Empty;
      List<string> list = new List<string>();
label_1:
      engine.OperatorConsole.SureConsoleCursorStart();
      engine.OperatorConsole.PrintTextLine("Введите словоформы по одной согласно падежу:", DialogConsoleColors.Сообщение);
      foreach (string question in PlaceProcedures.ВопросыПадежныхФорм)
      {
        engine.OperatorConsole.SureConsoleCursorStart();
        string текстОтветаПользователя = engine.OperatorConsole.PrintQuestionAnswer(SpeakDialogResult.Отмена, question, false, true);
        if (Dialogs.этоОтмена(текстОтветаПользователя))
          return str;
        list.Add(текстОтветаПользователя);
      }
      str = string.Join(", ", list.ToArray());
      engine.OperatorConsole.SureConsoleCursorStart();
      engine.OperatorConsole.PrintTextLine(string.Format("Строка словоформ: {0}", (object) str), DialogConsoleColors.Сообщение);
      switch (engine.OperatorConsole.PrintДаНетОтмена("Желаете ввести словоформы еще одного синонима места?"))
      {
        case SpeakDialogResult.Да:
          goto label_1;
        case SpeakDialogResult.Нет:
          return str;
        default:
          return string.Empty;
      }
    }

    [Procedure(ImplementationState.NotTested)]
    public static ProcedureResult CommandListPlaces(Engine engine, string query, ArgumentCollection args)
    {
      engine.OperatorConsole.PrintTextLine("Начата процедура CommandListPlaces()", DialogConsoleColors.Сообщение);
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("Список всех Мест Оператора", DialogConsoleColors.Сообщение);
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintListOfPlaces();
      engine.OperatorConsole.PrintEmptyLine();
      engine.OperatorConsole.PrintTextLine("Выведен список Мест", DialogConsoleColors.Успех);
      return ProcedureResult.Success;
    }
  }
}
