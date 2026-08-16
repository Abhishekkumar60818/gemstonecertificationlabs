using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for calendrData
/// </summary>
public class calendrData
{
   private int _Id;
    private string _Name;
    private string _address;
    private int _User_Id;
    private int _Status;
    private string _Image;
	public calendrData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      public calendrData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM calender_db WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                vehicleID = int.Parse(ds.Tables[0].Rows[0]["vehicleID"].ToString());
                date = ds.Tables[0].Rows[0]["date"].ToString();
                canter = ds.Tables[0].Rows[0]["canter"].ToString();
                gypsy = ds.Tables[0].Rows[0]["gypsy"].ToString();
                


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }


    public calendrData(int Id,string vehicleid)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM calender_db WHERE vehical_Id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                vehicleID = int.Parse(ds.Tables[0].Rows[0]["vehical_Id"].ToString());
                date = ds.Tables[0].Rows[0]["date"].ToString();
                canter = ds.Tables[0].Rows[0]["canter"].ToString();
                gypsy = ds.Tables[0].Rows[0]["gypsy"].ToString();



            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public calendrData(string date)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@date", date));
        using (DataSet ds = connect.GetDataset("SELECT * FROM calender_db WHERE date=@date", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                date = ds.Tables[0].Rows[0]["date"].ToString();
                canter = ds.Tables[0].Rows[0]["canter"].ToString();
                gypsy = ds.Tables[0].Rows[0]["gypsy"].ToString();

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

        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@canter", canter));
        param.Add(new MySqlParameter("@gypsy", gypsy));
        

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO calender_db(date,canter,gypsy) VALUES(@date,@canter,@gypsy)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@date", date));
        param.Add(new MySqlParameter("@canter", canter));
        param.Add(new MySqlParameter("@gypsy", gypsy));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE calender_db SET date=@date,canter=@canter,gypsy=@gypsy WHERE id=@id", param);
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
        get;set;
    }
    public string date { get; set; }
    public string canter { get; set; }
    public string gypsy { get; set; }
    public int vehicleID { get; set; }


    public bool HasValue
    {
        get;
        set;
    }
}