using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Player_Registrationdata
/// </summary>
public class Player_Registrationdata
{

   



    public Player_Registrationdata()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Player_Registrationdata(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM p_registration WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                name = ds.Tables[0].Rows[0]["name"].ToString();
                Mobil_No = ds.Tables[0].Rows[0]["Mobil_No"].ToString();
                Email = ds.Tables[0].Rows[0]["Email"].ToString();
                Date = ds.Tables[0].Rows[0]["Date"].ToString();
                sazoncheck = ds.Tables[0].Rows[0]["sazoncheck"].ToString();
                sazoncheck1 = ds.Tables[0].Rows[0]["sazoncheck1"].ToString();
                sazoncheck2 = ds.Tables[0].Rows[0]["sazoncheck2"].ToString();
                sazoncheck3 = ds.Tables[0].Rows[0]["sazoncheck3"].ToString();
                sazoncheck4 = ds.Tables[0].Rows[0]["sazoncheck4"].ToString();
                sazoncheck5 = ds.Tables[0].Rows[0]["sazoncheck5"].ToString();
                noofPerson = ds.Tables[0].Rows[0]["noofPerson"].ToString();
               
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

        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@Mobil_No", Mobil_No));
        param.Add(new MySqlParameter("@Email", Email));
        param.Add(new MySqlParameter("@Date", Date));
        param.Add(new MySqlParameter("@sazoncheck", sazoncheck));
        //param.Add(new MySqlParameter("@sazoncheck1", sazoncheck1));
        param.Add(new MySqlParameter("@sazoncheck2", sazoncheck2));
        //param.Add(new MySqlParameter("@sazoncheck3", sazoncheck3));
        param.Add(new MySqlParameter("@sazoncheck4", sazoncheck4));
        //param.Add(new MySqlParameter("@sazoncheck5", sazoncheck5));
        param.Add(new MySqlParameter("@noofPerson", noofPerson));
       
        

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO formfill (name,Mobil_No,Email,Date,sazoncheck,sazoncheck2,sazoncheck4,noofPerson)VALUES(@name,@Mobil_No,@Email,@Date,@sazoncheck,@sazoncheck2,@sazoncheck4,@noofPerson)", param);
            


        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", name));
        param.Add(new MySqlParameter("@Mobil_No", Mobil_No));
        param.Add(new MySqlParameter("@Email", Email));
        param.Add(new MySqlParameter("@Date", Date));
        param.Add(new MySqlParameter("@sazoncheck", sazoncheck));
        param.Add(new MySqlParameter("@sazoncheck1", sazoncheck1));
        param.Add(new MySqlParameter("@sazoncheck2", sazoncheck2));
        param.Add(new MySqlParameter("@sazoncheck3", sazoncheck3));
        param.Add(new MySqlParameter("@sazoncheck4", sazoncheck4));
        param.Add(new MySqlParameter("@sazoncheck5", sazoncheck5));
        param.Add(new MySqlParameter("@noofPerson", noofPerson));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE formfill SET name=@name,Mobil_No=@Mobil_No,Email=@Email,Date=@Date,sazoncheck=@sazoncheck,sazoncheck1=@sazoncheck1,sazoncheck2=@sazoncheck2,sazoncheck3=@sazoncheck4,sazoncheck5=@sazoncheck5,noofPerson=@noofPerson WHERE id=@id", param);
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
    public int id { get; set; }
    public string name { get; set; }
    public string Mobil_No { get; set; }
    public string Email { get; set; }
    public string Date { get; set; }
    public string sazoncheck { get; set; }
    public string sazoncheck1 { get; set; }
    public string sazoncheck2 { get; set; }
    public string sazoncheck3 { get; set; }
    public string sazoncheck4 { get; set; }
    public string sazoncheck5 { get; set; }
    public string noofPerson { get; set; }


    public bool HasValue
    {
        get;
        set;
    }



}