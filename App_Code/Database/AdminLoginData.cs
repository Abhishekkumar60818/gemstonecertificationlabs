using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminLoginData
/// </summary>
public class AdminLoginData
{
    private string _Username;
    private string _Password;
    private int _Id;
    public AdminLoginData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AdminLoginData(string username, string password)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", username));
        param.Add(new MySqlParameter("@pass", password));
        using (DataSet ds = connect.GetDataset("select * from admin where email=@email and apassword=@pass", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Username = ds.Tables[0].Rows[0]["email"].ToString();
                _Password = ds.Tables[0].Rows[0]["apassword"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@pass", _Password));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE admin SET apassword=@pass", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@username", _Username));
        param.Add(new MySqlParameter("@pass", _Password));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO admin(email,apassword) VALUES(@email,@pass)", param);
        connect.Dispose();
        connect = null;
    }
    public int Id { get { return _Id; } set { _Id = value; } }
    public string Username { get { return _Username; } set { _Username = value; } }
    public string Password { get { return _Password; } set { _Password = value; } }
    public bool HasValue { get; set; }
}