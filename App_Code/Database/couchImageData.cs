using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for couchImageData
/// </summary>
public class couchImageData
{
    private int _Id;
    
    
    public couchImageData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   
    public couchImageData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM couchimage WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                couchimage = ds.Tables[0].Rows[0]["CouchImage"].ToString();
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
        param.Add(new MySqlParameter("@CRegid", CRegid));
        param.Add(new MySqlParameter("@CouchImage", couchimage));





        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO couchimage(CouchImage,CRegid)VALUES(@CouchImage,@CRegid) ", param);
        //("INSERT INTO p_registration(Name,MName,fName,dob,Blood,mobile,Address,couch_name,clubName,currentguarding,email,Aadhar,img) VALUES(@name,@mothername,@fathername,@dob,@mobile_no,@email,@Blood_group,@Couch_Name,@club_name,@current_gurding,@Aadhar,@image)", param);


        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@CouchImage", couchimage));
        param.Add(new MySqlParameter("@CRegid", CRegid));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE playerimage SET imageName=@imageName,PRegid=@PRegid WHERE id=@id", param);
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
    public int CRegid
    {
        get;
        set;
    }

    public string couchimage
    {
        get;
        set;
    }


    public bool HasValue
    {
        get;
        set;
    }
}