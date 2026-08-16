using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicineOrdersData
/// </summary>
public class MedicineOrdersData
{
    private int _Id;
    private int _UserId;
    private int _Address;
    private string _OrderTotal;
    private string _DeliveryCharge;
    private string _PlacedDate;
    private string _PlacedTime;
    private string _OrderDate;
    private string _Percription;
    private int _IsPlaced;
    private string _PaymentOption;
    private string _Status;
    private int _IsConfirm;
    private string _UserType;

    
	public MedicineOrdersData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      public MedicineOrdersData(int Id,string str)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicineorders WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _PlacedDate = ds.Tables[0].Rows[0]["placedate"].ToString();
                _PlacedTime = ds.Tables[0].Rows[0]["placetime"].ToString();
                _OrderDate = ds.Tables[0].Rows[0]["orderdate"].ToString();
                _Percription = ds.Tables[0].Rows[0]["percription"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();
                _IsConfirm =int.Parse( ds.Tables[0].Rows[0]["isconfirm"].ToString());
                _UserType = ds.Tables[0].Rows[0]["usertype"].ToString();


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }



      public MedicineOrdersData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicineorders WHERE userid=@int_Id and isconfirm=0", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                 _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _PlacedDate = ds.Tables[0].Rows[0]["placedate"].ToString();
                _PlacedTime = ds.Tables[0].Rows[0]["placetime"].ToString();
                _OrderDate = ds.Tables[0].Rows[0]["orderdate"].ToString();
                _Percription = ds.Tables[0].Rows[0]["percription"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();
                _IsConfirm =int.Parse( ds.Tables[0].Rows[0]["isconfirm"].ToString());
                _UserType = ds.Tables[0].Rows[0]["usertype"].ToString();
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
        
        param.Add(new MySqlParameter("@userid", _UserId));
        param.Add(new MySqlParameter("@address", _Address));
        param.Add(new MySqlParameter("@ordertotal", _OrderTotal));
        param.Add(new MySqlParameter("@delivery", _DeliveryCharge));
        param.Add(new MySqlParameter("@placedate", _PlacedDate));
        param.Add(new MySqlParameter("@placetime", _PlacedTime));
        param.Add(new MySqlParameter("@orderdate", _OrderDate));
        param.Add(new MySqlParameter("@percription", _Percription));
        param.Add(new MySqlParameter("@paymentoption", _PaymentOption));
        param.Add(new MySqlParameter("@status", _Status));
        param.Add(new MySqlParameter("@usertype", _UserType));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO medicineorders(userid,address,ordertotal,delivery,placedate,placetime,orderdate,percription,paymentoption,status,usertype) VALUES(@userid,@address,@ordertotal,@delivery,@placedate,@placetime,@orderdate,@percription,@paymentoption,@status,@usertype)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
       


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE medicineorders SET isconfirm=1 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateStatus(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@status", _Status));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE medicineorders SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Delivered(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE medicineorders SET IsPlaced=1 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getOrderHeader(String query)
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
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public int Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
   
    public string OrderTotal
    {
        get { return _OrderTotal; }
        set { _OrderTotal = value; }
    }
    public string DeliveryCharge
    {
        get { return _DeliveryCharge; }
        set { _DeliveryCharge = value; }
    }
    public string PlacedDate
    {
        get { return _PlacedDate; }
        set { _PlacedDate = value; }
    }
    public string PlacedTime
    {
        get { return _PlacedTime; }
        set { _PlacedTime = value; }
    }
    public string OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }
 
    public string Percription
    {
        get { return _Percription; }
        set { _Percription = value; }
    }
    public int IsPlaced
    {
        get { return _IsPlaced; }
        set { _IsPlaced = value; }
    }
    public string PaymentOption
    {
        get { return _PaymentOption; }
        set { _PaymentOption = value; }
    }
    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public int IsConfirm
    {
        get { return _IsConfirm; }
        set { _IsConfirm = value; }
    }
    public string UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}