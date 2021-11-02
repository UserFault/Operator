// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.RegexManager
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SpeakIfaceTest1
{
  public class RegexManager
  {
    private static ArgumentCollection m_AppMatchArguments;

    public static RegexType determineRegexType(string pattern)
    {
      if (string.IsNullOrEmpty(pattern))
        return RegexType.Empty;
      bool flag1 = (int) pattern[0] == 94;
      bool flag2 = (int) pattern[pattern.Length - 1] == 36;
      if (flag1 & flag2)
        return RegexType.NormalRegex;
      return !(flag1 | flag2) ? RegexType.SimpleString : RegexType.Invalid;
    }

    internal static string ConvertSimpleToRegex(string rx)
    {
      string[] strArray = rx.Trim().Split(new char[1]
      {
        ' '
      }, StringSplitOptions.RemoveEmptyEntries);
      int num = 0;
      for (int index = 0; index < strArray.Length; ++index)
      {
        if ((int) strArray[index][0] == 37)
        {
          strArray[index] = "(?<arg" + num.ToString() + ">.+)";
          ++num;
        }
      }
      return string.Join(" ", strArray);
    }

    internal static string ConvertApplicationCommandString(string cmdline, ArgumentCollection arguments)
    {
      string pattern = "%\\w+";
      RegexManager.m_AppMatchArguments = arguments;
      MatchEvaluator evaluator = new MatchEvaluator(RegexManager.AppMatchEvaluator);
      return Regex.Replace(cmdline, pattern, evaluator);
    }

    private static string AppMatchEvaluator(Match match)
    {
      string argname = match.Value.Substring(1);
      string str = RegexManager.m_AppMatchArguments.GetByName(argname).ArgumentValue;
      if (str.Contains(" "))
        str = (string) (object) '"' + (object) str + (string) (object) '"';
      return str;
    }

    internal static string ConvertSimpleToRegex2(string rx)
    {
      return "^" + Regex.Replace(rx.Trim(), "%\\w+", new MatchEvaluator(RegexManager.SimpleMatchEvaluator)) + "$";
    }

    private static string SimpleMatchEvaluator(Match match)
    {
      return "(?<" + match.Value.Substring(1) + ">.+)";
    }

    internal static string[] ParseCommandLine(string cmdline)
    {
      string[] strArray1 = new string[2];
      string[] strArray2 = new string[8]
      {
        ".exe ",
        ".exe\"",
        ".com ",
        ".com\"",
        ".bat ",
        ".bat\"",
        ".cmd ",
        ".cmd\""
      };
      foreach (string str in strArray2)
      {
        int num1 = cmdline.IndexOf(str, StringComparison.OrdinalIgnoreCase);
        if (num1 >= 0)
        {
          int num2 = num1 + str.Length;
          strArray1[0] = cmdline.Substring(0, num2);
          strArray1[1] = cmdline.Substring(num2);
          return strArray1;
        }
      }
      if (File.Exists(cmdline))
      {
        strArray1[0] = string.Copy(cmdline);
        strArray1[1] = "";
        return strArray1;
      }
      strArray1[0] = string.Copy(cmdline);
      strArray1[1] = "";
      return strArray1;
    }

    internal static bool IsAssemblyCodePath(string path)
    {
      string pattern = "^\\w+\\.\\w+\\.\\w+\\([\\w,\\s]*\\)\\w*$";
      return Regex.IsMatch(path, pattern);
    }

    internal static string[] ParseAssemblyCodePath(string path)
    {
      List<string> list = new List<string>();
      string[] strArray1 = path.Trim().Split(new char[1]
      {
        '('
      }, StringSplitOptions.RemoveEmptyEntries);
      string str1 = strArray1[0];
      string str2 = strArray1[1];
      string[] strArray2 = str1.Split(new char[1]
      {
        '.'
      }, StringSplitOptions.RemoveEmptyEntries);
      list.Add(strArray2[0]);
      list.Add(strArray2[1]);
      list.Add(strArray2[2]);
      int startIndex = str2.IndexOf(')');
      if (startIndex < 0)
        throw new Exception(string.Format("Неправильный путь: {0}", (object) path));
      string str3 = str2.Remove(startIndex);
      if (str3.Length > 0)
      {
        string str4 = str3;
        char[] separator = new char[1]
        {
          ','
        };
        int num = 1;
        foreach (string str5 in str4.Split(separator, (StringSplitOptions) num))
          list.Add(str5.Trim());
      }
      return list.ToArray();
    }

    internal static ArgumentCollection ExtractArgumentsFromCommand(string command, string pattern)
    {
      ArgumentCollection argumentCollection = (ArgumentCollection) null;
      Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
      Match match = regex.Match(command);
      if (match.Success)
      {
        argumentCollection = new ArgumentCollection();
        for (int i = 0; i < match.Groups.Count; ++i)
        {
          string name = regex.GroupNameFromNumber(i);
          string queryValue = match.Groups[i].Value;
          argumentCollection.Add(new FuncArgument(name, "", queryValue, queryValue));
        }
        if (argumentCollection.Arguments.Count > 0)
          argumentCollection.Arguments.RemoveAt(0);
      }
      return argumentCollection;
    }
  }
}
