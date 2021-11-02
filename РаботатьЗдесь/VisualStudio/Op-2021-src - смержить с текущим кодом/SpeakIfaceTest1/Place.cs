// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Place
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;
using System.Text;

namespace SpeakIfaceTest1
{
  public class Place : Item
  {
    private string m_placetype;
    private string m_synonim;
    private EntityTypesCollection m_entityTypes;

    public string PlaceTypeExpression
    {
      get
      {
        return this.m_placetype;
      }
      set
      {
        this.m_placetype = value;
      }
    }

    public string Synonim
    {
      get
      {
        return this.m_synonim;
      }
      set
      {
        this.m_synonim = value;
      }
    }

    public EntityTypesCollection EntityTypes
    {
      get
      {
        return this.m_entityTypes;
      }
      set
      {
        this.m_entityTypes = value;
      }
    }

    public Place()
    {
      this.m_entityTypes = new EntityTypesCollection();
    }

    public Place(Place p)
    {
      this.m_descr = string.Copy(p.m_descr);
      this.m_id = p.m_id;
      this.m_path = string.Copy(p.m_path);
      this.m_placetype = string.Copy(p.m_placetype);
      this.m_synonim = string.Copy(p.m_synonim);
      this.m_title = string.Copy(p.m_title);
      this.m_entityTypes = (EntityTypesCollection) null;
      this.ParseEntityTypeString();
    }

    public override string ToString()
    {
      return this.getSingleLineProperties();
    }

    public void ParseEntityTypeString()
    {
      this.m_entityTypes = new EntityTypesCollection();
      this.m_entityTypes.ParseExpression(this.m_placetype);
    }

    public List<string> GetSynonims()
    {
      string[] strArray = this.m_synonim.Trim().Split(new char[2]
      {
        ',',
        ';'
      }, StringSplitOptions.RemoveEmptyEntries);
      List<string> lis = new List<string>();
      foreach (string str in strArray)
      {
        string sss = str.Trim();
        if (sss.Length > 0 && this.listNotContains(lis, sss))
          lis.Add(sss);
      }
      return lis;
    }

    private bool listNotContains(List<string> lis, string sss)
    {
      foreach (string a in lis)
      {
        if (string.Equals(a, sss, StringComparison.OrdinalIgnoreCase))
          return false;
      }
      return true;
    }

    public override string getSingleLineProperties()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.m_id.ToString());
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_title);
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_placetype);
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_path);
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_descr);
      if (stringBuilder.Length > 80)
        stringBuilder.Length = 80;
      return stringBuilder.ToString();
    }

    public static bool checkSynonimString(string syno)
    {
      return true;
    }
  }
}
