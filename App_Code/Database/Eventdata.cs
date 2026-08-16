using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Eventdata
/// </summary>
public class Eventdata
{
    private int _Id;
    private string _name;
    private string _Mothername;
    private string _fathername;
    private string _dob;
    private string _Age;
    private string _Blood_group;
    private string _mobile_no;
    private string _Address;
    private string _Couch_Name;
    private string _club_name;
    private string _current_gurding;
    private string _Email;
    private string _Aadhar;
    private string _Image;
    private string _Document;



    public Eventdata()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Eventdata(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM currenteventreg WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _name = ds.Tables[0].Rows[0]["name"].ToString();
                //_fathername = ds.Tables[0].Rows[0]["mothername"].ToString();
                //_mothername = ds.Tables[0].Rows[0]["fathername"].ToString();
                //_dob = ds.Tables[0].Rows[0]["dob"].ToString();
                //_Blood_group = ds.Tables[0].Rows[0]["Blood_group"].ToString();
                //_mobile_no = ds.Tables[0].Rows[0]["mobile_no"].ToString();
                //_Address = ds.Tables[0].Rows[0]["Image"].ToString();
                //_Couch_Name = ds.Tables[0].Rows[0]["Couch_Name"].ToString();
                //_current_gurding = ds.Tables[0].Rows[0]["current_gurding"].ToString();
                //_Email = ds.Tables[0].Rows[0]["email"].ToString();
                //_Aadhar = ds.Tables[0].Rows[0]["Aadhar"].ToString();
                //_Image = ds.Tables[0].Rows[0]["metadescription"].ToString();
                //_club_name = ds.Tables[0].Rows[0]["club_name"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    //public Player_Registrationdata(string category)
    //{
    //    Connection connect = new Connection();
    //    List<MySqlParameter> param = new List<MySqlParameter>();
    //    param.Add(new MySqlParameter("@cate", category));
    //    using (DataSet ds = connect.GetDataset("SELECT * FROM p_registration WHERE categoryName=@cate", param))
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HasValue = true;
    //            _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
    //            _Name = ds.Tables[0].Rows[0]["name"].ToString();
    //            _fName = ds.Tables[0].Rows[0]["mothername"].ToString();
    //            _MName = ds.Tables[0].Rows[0]["fathername"].ToString();
    //            _dob = ds.Tables[0].Rows[0]["dob"].ToString();
    //            _Blood = ds.Tables[0].Rows[0]["Blood_group"].ToString();
    //            _mobile = ds.Tables[0].Rows[0]["mobile_no"].ToString();
    //            _Address = ds.Tables[0].Rows[0]["Image"].ToString();
    //            _couch_name = ds.Tables[0].Rows[0]["Couch_Name"].ToString();
    //            _currentguarding = ds.Tables[0].Rows[0]["current_gurding"].ToString();
    //            _email = ds.Tables[0].Rows[0]["email"].ToString();
    //            _Aadhar = ds.Tables[0].Rows[0]["Aadhar"].ToString();
    //            _img = ds.Tables[0].Rows[0]["metadescription"].ToString();
    //            _clubName = ds.Tables[0].Rows[0]["club_name"].ToString();
    //        }
    //        else
    //        {
    //            HasValue = false;
    //        }
    //    }
    //    connect.Dispose();
    //    connect = null;
    //}
    //public Player_Registrationdata(string image, string nouse)
    //{
    //    Connection connect = new Connection();
    //    List<MySqlParameter> param = new List<MySqlParameter>();
    //    param.Add(new MySqlParameter("@image", image));
    //    using (DataSet ds = connect.GetDataset("SELECT * FROM category WHERE image=@image", param))
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HasValue = true;
    //            _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
    //            _Name = ds.Tables[0].Rows[0]["name"].ToString();
    //            _fName = ds.Tables[0].Rows[0]["mothername"].ToString();
    //            _MName = ds.Tables[0].Rows[0]["fathername"].ToString();
    //            _dob = ds.Tables[0].Rows[0]["dob"].ToString();
    //            _Blood = ds.Tables[0].Rows[0]["Blood_group"].ToString();
    //            _mobile = ds.Tables[0].Rows[0]["mobile_no"].ToString();
    //            _Address = ds.Tables[0].Rows[0]["Image"].ToString();
    //            _couch_name = ds.Tables[0].Rows[0]["Couch_Name"].ToString();
    //            _currentguarding = ds.Tables[0].Rows[0]["current_gurding"].ToString();
    //            _email = ds.Tables[0].Rows[0]["email"].ToString();
    //            _Aadhar = ds.Tables[0].Rows[0]["Aadhar"].ToString();
    //            _img = ds.Tables[0].Rows[0]["metadescription"].ToString();
    //            _clubName = ds.Tables[0].Rows[0]["club_name"].ToString();
    //        }
    //        else
    //        {
    //            HasValue = false;
    //        }
    //    }
    //    connect.Dispose();
    //    connect = null;
    //}
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();

        param.Add(new MySqlParameter("@name", _name));
        param.Add(new MySqlParameter("@mothername", _Mothername));
        param.Add(new MySqlParameter("@fathername", _fathername));
        param.Add(new MySqlParameter("@dob", _dob));
        param.Add(new MySqlParameter("@Age", _Age));
        param.Add(new MySqlParameter("@Blood_group", _Blood_group));
        param.Add(new MySqlParameter("@mobile_no", _mobile_no));
        param.Add(new MySqlParameter("@Address", _Address));
        param.Add(new MySqlParameter("@Couch_Name", _Couch_Name));
        param.Add(new MySqlParameter("@club_name", _club_name));
        param.Add(new MySqlParameter("@current_gurding", _current_gurding));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@Aadhar", _Aadhar));
        param.Add(new MySqlParameter("@Document", _Document));
        param.Add(new MySqlParameter("@Image", _Image));


        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO currenteventreg(Name,Mothername,fathername,dob,Age,mobile_no,Blood_group,Couch_Name,club_name,current_gurding,Aadhar,Document,Image,Address,Email)VALUES(@name,@Mothername,@fathername,@dob,@Age,@mobile_no,@Blood_group,@Couch_Name,@club_name,@current_gurding,@Aadhar,@Document,@Image,@Address,@Email)", param);
        //("INSERT INTO p_registration(Name,MName,fName,dob,Blood,mobile,Address,couch_name,clubName,currentguarding,email,Aadhar,img) VALUES(@name,@mothername,@fathername,@dob,@mobile_no,@email,@Blood_group,@Couch_Name,@club_name,@current_gurding,@Aadhar,@image)", param);


        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", _name));
        param.Add(new MySqlParameter("@mothername", _Mothername));
        param.Add(new MySqlParameter("@fathername", _fathername));
        param.Add(new MySqlParameter("@dob", _dob));
        param.Add(new MySqlParameter("@Age", _Age));
        param.Add(new MySqlParameter("@Blood_group", _Blood_group));
        param.Add(new MySqlParameter("@mobile_no", _mobile_no));
        param.Add(new MySqlParameter("@Address", _Address));
        param.Add(new MySqlParameter("@Couch_Name", _Couch_Name));
        param.Add(new MySqlParameter("@club_name", _club_name));
        param.Add(new MySqlParameter("@current_gurding", _current_gurding));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@Aadhar", _Aadhar));
        param.Add(new MySqlParameter("@Document", _Document));
        param.Add(new MySqlParameter("@Image", _Image));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE currenteventreg SET name=@name,mothername=@mothername,fathername=@fathername,dob=@dob,Age=@Age,mobile_no=@mobile_no,email=@email,Blood_group=@Blood_group,Couch_Name=@Couch_Name,club_name=@club_name,current_gurding=@current_gurding,Aadhar=@Aadhar,Document=@Document,Image=@Image WHERE id=@id", param);
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

    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement(query);
        connect.Dispose();
        connect = null;
    }
    public int id
    {
        get { return _Id; }
        set { _Id = value; }
    }


    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string fathername
    {
        get { return _fathername; }
        set { _fathername = value; }
    }
    public string Mothername
    {
        get { return _Mothername; }
        set { _Mothername = value; }
    }

    public string dob
    {
        get { return _dob; }
        set { _dob = value; }
    }

    public string Age
    {
        get { return _Age; }
        set { _Age = value; }
    }
    public string Blood_group
    {
        get { return _Blood_group; }
        set { _Blood_group = value; }
    }
    public string mobile_no
    {
        get { return _mobile_no; }
        set { _mobile_no = value; }
    }
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public string Couch_Name
    {
        get { return _Couch_Name; }
        set { _Couch_Name = value; }
    }
    public string club_name
    {
        get { return _club_name; }
        set { _club_name = value; }
    }
    public string current_gurding
    {
        get { return _current_gurding; }
        set { _current_gurding = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Aadhar
    {
        get { return _Aadhar; }
        set { _Aadhar = value; }
    }
    public string Document
    {
        get { return _Document; }
        set { _Document = value; }
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