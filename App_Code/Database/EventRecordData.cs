using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventRecordData
/// </summary>
public class EventRecordData
{
    

    public EventRecordData()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public EventRecordData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM eventrecord WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Name =ds.Tables[0].Rows[0]["Name"].ToString();
                Start_Date = ds.Tables[0].Rows[0]["Start_Date"].ToString();
                End_Date = ds.Tables[0].Rows[0]["End_Date"].ToString();
                Venue = ds.Tables[0].Rows[0]["Venue"].ToString();
                Awards = ds.Tables[0].Rows[0]["Awards"].ToString();
                pdf_Record = ds.Tables[0].Rows[0]["pdf_Record"].ToString();
                

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public EventRecordData(string subcate)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@subcate", subcate));
        using (DataSet ds = connect.GetDataset("SELECT * FROM eventrecord WHERE eventrecordName=@subcate", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Name = ds.Tables[0].Rows[0]["Name"].ToString();
                Start_Date = ds.Tables[0].Rows[0]["Start_Date"].ToString();
                End_Date = ds.Tables[0].Rows[0]["End_Date"].ToString();
                Venue = ds.Tables[0].Rows[0]["Venue"].ToString();
                Awards = ds.Tables[0].Rows[0]["Awards"].ToString();
                pdf_Record = ds.Tables[0].Rows[0]["pdf_Record"].ToString();

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public EventRecordData(string Name, string nousse)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@Name", Name));
        using (DataSet ds = connect.GetDataset("SELECT * FROM eventrecord WHERE id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Name = ds.Tables[0].Rows[0]["Name"].ToString();
                Start_Date = ds.Tables[0].Rows[0]["Start_Date"].ToString();
                End_Date = ds.Tables[0].Rows[0]["End_Date"].ToString();
                Venue = ds.Tables[0].Rows[0]["Venue"].ToString();
                Awards = ds.Tables[0].Rows[0]["Awards"].ToString();
                pdf_Record = ds.Tables[0].Rows[0]["pdf_Record"].ToString();

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@Name", Name));
        param.Add(new MySqlParameter("@Start_Date", Start_Date));
        param.Add(new MySqlParameter("@End_Date", End_Date));
        param.Add(new MySqlParameter("@Venue", Venue));
        param.Add(new MySqlParameter("@Awards", Awards));
        param.Add(new MySqlParameter("@pdf_Record", pdf_Record));
        

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO eventrecord(id,Name,Start_Date,End_Date,Venue,Awards,pdf_Record) VALUES(@id,@Name,@Start_Date,@End_Date,@Venue,@Awards,@pdf_Record)", param);
        connect.Dispose();
        connect = null;

    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@Name", Name));
        param.Add(new MySqlParameter("@Start_Date", Start_Date));
        param.Add(new MySqlParameter("@End_Date", End_Date));
        param.Add(new MySqlParameter("@Venue", Venue));
        param.Add(new MySqlParameter("@Awards", Awards));
        param.Add(new MySqlParameter("@pdf_Record", pdf_Record));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE eventrecord SET categoryid=@catid,eventrecordName=@eventrecord,description=@description,image=@image,pagetitle=@pagetitle,metakey=@metakey,metadescription=@metadescription WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet geteventrecord(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement(query);
        connect.Dispose();
        connect = null;
    }


    public int id{ get; set; }
    public string Name { get; set; }
    public string Start_Date { get; set; }
    public string End_Date { get; set; }
    public string Venue { get; set; }
    public string Awards { get; set; }
    public string pdf_Record { get; set; }

    public bool HasValue
    {
        get;
        set;
    }
}