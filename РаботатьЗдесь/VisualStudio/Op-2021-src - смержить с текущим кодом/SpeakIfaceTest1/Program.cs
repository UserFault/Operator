// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Program
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.IO;
using System.Text;

namespace SpeakIfaceTest1
{
  internal class Program
  {
    private static StreamWriter logWriter = (StreamWriter) null;
    private static Engine m_engine;
    private static ProcedureResult m_exitcode;

    private static void Main(string[] args)
    {
      if (Utility.DoubleApplication())
        return;
      Utility.DisableConsoleCloseButton();
      Console.TreatControlCAsInput = false;
      Console.CancelKeyPress += new ConsoleCancelEventHandler(Program.Console_CancelKeyPress);
      try
      {
        Program.logWriter = new StreamWriter("log.txt", true, Encoding.UTF8);
        Program.logWriter.AutoFlush = true;
        Program.m_engine = new Engine(Program.logWriter);
        Program.m_engine.Init();
        Program.DebugTestPlace();
        Program.m_exitcode = Program.m_engine.ProcessLoop();
        Program.m_engine.Exit();
        Program.logWriter.WriteLine("ENDSESSION {0}", (object) DateTime.Now.ToString());
      }
      catch (Exception ex)
      {
        Console.WriteLine("EXCEPTION {0} : {1}", (object) ex.GetType().ToString(), (object) ex.Message);
        if (Program.logWriter != null)
          Program.logWriter.WriteLine("EXCEPTION {0} : {1}", (object) ex.GetType().ToString(), (object) ex.Message);
        if (Program.m_engine != null)
          Program.m_engine.Exit();
      }
      if (Program.logWriter != null)
        Program.logWriter.Close();
      PowerManager.ProcessExitCode(Program.m_exitcode);
    }

    private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
      if (e.SpecialKey == ConsoleSpecialKey.ControlC)
      {
        e.Cancel = true;
      }
      else
      {
        if (e.SpecialKey != ConsoleSpecialKey.ControlBreak)
          return;
        e.Cancel = false;
        Program.m_engine.Exit();
        StreamWriter streamWriter1 = Program.logWriter;
        string format1 = "Close by Ctrl+Break {0}";
        DateTime now = DateTime.Now;
        string str1 = now.ToString();
        streamWriter1.WriteLine(format1, (object) str1);
        StreamWriter streamWriter2 = Program.logWriter;
        string format2 = "ENDSESSION {0}";
        now = DateTime.Now;
        string str2 = now.ToString();
        streamWriter2.WriteLine(format2, (object) str2);
      }
    }

    private static void DebugTestPlace()
    {
    }
  }
}
