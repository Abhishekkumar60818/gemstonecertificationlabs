using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CurrentEvent_Session
/// </summary>
public class CurrentEvent_SessionData
{
    

    private int _id;
    private string _StartDate;
    private string _EndDate;
    public CurrentEvent_SessionData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public CurrentEvent_SessionData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM currentevent_sessions order by id desc limit 1", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                _id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _StartDate = ds.Tables[0].Rows[0]["StartDate"].ToString();
                _EndDate = ds.Tables[0].Rows[0]["EndDate"].ToString();
                Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
            }
            else
            {
                //HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    //public Eventdata(string category)
    //{
    //    Connection connect = new Connection();
    //    List<MySqlParameter> param = new List<MySqlParameter>();
    //    param.Add(new MySqlParameter("@cate", category));
    //    using (DataSet ds = connect.GetDataset("SELECT * FROM currentevent_sessions WHERE categoryName=@cate", param))
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
    //public Eventdata(string image, string nouse)
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

        param.Add(new MySqlParameter("@StartDate", _StartDate));
        param.Add(new MySqlParameter("@EndDate", _EndDate));
      


        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO currentevent_sessions(StartDate,EndDate)VALUES(@StartDate,@EndDate)", param);
        //("INSERT INTO currentevent_sessions(Name,MName,fName,dob,Blood,mobile,Address,couch_name,clubName,currentguarding,email,Aadhar,img) VALUES(@name,@mothername,@fathername,@dob,@mobile_no,@email,@Blood_group,@Couch_Name,@club_name,@current_gurding,@Aadhar,@image)", param);


        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@StartDate", _StartDate));
        param.Add(new MySqlParameter("@EndDate", _EndDate));
      

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE currentevent_sessions SET StartDate=@StartDate,EndDate=@EndDate WHERE id=@id", param);
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
        get { return _id; }
        set { _id = value; }
    }

    public int Status
    {
        get; set;
    }
    public string StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }
    public string EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }

}