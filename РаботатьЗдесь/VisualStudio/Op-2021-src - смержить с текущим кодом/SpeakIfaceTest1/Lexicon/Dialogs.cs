// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Lexicon.Dialogs
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakIfaceTest1.Lexicon
{
  public class Dialogs
  {
    protected static string[] СтандартныеДа = new string[1]
    {
      "Да"
    };
    protected static string[] СтандартныеНет = new string[1]
    {
      "Нет"
    };
    protected static string[] СтандартныеОтмена = new string[3]
    {
      "Отмена",
      "отмени",
      "отменить"
    };
    protected static string[] СтандартныеОтложить = new string[2]
    {
      "Отложить",
      "Отложи"
    };
    protected static string[] СтандартныеПрервать = new string[2]
    {
      "Прервать",
      "Прерви"
    };
    protected static string[] СтандартныеПовторить = new string[3]
    {
      "Повтор",
      "Повторить",
      "Повтори"
    };
    protected static string[] СтандартныеПропустить = new string[3]
    {
      "Пропуск",
      "Пропустить",
      "Пропусти"
    };
    private static string[] ExitAppCommands = new string[6]
    {
      "выход",
      "выйти",
      "закрыть",
      "quit",
      "close",
      "exit"
    };
    private static string[] ExitSleepCommands = new string[3]
    {
      "спать",
      "спи",
      "sleep"
    };
    private static string[] ExitReloadCommands = new string[6]
    {
      "перезагрузить",
      "перезагрузись",
      "перезагрузка",
      "перезагрузить компьютер",
      "reload",
      "restart"
    };
    private static string[] ExitShutdownCommands = new string[5]
    {
      "выключись",
      "выключайся",
      "выключить компьютер",
      "poweroff",
      "shutdown"
    };
    private static string[] ExitLogoffCommands = new string[3]
    {
      "завершить сеанс",
      "завершение сеанса",
      "logoff"
    };

    public static string makeСтрокаОжидаемыхОтветов(SpeakDialogResult ожидаемыеОтветы)
    {
      if (ожидаемыеОтветы == SpeakDialogResult.Unknown)
        return string.Empty;
      List<string> list = new List<string>();
      if ((ожидаемыеОтветы & SpeakDialogResult.Да) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеДа[0]);
      if ((ожидаемыеОтветы & SpeakDialogResult.Нет) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеНет[0]);
      if ((ожидаемыеОтветы & SpeakDialogResult.Отмена) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеОтмена[0]);
      if ((ожидаемыеОтветы & SpeakDialogResult.Отложить) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеОтложить[0]);
      if ((ожидаемыеОтветы & SpeakDialogResult.Прервать) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеПрервать[0]);
      if ((ожидаемыеОтветы & SpeakDialogResult.Повторить) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеПовторить[0]);
      if ((ожидаемыеОтветы & SpeakDialogResult.Пропустить) != SpeakDialogResult.Unknown)
        list.Add(Dialogs.СтандартныеПропустить[0]);
      if (list.Count == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append('[');
      int num = list.Count - 1;
      for (int index = 0; index < list.Count; ++index)
      {
        stringBuilder.Append(list[index]);
        if (index < num)
          stringBuilder.Append('/');
      }
      stringBuilder.Append(']');
      list.Clear();
      return stringBuilder.ToString();
    }

    public static bool этоДа(string текстОтветаПользователя)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.СтандартныеДа, текстОтветаПользователя.Trim());
    }

    public static bool этоНет(string текстОтветаПользователя)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.СтандартныеНет, текстОтветаПользователя.Trim());
    }

    public static bool этоОтмена(string текстОтветаПользователя)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.СтандартныеОтмена, текстОтветаПользователя.Trim());
    }

    public static SpeakDialogResult этоДаНетОтмена(string текстОтвета)
    {
      string текстОтветаПользователя = текстОтвета.Trim();
      if (Dialogs.этоДа(текстОтветаПользователя))
        return SpeakDialogResult.Да;
      if (Dialogs.этоНет(текстОтветаПользователя))
        return SpeakDialogResult.Нет;
      return Dialogs.этоОтмена(текстОтветаПользователя) ? SpeakDialogResult.Отмена : SpeakDialogResult.Unknown;
    }

    internal static bool arrayContainsStringOrdinalIgnoreCase(string[] array, string sample)
    {
      foreach (string a in array)
      {
        if (string.Equals(a, sample, StringComparison.OrdinalIgnoreCase))
          return true;
      }
      return false;
    }

    internal static bool isExitAppCommand(string query)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.ExitAppCommands, query.Trim());
    }

    internal static bool isSleepCommand(string query)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.ExitSleepCommands, query.Trim());
    }

    internal static bool isExitReloadCommand(string query)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.ExitReloadCommands, query.Trim());
    }

    internal static bool isExitShutdownCommand(string query)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.ExitShutdownCommands, query.Trim());
    }

    internal static bool isExitLogoffCommand(string query)
    {
      return Dialogs.arrayContainsStringOrdinalIgnoreCase(Dialogs.ExitLogoffCommands, query.Trim());
    }
  }
}
