// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.ProcedureCollection
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;

namespace SpeakIfaceTest1
{
  public class ProcedureCollection
  {
    private List<Procedure> m_proclist;

    public List<Procedure> Procedures
    {
      get
      {
        return this.m_proclist;
      }
    }

    public ProcedureCollection()
    {
      this.m_proclist = new List<Procedure>();
    }

    internal void FillHardcodedProcedures()
    {
      Procedure procedure1 = new Procedure();
      procedure1.Title = "Тест эхо";
      procedure1.Regex = "тест эхо";
      procedure1.Path = "FirstProcedures.Procedures.CommandHandlerExample()";
      procedure1.Description = "Тестирование вывода на консоль из загружаемого обработчика команды";
      this.m_proclist.Add(procedure1);
      Procedure procedure2 = new Procedure();
      procedure2.Title = "Открыть место";
      procedure2.Regex = "открыть %место";
      procedure2.Path = "%место";
      procedure2.Description = "Тестирование работы с местами";
      procedure2.Ves = 0.9;
      this.m_proclist.Add(procedure2);
      Procedure procedure3 = new Procedure();
      procedure3.Title = "Найти в Инвентаре";
      procedure3.Regex = "найти в инвентаре %предмет";
      procedure3.Path = "inv:\\\\%предмет";
      procedure3.Description = "найти в инвентаре предмет";
      procedure3.Ves = 0.5;
      this.m_proclist.Add(procedure3);
      Procedure procedure4 = new Procedure();
      procedure4.Title = "Найти предмет";
      procedure4.Regex = "найти предмет %предмет";
      procedure4.Path = "inv:\\\\%предмет";
      procedure4.Description = "найти в инвентаре предмет";
      procedure4.Ves = 0.5;
      this.m_proclist.Add(procedure4);
      this.m_proclist.Sort(new Comparison<Procedure>(Procedure.SortByVes));
    }

    internal void FillFromDb(List<Procedure> list)
    {
      this.m_proclist.AddRange((IEnumerable<Procedure>) list);
      this.m_proclist.Sort(new Comparison<Procedure>(Procedure.SortByVes));
    }

    internal void Clear()
    {
      this.m_proclist.Clear();
    }

    internal List<Procedure> getByTitle(string title)
    {
      List<Procedure> list = new List<Procedure>();
      foreach (Procedure procedure in this.m_proclist)
      {
        if (string.Equals(procedure.Title, title, StringComparison.OrdinalIgnoreCase))
          list.Add(procedure);
      }
      return list;
    }
  }
}
