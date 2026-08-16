using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityData
/// </summary>
public class CityData
{
    private int _Id;
    private string _state;
    private string _Name;
    public CityData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CityData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM city WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _state = ds.Tables[0].Rows[0]["state"].ToString();
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
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
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@state", _state));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO city(name,state)  VALUES(@name,@state)", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCity(String query)
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
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string StateId
    {
        get { return _state; }
        set { _state = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}