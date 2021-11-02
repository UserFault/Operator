// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Lexicon.DialogConsole
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using SpeakIfaceTest1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SpeakIfaceTest1.Lexicon
{
  public class DialogConsole
  {
    private Engine m_Engine;
    private ConsoleColor m_defaultColor;
    private CultureInfo m_RuCulture;

    public CultureInfo RuCulture
    {
      get
      {
        return this.m_RuCulture;
      }
    }

    public DialogConsole()
    {
      this.m_defaultColor = ConsoleColor.Gray;
      Console.ForegroundColor = this.m_defaultColor;
      this.m_RuCulture = CultureInfo.CreateSpecificCulture("ru-RU");
    }

    public DialogConsole(Engine engine)
    {
      this.m_Engine = engine;
      this.m_defaultColor = ConsoleColor.Gray;
      Console.ForegroundColor = this.m_defaultColor;
      this.m_RuCulture = CultureInfo.CreateSpecificCulture("ru-RU");
    }

    public void ResetColor()
    {
      Console.ForegroundColor = this.m_defaultColor;
    }

    public void Beep()
    {
      Console.Beep();
    }

    public void SureConsoleCursorStart()
    {
      if (Console.CursorLeft <= 0)
        return;
      Console.WriteLine();
    }

    public void PrintText(string text, DialogConsoleColors color)
    {
      Console.ForegroundColor = (ConsoleColor) color;
      Console.Write(text);
      this.ResetColor();
    }

    public void PrintEmptyLine()
    {
      Console.WriteLine();
    }

    public void PrintTextLine(string text, DialogConsoleColors color)
    {
      if (string.IsNullOrEmpty(text))
      {
        Console.WriteLine();
      }
      else
      {
        Console.ForegroundColor = (ConsoleColor) color;
        Console.WriteLine(text);
        this.ResetColor();
      }
    }

    public void PrintTextLines(string[] lines, DialogConsoleColors color)
    {
      Console.ForegroundColor = (ConsoleColor) color;
      foreach (string str in lines)
        Console.WriteLine(str);
      this.ResetColor();
    }

    public string ReadLine()
    {
      Console.ForegroundColor = ConsoleColor.White;
      string str = Console.ReadLine();
      this.ResetColor();
      return str;
    }

    public string PrintQuestionAnswer(SpeakDialogResult keys, string question, bool newLine, bool noEmptyAnswer)
    {
      this.SureConsoleCursorStart();
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.Write(question);
      Console.Write(' ');
      Console.Write(Dialogs.makeСтрокаОжидаемыхОтветов(keys));
      this.ResetColor();
      if (newLine)
        Console.WriteLine();
      string str1 = string.Empty;
      string str2;
      do
      {
        string str3 = this.ReadLine();
        str2 = str3 != null ? str3.Trim() : string.Empty;
      }
      while ((noEmptyAnswer || !string.IsNullOrEmpty(str2)) && string.IsNullOrEmpty(str2));
      return str2;
    }

    public SpeakDialogResult PrintДаНетОтмена(string текстЗапроса)
    {
      this.SureConsoleCursorStart();
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.Write(текстЗапроса);
      Console.Write(' ');
      Console.Write(Dialogs.makeСтрокаОжидаемыхОтветов(SpeakDialogResult.ДаНетОтмена));
      this.ResetColor();
      string str = string.Empty;
      while (true)
      {
        string текстОтветаПользователя = this.ReadLine() ?? string.Empty;
        if (!Dialogs.этоДа(текстОтветаПользователя))
        {
          if (!Dialogs.этоНет(текстОтветаПользователя))
          {
            if (!Dialogs.этоОтмена(текстОтветаПользователя))
            {
              this.SureConsoleCursorStart();
              this.PrintTextLine("Принимаются только ответы Да, Нет или Отмена!", DialogConsoleColors.Предупреждение);
            }
            else
              goto label_6;
          }
          else
            goto label_4;
        }
        else
          break;
      }
      return SpeakDialogResult.Да;
label_4:
      return SpeakDialogResult.Нет;
label_6:
      return SpeakDialogResult.Отмена;
    }

    public string CreateLongDatetimeString(DateTime dt)
    {
      return dt.ToString("dddd, d MMMM yyyyг. HH:mm:ss", (IFormatProvider) this.m_RuCulture);
    }

    public void PrintExceptionMessage(string title, Exception ex)
    {
      StringBuilder stringBuilder = new StringBuilder(title);
      stringBuilder.Append(' ');
      stringBuilder.Append(ex.GetType().ToString());
      stringBuilder.Append(": ");
      stringBuilder.Append(ex.Message);
      this.PrintTextLine(stringBuilder.ToString(), DialogConsoleColors.Предупреждение);
    }

    public void PrintExceptionMessage(Exception ex)
    {
      this.PrintExceptionMessage("Ошибка", ex);
    }

    public void PrintPlaceShortLine(Place place)
    {
      this.SureConsoleCursorStart();
      this.PrintTextLine(place.getSingleLineProperties(), DialogConsoleColors.Сообщение);
    }

    public void PrintPlaceForm(Place p)
    {
      this.SureConsoleCursorStart();
      this.PrintTextLine(string.Format("Свойства Места \"{0}\":", (object) p.Title), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Название: {0}", (object) p.Title), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Класс:    {0}", (object) p.PlaceTypeExpression), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Адрес:    {0}", (object) p.Path), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Синонимы: {0}", (object) p.Synonim), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Описание: {0}", (object) p.Description), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("ID:       {0}", (object) p.TableId.ToString()), DialogConsoleColors.Сообщение);
      this.PrintEmptyLine();
    }

    public void PrintListOfPlaces()
    {
      this.SureConsoleCursorStart();
      List<Place> allPlaces = this.m_Engine.Database.GetAllPlaces();
      allPlaces.Sort(new Comparison<Place>(Item.SortByTitle));
      foreach (Place place in allPlaces)
        this.PrintTextLine(string.Format("{0} [{1}]", (object) place.Title, (object) place.Path), DialogConsoleColors.Сообщение);
    }

    public void PrintListOfProcedures()
    {
      this.SureConsoleCursorStart();
      List<Procedure> allProcedures = this.m_Engine.Database.GetAllProcedures();
      allProcedures.Sort(new Comparison<Procedure>(Item.SortByTitle));
      foreach (Procedure procedure in allProcedures)
        this.PrintTextLine(string.Format("{0} [{1}]", (object) procedure.Title, (object) procedure.Description), DialogConsoleColors.Сообщение);
    }

    public void PrintProcedureShortLine(Procedure p)
    {
      this.SureConsoleCursorStart();
      this.PrintTextLine(p.getSingleLineProperties(), DialogConsoleColors.Сообщение);
    }

    public void PrintProcedureForm(Procedure p)
    {
      this.SureConsoleCursorStart();
      this.PrintTextLine(string.Format("Свойства Команды \"{0}\":", (object) p.Title), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Название: {0}", (object) p.Title), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Описание: {0}", (object) p.Description), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Регекс:   {0}", (object) p.Regex), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Адрес:    {0}", (object) p.Path), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("Вес:      {0}", (object) p.Ves), DialogConsoleColors.Сообщение);
      this.PrintTextLine(string.Format("ID:       {0}", (object) p.TableId.ToString()), DialogConsoleColors.Сообщение);
      this.PrintEmptyLine();
    }
  }
}
