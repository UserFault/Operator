// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Procedure
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace SpeakIfaceTest1
{
  public class Procedure : Item
  {
    private double m_ves;
    private string m_regex;

    public double Ves
    {
      get
      {
        return this.m_ves;
      }
      set
      {
        this.m_ves = value;
      }
    }

    public string Regex
    {
      get
      {
        return this.m_regex;
      }
      set
      {
        this.m_regex = value;
      }
    }

    public override string ToString()
    {
      return this.getSingleLineProperties();
    }

    public static string getAssemblyFilePath(string assemblyName)
    {
      return Path.ChangeExtension(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), assemblyName), ".dll");
    }

    public static MethodInfo getMethodInfo(string[] names)
    {
      Type type = Assembly.LoadFile(Procedure.getAssemblyFilePath(names[0])).GetType(string.Format("{0}.{1}", (object) names[0], (object) names[1]));
      if (type == null)
        throw new Exception(string.Format("Класс {0} не найден в сборке {1}", (object) names[1], (object) names[0]));
      MethodInfo method = type.GetMethod(names[2]);
      if (method == null)
        throw new Exception(string.Format("Процедура {0} не найдена в классе {1} сборки {2}", (object) names[2], (object) names[1], (object) names[0]));
      return method;
    }

    public static ImplementationState getStateOfImplement(MethodInfo mi)
    {
      ImplementationState implementationState = ImplementationState.NotRealized;
      try
      {
        object[] customAttributes = mi.GetCustomAttributes(typeof (ProcedureAttribute), false);
        if (customAttributes.Length > 0)
          implementationState = ((ProcedureAttribute) customAttributes[0]).ElementValue;
      }
      catch (Exception ex)
      {
      }
      return implementationState;
    }

    public ProcedureResult invokeProcedure(string command, string[] names, Engine engine, ArgumentCollection args)
    {
      MethodInfo methodInfo = Procedure.getMethodInfo(names);
      if (Procedure.getStateOfImplement(methodInfo) == ImplementationState.NotRealized)
        throw new Exception(string.Format("Процедура {0}.{1}.{2} не готова для исполнения.", (object) names[0], (object) names[1], (object) names[2]));
      return (ProcedureResult) methodInfo.Invoke((object) null, new List<object>()
      {
        (object) engine,
        (object) command,
        (object) args
      }.ToArray());
    }

    public static int SortByVes(Procedure p1, Procedure p2)
    {
      if (p1 == null)
        return p2 == null ? 0 : -1;
      if (p2 == null || p1.m_ves > p2.m_ves)
        return 1;
      return p1.m_ves < p2.m_ves ? -1 : 0;
    }

    public override string getSingleLineProperties()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.m_id.ToString());
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_title);
      stringBuilder.Append(";ves=");
      stringBuilder.Append(this.m_ves.ToString());
      stringBuilder.Append(";path=");
      stringBuilder.Append(this.m_path);
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_descr);
      if (stringBuilder.Length > 80)
        stringBuilder.Length = 80;
      return stringBuilder.ToString();
    }

    public static bool IsValidVesFormat(string str, CultureInfo cultureInfo)
    {
      bool flag = false;
      try
      {
        double num = double.Parse(str, (IFormatProvider) cultureInfo);
        if (num > 0.0 && num < 1.0)
          flag = true;
      }
      catch
      {
        flag = false;
      }
      return flag;
    }
  }
}
