// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.EntityType
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;

namespace SpeakIfaceTest1
{
  public class EntityType
  {
    private Dictionary<string, EntityType> m_AbstractionSuperClasses;
    private Dictionary<string, EntityType> m_AggregationSubClasses;
    private string m_Title;

    public string Title
    {
      get
      {
        return this.m_Title;
      }
      set
      {
        this.m_Title = value;
      }
    }

    internal Dictionary<string, EntityType> AbstractionSuperClasses
    {
      get
      {
        return this.m_AbstractionSuperClasses;
      }
      set
      {
        this.m_AbstractionSuperClasses = value;
      }
    }

    internal Dictionary<string, EntityType> AggregationSubClasses
    {
      get
      {
        return this.m_AggregationSubClasses;
      }
      set
      {
        this.m_AggregationSubClasses = value;
      }
    }

    public EntityType(string title)
    {
      this.m_Title = title;
      this.m_AbstractionSuperClasses = new Dictionary<string, EntityType>();
      this.m_AggregationSubClasses = new Dictionary<string, EntityType>();
    }

    public EntityType()
    {
      this.m_Title = string.Empty;
      this.m_AbstractionSuperClasses = new Dictionary<string, EntityType>();
      this.m_AggregationSubClasses = new Dictionary<string, EntityType>();
    }

    public override string ToString()
    {
      return string.Format("{0};{1};{2}", (object) this.m_Title, (object) this.m_AbstractionSuperClasses.Count, (object) this.AggregationSubClasses.Count);
    }

    public EntityType ContainsType(string nameOfType)
    {
      if (this.m_AbstractionSuperClasses.ContainsKey(nameOfType))
        return this.m_AbstractionSuperClasses[nameOfType];
      foreach (KeyValuePair<string, EntityType> keyValuePair in this.m_AbstractionSuperClasses)
      {
        EntityType entityType = keyValuePair.Value.ContainsType(nameOfType);
        if (entityType != null)
          return entityType;
      }
      if (this.m_AggregationSubClasses.ContainsKey(nameOfType))
        return this.m_AggregationSubClasses[nameOfType];
      foreach (KeyValuePair<string, EntityType> keyValuePair in this.m_AggregationSubClasses)
      {
        EntityType entityType = keyValuePair.Value.ContainsType(nameOfType);
        if (entityType != null)
          return entityType;
      }
      return (EntityType) null;
    }

    public void ParseExpression(string expression)
    {
      string[] strArray1 = expression.Trim().Split(new char[2]
      {
        '<',
        '>'
      }, StringSplitOptions.RemoveEmptyEntries);
      this.ParseClassTitle(strArray1[0]);
      if (strArray1.Length == 1)
        return;
      if (strArray1.Length > 2)
        throw new Exception(string.Format("Неправильное выражение: {0}", (object) expression));
      if (strArray1.Length != 2)
        return;
      string[] strArray2 = strArray1[1].Split(new char[1]
      {
        ','
      }, StringSplitOptions.RemoveEmptyEntries);
      if (strArray1.Length == 0)
        throw new Exception(string.Format("Неправильная запись агрегированных субклассов: {0}", (object) expression));
      foreach (string expression1 in strArray2)
      {
        EntityType entityType = new EntityType();
        entityType.ParseClassTitle(expression1);
        this.m_AggregationSubClasses.Add(entityType.Title, entityType);
      }
    }

    public void ParseClassTitle(string expression)
    {
      string str = expression.Trim();
      if (str.Contains("::"))
      {
        string[] strArray = str.Split(new string[1]
        {
          "::"
        }, StringSplitOptions.RemoveEmptyEntries);
        this.m_Title = strArray[1].Trim();
        EntityType entityType = new EntityType(strArray[0].Trim());
        this.m_AbstractionSuperClasses.Add(entityType.Title, entityType);
      }
      else
        this.m_Title = str;
    }
  }
}
