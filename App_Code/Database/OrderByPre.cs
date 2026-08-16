using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderByPre
/// </summary>
public class OrderByPre
{

    private int _Id;
    private string _Name;
    private string _Mobile;
    private string _Email;
    private string _Address;   
    private string _Area;
    private string _Pincode;
    private string _Image;
   
    
   
    

    public OrderByPre()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();

        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@address", _Address));
        param.Add(new MySqlParameter("@area", _Area));
        param.Add(new MySqlParameter("@pincode", _Pincode));
        param.Add(new MySqlParameter("@image", _Image));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO orderbypre(name,mobile,email,full address,pin,area,image) VALUES(@name,@mobile,@email,@address,@pincode,@area,@image)", param);
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
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    public string Pincode
    {
        get { return _Pincode; }
        set { _Pincode = value; }
    }
    public string Area
    {
        get { return _Area; }
        set { _Area = value; }
    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }

}