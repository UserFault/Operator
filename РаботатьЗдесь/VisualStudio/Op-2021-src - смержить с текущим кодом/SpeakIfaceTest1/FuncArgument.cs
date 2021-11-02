// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.FuncArgument
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

namespace SpeakIfaceTest1
{
  public class FuncArgument
  {
    private string m_argtype;
    private string m_argname;
    private string m_argvalue;
    private string m_argQueryValue;
    private Place m_Place;

    public string ArgumentType
    {
      get
      {
        return this.m_argtype;
      }
      set
      {
        this.m_argtype = value;
      }
    }

    public string ArgumentName
    {
      get
      {
        return this.m_argname;
      }
      set
      {
        this.m_argname = value;
      }
    }

    public string ArgumentValue
    {
      get
      {
        return this.m_argvalue;
      }
      set
      {
        this.m_argvalue = value;
      }
    }

    public string ArgumentQueryValue
    {
      get
      {
        return this.m_argQueryValue;
      }
      set
      {
        this.m_argQueryValue = value;
      }
    }

    public Place AssociatedPlace
    {
      get
      {
        return this.m_Place;
      }
    }

    public bool АвтоподстановкаМеста
    {
      get
      {
        return this.m_Place != null;
      }
    }

    public FuncArgument(string name, string type, string value, string queryValue)
    {
      this.m_argname = name;
      this.m_argtype = type;
      this.m_argvalue = value;
      this.m_argQueryValue = queryValue;
      this.m_Place = (Place) null;
    }

    public FuncArgument()
    {
      this.m_argvalue = string.Empty;
      this.m_argtype = string.Empty;
      this.m_argname = string.Empty;
      this.m_argQueryValue = string.Empty;
      this.m_Place = (Place) null;
    }

    internal void ПодставитьМесто(Place p)
    {
      this.m_argtype = string.Copy(p.PlaceTypeExpression);
      this.m_argvalue = string.Copy(p.Path);
      this.m_Place = new Place(p);
    }
  }
}
