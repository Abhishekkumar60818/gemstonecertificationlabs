using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for vehiclepageData
/// </summary>
public class vehiclepageData
{
    private int _Id;
    private string _Name;
    private string _address;
    private int _User_Id;
    private int _Status;
    private string _Image;
    public vehiclepageData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public vehiclepageData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM vehiclecurrentdb WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _address = ds.Tables[0].Rows[0]["address"].ToString();
                _User_Id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _Image = ds.Tables[0].Rows[0]["image"].ToString();

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public vehiclepageData(string name)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", name));
        using (DataSet ds = connect.GetDataset("SELECT * FROM vehiclecurrentdb WHERE name=@name", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _address = ds.Tables[0].Rows[0]["address"].ToString();
                _User_Id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _Image = ds.Tables[0].Rows[0]["image"].ToString();

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
        param.Add(new MySqlParameter("@address", _address));
        param.Add(new MySqlParameter("@user_id", _User_Id));
        param.Add(new MySqlParameter("@status", _Status));
        param.Add(new MySqlParameter("@image", _Image));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO vehiclecurrentdb(name,address,user_id,status,image) VALUES(@name,@address,@user_id,@status,@image)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@address", _address));
        param.Add(new MySqlParameter("@user_id", _User_Id));
        param.Add(new MySqlParameter("@status", _Status));
        param.Add(new MySqlParameter("@image", _Image));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE vehiclecurrentdb SET name=@name,address=@address,user_id=@user_id,status=@status,image=@image WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getMedicineType(String query)
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
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string address
    {
        get { return _address; }
        set { _address = value; }
    }

    public int User_Id
    {
        get { return _User_Id; }
        set { _User_Id = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}