﻿// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.ProcedureAttribute
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;

namespace SpeakIfaceTest1
{
  public class ProcedureAttribute : Attribute
  {
    private ImplementationState elem;

    public ImplementationState ElementValue
    {
      get
      {
        return this.elem;
      }
      set
      {
        this.elem = value;
      }
    }

    public ProcedureAttribute(ImplementationState ie)
    {
      this.elem = ie;
    }
  }
}
