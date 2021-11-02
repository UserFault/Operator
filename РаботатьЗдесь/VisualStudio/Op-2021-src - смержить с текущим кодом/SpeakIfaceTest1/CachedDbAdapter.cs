// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.CachedDbAdapter
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System.Collections.Generic;

namespace SpeakIfaceTest1
{
  public class CachedDbAdapter : SqliteDbAdapter
  {
    private ProcedureCollection m_procedures;
    private PlacesCollection m_places;

    public ProcedureCollection Procedures
    {
      get
      {
        return this.m_procedures;
      }
      set
      {
        this.m_procedures = value;
      }
    }

    public PlacesCollection Places
    {
      get
      {
        return this.m_places;
      }
      set
      {
        this.m_places = value;
      }
    }

    public CachedDbAdapter()
    {
      this.m_places = new PlacesCollection();
      this.m_procedures = new ProcedureCollection();
    }

    public override void Open()
    {
      this.m_places.Clear();
      this.m_procedures.Clear();
      base.Open();
      this.reloadProcedures();
      this.reloadPlaces();
    }

    public override void Close()
    {
      this.m_places.Clear();
      this.m_procedures.Clear();
      base.Close();
    }

    public new void AddPlace(Place p)
    {
      base.AddPlace(p);
      this.reloadPlaces();
    }

    public void AddPlace(List<Place> places)
    {
      foreach (Place p in places)
        base.AddPlace(p);
      this.reloadPlaces();
    }

    public void RemovePlace(Place p)
    {
      this.RemovePlace(p.TableId);
      this.reloadPlaces();
    }

    public new void AddProcedure(Procedure p)
    {
      base.AddProcedure(p);
      this.reloadProcedures();
    }

    public void AddProcedure(List<Procedure> procedures)
    {
      foreach (Procedure p in procedures)
        base.AddProcedure(p);
      this.reloadProcedures();
    }

    public void RemoveProcedure(Procedure p)
    {
      this.RemoveProcedure(p.TableId);
      this.reloadProcedures();
    }

    private void reloadPlaces()
    {
      this.m_places.Clear();
      this.m_places.FillFromDb(this.GetAllPlaces());
    }

    private void reloadProcedures()
    {
      this.m_procedures.Clear();
      this.m_procedures.FillFromDb(this.GetAllProcedures());
    }
  }
}
