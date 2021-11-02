// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.OleDbAdapter
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace SpeakIfaceTest1
{
  public class OleDbAdapter
  {
    private string m_conString;
    private OleDbConnection m_connection;
    private OleDbCommand m_cmdGetAllPlaces;
    private OleDbCommand m_cmdAddPlace;
    private OleDbCommand m_cmdGetAllProcedures;
    private OleDbCommand m_cmdAddProcedure;

    public OleDbAdapter()
    {
      this.m_connection = (OleDbConnection) null;
      this.m_cmdGetAllPlaces = (OleDbCommand) null;
    }

    public void Open(string connectionString)
    {
      this.m_conString = string.Copy(connectionString);
      this.Open();
    }

    public virtual void Open()
    {
      this.m_connection = new OleDbConnection(this.m_conString);
      this.m_connection.Open();
    }

    public virtual void Close()
    {
      if (this.m_connection == null || this.m_connection.State == ConnectionState.Closed)
        return;
      this.m_connection.Close();
      this.m_connection = (OleDbConnection) null;
      this.m_cmdGetAllPlaces = (OleDbCommand) null;
      this.m_cmdAddPlace = (OleDbCommand) null;
      this.m_cmdGetAllProcedures = (OleDbCommand) null;
      this.m_cmdAddProcedure = (OleDbCommand) null;
    }

    public static string CreateConnectionString(string dbfile)
    {
      return new OleDbConnectionStringBuilder()
      {
        Provider = "Microsoft.Jet.OLEDB.4.0",
        DataSource = dbfile
      }.ConnectionString;
    }

    public List<Place> GetAllPlaces()
    {
      OleDbCommand oleDbCommand = this.m_cmdGetAllPlaces;
      if (oleDbCommand == null)
      {
        oleDbCommand = new OleDbCommand("SELECT * FROM `places`", this.m_connection);
        this.m_cmdGetAllPlaces = oleDbCommand;
      }
      List<Place> list = new List<Place>();
      OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
      if (oleDbDataReader.HasRows)
      {
        while (oleDbDataReader.Read())
        {
          Place place = new Place();
          place.TableId = oleDbDataReader.GetInt32(0);
          place.Title = oleDbDataReader.GetString(1);
          place.PlaceTypeExpression = oleDbDataReader.GetString(2);
          place.Path = oleDbDataReader.GetString(3);
          place.Description = oleDbDataReader.GetString(4);
          place.Synonim = oleDbDataReader.GetString(5);
          place.ParseEntityTypeString();
          list.Add(place);
        }
      }
      oleDbDataReader.Close();
      return list;
    }

    public void AddPlace(Place p)
    {
      OleDbCommand oleDbCommand = this.m_cmdAddPlace;
      if (oleDbCommand == null)
      {
        oleDbCommand = new OleDbCommand("INSERT INTO `places`(`title`, `type`, `path`, `descr`, `syno`) VALUES (?,?,?,?,?);", this.m_connection);
        oleDbCommand.Parameters.Add(new OleDbParameter("@a0", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a1", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a2", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a3", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a4", OleDbType.VarWChar));
        this.m_cmdAddPlace = oleDbCommand;
      }
      oleDbCommand.Parameters[0].Value = (object) p.Title;
      oleDbCommand.Parameters[1].Value = (object) p.PlaceTypeExpression;
      oleDbCommand.Parameters[2].Value = (object) p.Path;
      oleDbCommand.Parameters[3].Value = (object) p.Description;
      oleDbCommand.Parameters[4].Value = (object) p.Synonim;
      oleDbCommand.ExecuteNonQuery();
    }

    public List<Procedure> GetAllProcedures()
    {
      OleDbCommand oleDbCommand = this.m_cmdGetAllProcedures;
      if (oleDbCommand == null)
      {
        oleDbCommand = new OleDbCommand("SELECT * FROM `routines`", this.m_connection);
        this.m_cmdGetAllProcedures = oleDbCommand;
      }
      List<Procedure> list = new List<Procedure>();
      OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
      if (oleDbDataReader.HasRows)
      {
        while (oleDbDataReader.Read())
        {
          Procedure procedure = new Procedure();
          procedure.TableId = oleDbDataReader.GetInt32(0);
          procedure.Title = oleDbDataReader.GetString(1);
          procedure.Ves = oleDbDataReader.GetDouble(2);
          procedure.Path = oleDbDataReader.GetString(3);
          procedure.Regex = oleDbDataReader.GetString(4);
          procedure.Description = oleDbDataReader.GetString(5);
          list.Add(procedure);
        }
      }
      oleDbDataReader.Close();
      return list;
    }

    public void AddProcedure(Procedure p)
    {
      OleDbCommand oleDbCommand = this.m_cmdAddProcedure;
      if (oleDbCommand == null)
      {
        oleDbCommand = new OleDbCommand("INSERT INTO `routines`(`title`, `ves`, `path`, `regex`, `descr`) VALUES (?,?,?,?,?);", this.m_connection);
        oleDbCommand.Parameters.Add(new OleDbParameter("@a0", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a1", OleDbType.Double));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a2", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a3", OleDbType.VarWChar));
        oleDbCommand.Parameters.Add(new OleDbParameter("@a4", OleDbType.VarWChar));
        this.m_cmdAddProcedure = oleDbCommand;
      }
      oleDbCommand.Parameters[0].Value = (object) p.Title;
      oleDbCommand.Parameters[1].Value = (object) p.Ves;
      oleDbCommand.Parameters[2].Value = (object) p.Path;
      oleDbCommand.Parameters[3].Value = (object) p.Regex;
      oleDbCommand.Parameters[4].Value = (object) p.Description;
      oleDbCommand.ExecuteNonQuery();
    }
  }
}
