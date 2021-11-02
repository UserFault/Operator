// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.ArgumentCollection
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;

namespace SpeakIfaceTest1
{
  public class ArgumentCollection
  {
    private List<FuncArgument> m_args;

    public List<FuncArgument> Arguments
    {
      get
      {
        return this.m_args;
      }
      set
      {
        this.m_args = value;
      }
    }

    public ArgumentCollection()
    {
      this.m_args = new List<FuncArgument>();
    }

    public void Add(FuncArgument f)
    {
      this.m_args.Add(f);
    }

    public FuncArgument GetByName(string argname)
    {
      foreach (FuncArgument funcArgument in this.m_args)
      {
        if (string.Equals(argname, funcArgument.ArgumentName, StringComparison.OrdinalIgnoreCase))
          return funcArgument;
      }
      return (FuncArgument) null;
    }
  }
}
