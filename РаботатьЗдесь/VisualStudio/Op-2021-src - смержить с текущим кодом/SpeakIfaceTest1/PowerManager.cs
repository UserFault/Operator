// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.PowerManager
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SpeakIfaceTest1
{
  public class PowerManager
  {
    [DllImport("Powrprof.dll", CharSet = CharSet.Auto)]
    public static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

    public static void ProcessExitCode(ProcedureResult exitcode)
    {
      switch (exitcode)
      {
        case ProcedureResult.ExitAndSleep:
          PowerManager.DoSleep();
          break;
        case ProcedureResult.ExitAndReload:
          PowerManager.DoReload();
          break;
        case ProcedureResult.ExitAndShutdown:
          PowerManager.DoShutdown();
          break;
        case ProcedureResult.ExitAndLogoff:
          PowerManager.DoLogoff();
          break;
        case ProcedureResult.ExitAndHybernate:
          PowerManager.DoHybernate();
          break;
      }
    }

    public static void DoHybernate()
    {
      PowerManager.SetSuspendState(true, true, true);
    }

    public static void DoSleep()
    {
      PowerManager.SetSuspendState(false, true, true);
    }

    public static void DoLogoff()
    {
      Process.Start("Shutdown.exe", " -l -t 00");
    }

    public static void DoReload()
    {
      Process.Start("Shutdown.exe", "-r -t 00");
    }

    public static void DoShutdown()
    {
      Process.Start("Shutdown.exe", "-s -t 00");
    }

    public static void ExecuteApplication(string cmdline)
    {
      string[] strArray = RegexManager.ParseCommandLine(cmdline);
      PowerManager.ExecuteApplication(strArray[0], strArray[1]);
    }

    public static void ExecuteApplication(string app, string args)
    {
      Process.Start(new ProcessStartInfo(app, args)
      {
        WindowStyle = ProcessWindowStyle.Normal,
        WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
      });
    }
  }
}
