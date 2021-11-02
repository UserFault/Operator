// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Utility
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SpeakIfaceTest1
{
  internal class Utility
  {
    private const string RussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    private const string RussianAlphabetShift = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);

    [DllImport("user32.dll")]
    private static extern bool DeleteMenu(IntPtr hMenu, int uPosition, int uFlags);

    public static void DisableConsoleCloseButton()
    {
      Utility.DeleteMenu(Utility.GetSystemMenu(Process.GetCurrentProcess().MainWindowHandle, 0), 6, 1024);
    }

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    internal static bool DoubleApplication()
    {
      Process currentProcess = Process.GetCurrentProcess();
      string mainWindowTitle = currentProcess.MainWindowTitle;
      Process process = (Process) null;
      foreach (Process p in Process.GetProcesses())
      {
        if (Utility.isProcessCanAccessed(p) && (!p.HasExited && p.MainWindowTitle == mainWindowTitle && p.Id != currentProcess.Id))
        {
          process = p;
          break;
        }
      }
      if (process == null)
        return false;
      IntPtr mainWindowHandle = process.MainWindowHandle;
      bool flag = 1 == 0;
      Utility.ShowWindow(mainWindowHandle, 1);
      Utility.SetForegroundWindow(mainWindowHandle);
      return true;
    }

    private static bool isProcessCanAccessed(Process p)
    {
      bool flag;
      try
      {
        flag = !p.HasExited;
      }
      catch (Exception ex)
      {
        flag = false;
      }
      return flag;
    }

    internal static string getOperatorVersionString()
    {
      return Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    internal static Version getOperatorVersion()
    {
      return Assembly.GetExecutingAssembly().GetName().Version;
    }

    internal static bool IsNotRussianFirst(string query)
    {
      string str = query.Trim();
      return !Utility.IsRussianLetter(str[0]) || !Utility.IsRussianLetter(str[1]);
    }

    private static bool IsRussianLetter(char p)
    {
      return "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".IndexOf(p) != -1 || "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".IndexOf(p) != -1;
    }
  }
}
