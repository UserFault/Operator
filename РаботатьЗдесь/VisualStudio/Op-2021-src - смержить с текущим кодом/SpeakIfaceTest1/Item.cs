// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Item
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System.Text;

namespace SpeakIfaceTest1
{
  public class Item
  {
    protected int m_id;
    protected string m_title;
    protected string m_descr;
    protected string m_path;

    public int TableId
    {
      get
      {
        return this.m_id;
      }
      set
      {
        this.m_id = value;
      }
    }

    public string Title
    {
      get
      {
        return this.m_title;
      }
      set
      {
        this.m_title = value;
      }
    }

    public string Description
    {
      get
      {
        return this.m_descr;
      }
      set
      {
        this.m_descr = value;
      }
    }

    public string Path
    {
      get
      {
        return this.m_path;
      }
      set
      {
        this.m_path = value;
      }
    }

    public override string ToString()
    {
      return this.getSingleLineProperties();
    }

    public virtual string getSingleLineProperties()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.m_id.ToString());
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_title);
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_path);
      stringBuilder.Append(";");
      stringBuilder.Append(this.m_descr);
      if (stringBuilder.Length > 80)
        stringBuilder.Length = 80;
      return stringBuilder.ToString();
    }

    public static int SortByTitle(Item x, Item y)
    {
      if (x == null)
        return y == null ? 0 : -1;
      if (y == null)
        return 1;
      return x.m_title.CompareTo(y.m_title);
    }
  }
}
