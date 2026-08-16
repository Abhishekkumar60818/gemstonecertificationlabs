using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactData
/// </summary>
public class ContactData
{

    private int _Id;
    private string _Name;
    private string _Mobile;
    private string _Email;
    private string _Subject;
    private string _Message;
    public ContactData()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void Save()
    {  
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@subject", _Subject));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@msg", _Message));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO contact(name,email,subject,mobile,msg) VALUES (@name,@email,@subject,@mobile,@msg)", param);
        connect.Dispose();
        connect = null;
    }


    public ContactData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", _Id));
        using (DataSet ds = connect.GetDataset("select * from contact where id=@id"))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Subject = ds.Tables[0].Rows[0]["subject"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Message = ds.Tables[0].Rows[0]["msg"].ToString();
            }
        }
    }


    public DataSet getUsers(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        DataSet ds = connect.GetDataset(query);
        return ds;
    }




    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
   
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }
    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }

    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }

    public bool HasValue
    {
        get;
        set;
    }
}