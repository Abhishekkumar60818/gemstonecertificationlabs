using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderHeaderData
/// </summary>
public class OrderHeaderData
{
    private int _Id;
    private int _UserId;
    private int _Address;
    private string _OrderTotal;
    private string _OrderTime;
    private string _DeliveryCharge;
    private string _OrderPlaced;
    private string _OrderDate;
  
    private string _Instruction;
    private int _IsPlaced;
    private string _PaymentOption;
    private string _Status;
  
	public OrderHeaderData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public OrderHeaderData(int Id,string str)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderheader WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _OrderPlaced = ds.Tables[0].Rows[0]["placedate"].ToString();
                _OrderDate = ds.Tables[0].Rows[0]["orderdate"].ToString();
                _Instruction = ds.Tables[0].Rows[0]["instruction"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _OrderTime = ds.Tables[0].Rows[0]["ordertime"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
  


    public OrderHeaderData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderheader WHERE userid=@int_Id and isconfirm=0", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _OrderPlaced = ds.Tables[0].Rows[0]["placedate"].ToString();
                _OrderDate =ds.Tables[0].Rows[0]["orderdate"].ToString();
                _Instruction = ds.Tables[0].Rows[0]["instruction"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _OrderTime = ds.Tables[0].Rows[0]["ordertime"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public OrderHeaderData(int Id, string nuse1, string nuse2)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderheader WHERE id=@int_Id and isconfirm=0 ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _OrderPlaced = ds.Tables[0].Rows[0]["placedate"].ToString();
                _OrderDate = ds.Tables[0].Rows[0]["orderdate"].ToString();
                _Instruction = ds.Tables[0].Rows[0]["instruction"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _OrderTime = ds.Tables[0].Rows[0]["ordertime"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;


    }

    public void UpdateOrder(int id)
    {

        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@isconfirm", "1"));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET isconfirm=@isconfirm WHERE id=@id", param);
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
        param.Add(new MySqlParameter("@placedate", _OrderPlaced));
        param.Add(new MySqlParameter("@orderdate", _OrderDate));
        param.Add(new MySqlParameter("@instruction", _Instruction));
        param.Add(new MySqlParameter("@paymentoption", _PaymentOption));
        param.Add(new MySqlParameter("@orderTime", _OrderTime));
        param.Add(new MySqlParameter("@status", _Status));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO orderheader(userid,address,ordertotal,delivery,placedate,orderdate,instruction,paymentoption,ordertime,status) VALUES(@userid,@address,@ordertotal,@delivery,@placedate,@orderdate,@instruction,@paymentoption,@orderTime,@status)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));     


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET isconfirm=1 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateStatus(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@status", _Status));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Delivered(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET IsPlaced=1 WHERE id=@id", param);
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

    public string OrderTime
    {
        get { return _OrderTime; }
        set { _OrderTime = value; }
    }
    public string PlacedDate
    {
        get { return _OrderPlaced; }
        set { _OrderPlaced = value; }
    }
    public string OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }
 
    public string Instruction
    {
        get { return _Instruction; }
        set { _Instruction = value; }
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
    public bool HasValue
    {
        get;
        set;
    }
}