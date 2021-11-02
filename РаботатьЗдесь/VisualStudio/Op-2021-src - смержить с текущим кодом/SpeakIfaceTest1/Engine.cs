// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Engine
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using SpeakIfaceTest1.Lexicon;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpeakIfaceTest1
{
  public class Engine
  {
    private StreamWriter logWriter;
    private CachedDbAdapter m_db;
    private DialogConsole m_OperatorConsole;

    internal CachedDbAdapter Database
    {
      get
      {
        return this.m_db;
      }
    }

    public DialogConsole OperatorConsole
    {
      get
      {
        return this.m_OperatorConsole;
      }
    }

    public Engine(StreamWriter log)
    {
      this.logWriter = log;
      this.m_db = new CachedDbAdapter();
      this.m_OperatorConsole = new DialogConsole(this);
    }

    public void Init()
    {
      this.OperatorConsole.PrintTextLine("Консоль речевого интерфейса. Версия " + Utility.getOperatorVersionString(), DialogConsoleColors.Сообщение);
      this.OperatorConsole.PrintTextLine("Для завершения работы приложения введите слово выход или quit", DialogConsoleColors.Сообщение);
      this.OperatorConsole.PrintTextLine("Сегодня " + this.OperatorConsole.CreateLongDatetimeString(DateTime.Now), DialogConsoleColors.Сообщение);
      this.logWriter.WriteLine("SESSION {0}", (object) DateTime.Now.ToString());
      string str = "sidb.sqlite";
      string connectionString = SqliteDbAdapter.CreateConnectionString(str, false);
      SqliteDbAdapter sqliteDbAdapter = new SqliteDbAdapter();
      if (!File.Exists(str))
      {
        SqliteDbAdapter.DatabaseCreate(str);
        sqliteDbAdapter.Open(connectionString);
        sqliteDbAdapter.CreateDatabaseTables();
        sqliteDbAdapter.Close();
        if (File.Exists("SIdb.mdb"))
        {
          OleDbAdapter oleDbAdapter = new OleDbAdapter();
          oleDbAdapter.Open(OleDbAdapter.CreateConnectionString("SIdb.mdb"));
          List<Place> allPlaces = oleDbAdapter.GetAllPlaces();
          List<Procedure> allProcedures = oleDbAdapter.GetAllProcedures();
          oleDbAdapter.Close();
          sqliteDbAdapter.Open();
          sqliteDbAdapter.TransactionBegin();
          foreach (Place p in allPlaces)
            sqliteDbAdapter.AddPlace(p);
          sqliteDbAdapter.TransactionCommit();
          sqliteDbAdapter.TransactionBegin();
          foreach (Procedure p in allProcedures)
            sqliteDbAdapter.AddProcedure(p);
          sqliteDbAdapter.TransactionCommit();
          sqliteDbAdapter.Close();
        }
      }
      this.m_db.Open(connectionString);
    }

    internal void Exit()
    {
      if (this.m_db == null)
        return;
      this.m_db.Close();
    }

    public ProcedureResult ProcessLoop()
    {
      ProcedureResult result;
      while (true)
      {
        do
        {
          string query;
          do
          {
            this.OperatorConsole.PrintTextLine(string.Empty, DialogConsoleColors.Сообщение);
            this.OperatorConsole.PrintTextLine("Введите ваш запрос:", DialogConsoleColors.Сообщение);
            query = this.OperatorConsole.ReadLine().Trim();
          }
          while (string.IsNullOrEmpty(query));
          this.logWriter.WriteLine("QUERY {0}", (object) query);
          if (!Dialogs.isSleepCommand(query))
          {
            if (!Dialogs.isExitAppCommand(query))
            {
              if (!Dialogs.isExitShutdownCommand(query))
              {
                if (!Dialogs.isExitReloadCommand(query))
                {
                  if (!Dialogs.isExitLogoffCommand(query))
                  {
                    result = this.EventCommandArrived(query);
                    this.describeProcedureResult(result);
                  }
                  else
                    goto label_10;
                }
                else
                  goto label_8;
              }
              else
                goto label_6;
            }
            else
              goto label_4;
          }
          else
            goto label_2;
        }
        while (result != ProcedureResult.Exit && result != ProcedureResult.ExitAndReload && result != ProcedureResult.ExitAndShutdown && result != ProcedureResult.ExitAndLogoff);
        goto label_12;
label_2:
        PowerManager.DoSleep();
      }
label_4:
      return ProcedureResult.Exit;
label_6:
      return ProcedureResult.ExitAndShutdown;
label_8:
      return ProcedureResult.ExitAndReload;
label_10:
      return ProcedureResult.ExitAndLogoff;
label_12:
      return result;
    }

    private ProcedureResult EventCommandArrived(string query)
    {
      return CommandAnalyser.ProcessQuery(this, query);
    }

    private void describeProcedureResult(ProcedureResult result)
    {
      string text = (string) null;
      bool flag = false;
      switch (result)
      {
        case ProcedureResult.Unknown:
        case ProcedureResult.Error:
          text = "Ошибка при исполнении процедуры";
          flag = true;
          break;
        case ProcedureResult.WrongArguments:
          text = "Ошибка: неправильные аргументы";
          flag = true;
          break;
        case ProcedureResult.Exit:
          text = "Завершение программы...";
          break;
        case ProcedureResult.ExitAndSleep:
        case ProcedureResult.ExitAndHybernate:
          text = "Переход в спящий режим...";
          break;
        case ProcedureResult.ExitAndReload:
          text = "Перезагрузка компьютера...";
          break;
        case ProcedureResult.ExitAndShutdown:
          text = "Выключение компьютера...";
          break;
        case ProcedureResult.ExitAndLogoff:
          text = "Завершение сеанса пользователя...";
          break;
        case ProcedureResult.CancelledByUser:
          text = "Процедура прервана пользователем";
          break;
      }
      DialogConsoleColors color;
      if (flag)
      {
        this.OperatorConsole.Beep();
        color = DialogConsoleColors.Предупреждение;
      }
      else
        color = DialogConsoleColors.Сообщение;
      this.OperatorConsole.SureConsoleCursorStart();
      this.OperatorConsole.PrintTextLine(text, color);
    }

    internal ProcedureResult DoQuery(string query)
    {
      if (Utility.IsNotRussianFirst(query))
        return this.ExecuteWithTerminal(query);
      foreach (Procedure p in this.m_db.Procedures.Procedures)
      {
        string str = this.MakeNormalRegex(p);
        ArgumentCollection argumentsFromCommand = RegexManager.ExtractArgumentsFromCommand(query, str);
        if (argumentsFromCommand != null)
        {
          ProcedureResult procedureResult = this.Execute(query, str, p, argumentsFromCommand);
          if (procedureResult != ProcedureResult.WrongArguments)
            return procedureResult;
        }
      }
      this.EventCommandNotExecuted();
      return ProcedureResult.Success;
    }

    private void EventCommandNotExecuted()
    {
      this.OperatorConsole.PrintTextLine("Я такое не умею", DialogConsoleColors.Сообщение);
    }

    private ProcedureResult ExecuteWithTerminal(string query)
    {
      ProcedureResult procedureResult = ProcedureResult.Success;
      try
      {
        PowerManager.ExecuteApplication("cmd.exe", "/K " + query);
      }
      catch (Exception ex)
      {
        this.PrintExceptionToConsole(ex);
        procedureResult = ProcedureResult.Error;
      }
      return procedureResult;
    }

    private string MakeNormalRegex(Procedure p)
    {
      string str;
      switch (RegexManager.determineRegexType(p.Regex))
      {
        case RegexType.NormalRegex:
          str = string.Copy(p.Regex);
          break;
        case RegexType.SimpleString:
          str = RegexManager.ConvertSimpleToRegex2(p.Regex);
          break;
        default:
          throw new Exception(string.Format("Invalid regex string: {0} in {1}", (object) p.Regex, (object) p.Title));
      }
      return str;
    }

    private ProcedureResult Execute(string command, string regex, Procedure p, ArgumentCollection args)
    {
      this.TryAssignPlaces(args);
      if (!RegexManager.IsAssemblyCodePath(p.Path))
        return this.RunShellExecute(p, args);
      return this.RunLocalAssembly(command, p, args);
    }

    private ProcedureResult RunLocalAssembly(string command, Procedure p, ArgumentCollection args)
    {
      ProcedureResult procedureResult;
      try
      {
        string[] names = RegexManager.ParseAssemblyCodePath(p.Path);
        procedureResult = p.invokeProcedure(command, names, this, args);
      }
      catch (Exception ex)
      {
        this.PrintExceptionToConsole(ex);
        procedureResult = ProcedureResult.WrongArguments;
      }
      return procedureResult;
    }

    private ProcedureResult RunShellExecute(Procedure p, ArgumentCollection args)
    {
      ProcedureResult procedureResult = ProcedureResult.Success;
      try
      {
        PowerManager.ExecuteApplication(RegexManager.ConvertApplicationCommandString(p.Path, args));
      }
      catch (Exception ex)
      {
        this.OperatorConsole.PrintExceptionMessage(ex);
        procedureResult = ProcedureResult.WrongArguments;
      }
      return procedureResult;
    }

    private void TryAssignPlaces(ArgumentCollection args)
    {
      foreach (FuncArgument funcArgument in args.Arguments)
      {
        string argumentValue = funcArgument.ArgumentValue;
        if (this.m_db.Places.ContainsPlace(argumentValue))
        {
          Place place = this.m_db.Places.GetPlace(argumentValue);
          funcArgument.ПодставитьМесто(place);
        }
      }
    }

    private void PrintExceptionToConsole(Exception e)
    {
      if (e.InnerException != null)
        this.OperatorConsole.PrintExceptionMessage(e.InnerException);
      else
        this.OperatorConsole.PrintExceptionMessage(e);
    }

    public void DbInsertPlace(Place p)
    {
      this.m_db.AddPlace(p);
    }

    public void DbInsertPlace(List<Place> places)
    {
      this.m_db.AddPlace(places);
    }

    public void DbRemovePlace(Place p)
    {
      this.m_db.RemovePlace(p);
    }

    public void DbInsertProcedure(Procedure p)
    {
      this.m_db.AddProcedure(p);
    }

    public void DbInsertProcedure(List<Procedure> procedures)
    {
      this.m_db.AddProcedure(procedures);
    }

    public void DbRemoveProcedure(Procedure p)
    {
      this.m_db.RemoveProcedure(p);
    }

    public List<Place> DbGetPlacesByTitle(string placeTitle)
    {
      return this.m_db.Places.getByTitle(placeTitle);
    }

    public List<Procedure> DbGetProceduresByTitle(string title)
    {
      return this.m_db.Procedures.getByTitle(title);
    }
  }
}
