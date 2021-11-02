// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.EntityTypesCollection
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;

namespace SpeakIfaceTest1
{
  public class EntityTypesCollection
  {
    private Dictionary<string, EntityType> m_EntityTypes;

    public Dictionary<string, EntityType> EntityTypes
    {
      get
      {
        return this.m_EntityTypes;
      }
      set
      {
        this.m_EntityTypes = value;
      }
    }

    public EntityTypesCollection()
    {
      this.m_EntityTypes = new Dictionary<string, EntityType>();
    }

    public EntityType ContainsType(string nameOfType)
    {
      if (this.m_EntityTypes.ContainsKey(nameOfType))
        return this.m_EntityTypes[nameOfType];
      foreach (KeyValuePair<string, EntityType> keyValuePair in this.m_EntityTypes)
      {
        EntityType entityType = keyValuePair.Value.ContainsType(nameOfType);
        if (entityType != null)
          return entityType;
      }
      return (EntityType) null;
    }

    public void ParseExpression(string expression)
    {
      string str = expression.Trim();
      char[] separator = new char[1]
      {
        ';'
      };
      int num = 1;
      foreach (string expression1 in str.Split(separator, (StringSplitOptions) num))
      {
        EntityType entityType = new EntityType();
        entityType.ParseExpression(expression1);
        this.m_EntityTypes.Add(entityType.Title, entityType);
      }
    }
  }
}
