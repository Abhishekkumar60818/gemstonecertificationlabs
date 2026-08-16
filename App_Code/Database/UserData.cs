using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserData
/// </summary>
public class UserData
{
    private int _Id;
    private string _Name;
    private string _Shopname;
    private string _Tinnumber;
    private string _Mobile;
    private string _Email;
    private string _Password;
    private string _State;
    private string _City;
    private string _Address;
    private string _Image;
    private string _UserType;
    private int _Status;
    private string _OtherInfo;
    private int _Referenceid;
    private int _Approved;
    private string _Category_Not_Approved;
    public UserData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public UserData(string email)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@mobile", email));

        using (DataSet ds = connect.GetDataset("SELECT * FROM users WHERE (email=@email or mobile=@email)", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Shopname = ds.Tables[0].Rows[0]["shopname"].ToString();
                _Tinnumber = ds.Tables[0].Rows[0]["tinnumber"].ToString();
                 Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Password = ds.Tables[0].Rows[0]["epassword"].ToString();
                _State = ds.Tables[0].Rows[0]["state"].ToString();
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _Address = ds.Tables[0].Rows[0]["address"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _UserType = ds.Tables[0].Rows[0]["usertype"].ToString();
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _OtherInfo = ds.Tables[0].Rows[0]["otherinfo"].ToString();
                _Referenceid = int.Parse(ds.Tables[0].Rows[0]["referenceid"].ToString());
                _Approved = int.Parse(ds.Tables[0].Rows[0]["approved"].ToString());
                _Category_Not_Approved = ds.Tables[0].Rows[0]["category_to_approve"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public UserData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM users WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Shopname = ds.Tables[0].Rows[0]["shopname"].ToString();
                _Tinnumber = ds.Tables[0].Rows[0]["tinnumber"].ToString();
                Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Password = ds.Tables[0].Rows[0]["epassword"].ToString();
                _State = ds.Tables[0].Rows[0]["state"].ToString();
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _Address = ds.Tables[0].Rows[0]["address"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _UserType = ds.Tables[0].Rows[0]["usertype"].ToString();
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _OtherInfo = ds.Tables[0].Rows[0]["otherinfo"].ToString();
                _Referenceid = int.Parse(ds.Tables[0].Rows[0]["referenceid"].ToString());
                _Approved = int.Parse(ds.Tables[0].Rows[0]["approved"].ToString());
                _Category_Not_Approved = ds.Tables[0].Rows[0]["category_to_approve"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public UserData(string email, string pass, string role)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@epassword", pass));
        param.Add(new MySqlParameter("@role", role));
        using (DataSet ds = connect.GetDataset("select * from users where (email=@email or mobile=@email ) and epassword=@epassword and usertype=@role", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Shopname = ds.Tables[0].Rows[0]["shopname"].ToString();
                _Tinnumber = ds.Tables[0].Rows[0]["tinnumber"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Password = ds.Tables[0].Rows[0]["epassword"].ToString();
                _State = ds.Tables[0].Rows[0]["state"].ToString();
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _Address = ds.Tables[0].Rows[0]["address"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _UserType = ds.Tables[0].Rows[0]["usertype"].ToString();
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _OtherInfo = ds.Tables[0].Rows[0]["otherinfo"].ToString();
                _Referenceid = int.Parse(ds.Tables[0].Rows[0]["referenceid"].ToString());
                _Approved = int.Parse(ds.Tables[0].Rows[0]["approved"].ToString());
                _Category_Not_Approved = ds.Tables[0].Rows[0]["category_to_approve"].ToString();
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
        param.Add(new MySqlParameter("@shopname", _Shopname));
        param.Add(new MySqlParameter("@tinnumber", _Tinnumber));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@epassword", _Password));
        param.Add(new MySqlParameter("@state", _State));
        param.Add(new MySqlParameter("@city", _City));
        param.Add(new MySqlParameter("@address", _Address));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@usertype", _UserType));
        param.Add(new MySqlParameter("@status", _Status));
        param.Add(new MySqlParameter("@otherinfo", _OtherInfo));
        param.Add(new MySqlParameter("@referenceid", _Referenceid));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO users(name,shopname,tinnumber,mobile,email,epassword,state,city,address,image,usertype,status,otherinfo,referenceid) VALUES(@name,@shopname,@tinnumber,@mobile,@email,@epassword,@state,@city,@address,@image,@usertype,@status,@otherinfo,@referenceid)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveNormalUser()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@cpassword", _Password));
        param.Add(new MySqlParameter("@usertype", _UserType));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO customer(name,email,mobile,cpassword,usertype) VALUES(@name,@email,@mobile,@cpassword,@usertype)", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@shopname", _Shopname));
        param.Add(new MySqlParameter("@tinnumber", _Tinnumber));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@epassword", _Password));
        param.Add(new MySqlParameter("@state", _State));
        param.Add(new MySqlParameter("@city", _City));
        param.Add(new MySqlParameter("@address", _Address));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@usertype", _UserType));
        param.Add(new MySqlParameter("@status", _Status));
        param.Add(new MySqlParameter("@otherinfo", _OtherInfo));
        param.Add(new MySqlParameter("@referenceid", _Referenceid));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE users SET name=@name,shopname=@shopname,tinnumber=@tinnumber,mobile=@mobile,email=@email,epassword=@epassword,state=@state,city=@city,address=@address,image=@image,usertype=@usertype,status=@status,otherinfo=@otherinfo,referenceid=@referenceid WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateStatus(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@status", _Status));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE users SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateApproved(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@approved", _Approved));
        param.Add(new MySqlParameter("@category", _Category_Not_Approved));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE users SET approved=@approved,category_to_approve=@category WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdatePoints(int id)
    {
        //List<MySqlParameter> param = new List<MySqlParameter>();
        //param.Add(new MySqlParameter("@id", id));
        //param.Add(new MySqlParameter("@points", _Points));
        //Connection connect = new Connection();
        //connect.ExecStatement("UPDATE customer SET points=@points WHERE id=@id", param);
        //connect.Dispose();
        //connect = null;
    }

    public void ChangePassword(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@pass", _Password));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE users SET epassword=@pass WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public DataSet getUsers(String query)
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
    public string ShopName
    {
        get { return _Shopname; }
        set { _Shopname = value; }
    }
    public string TinNumber
    {
        get { return _Tinnumber; }
        set { _Tinnumber = value; }
    }
    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public string State
    {
        get { return _State; }
        set { _State = value; }
    }
    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public string UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public string OtherInfo
    {
        get { return _OtherInfo; }
        set { _OtherInfo = value; }
    }
    public int ReferenceId
    {
        get { return _Referenceid; }
        set { _Referenceid = value; }
    }
    public string CategoryNotApproved
    {
        get { return _Category_Not_Approved; }
        set { _Category_Not_Approved = value; }
    }
    public int Approved
    {
        get { return _Approved; }
        set { _Approved = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}