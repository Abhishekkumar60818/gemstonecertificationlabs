using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageData
/// </summary>
public class MessageData
{
    public MessageData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public MessageData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from message where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                about = ds.Tables[0].Rows[0]["about"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public void update()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@about", about));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE message SET about=@about", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@about", about));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO message(about) VALUES(@about)", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getDetails(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public int id { get; set; }
    public string about { get; set; }
    public bool HasValue { get; set; }
}