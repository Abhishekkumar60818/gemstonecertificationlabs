using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicineWishlist
/// </summary>
public class MedicineWishlist
{
      private int _Id;
    private int _ProductId;
    private double _Price;
    private double _NewPrice; 
    private int _Quantity;
    private string _Dose;
    private int _UserId;
    private string _UserType;
	public MedicineWishlist()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public MedicineWishlist(int id, int userid, string dose)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", id));
        param.Add(new MySqlParameter("@userid", userid));
        param.Add(new MySqlParameter("@dose", dose));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicine_wishlist WHERE product_id=@int_Id and userid=@userid and dose=@dose", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                _Dose = ds.Tables[0].Rows[0]["dose"].ToString();
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["new_price"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _UserType = ds.Tables[0].Rows[0]["user_type"].ToString();
                _Quantity = _Quantity + 1;
                Update(_Id);

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }


    public MedicineWishlist(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicine_wishlist WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                _Dose = ds.Tables[0].Rows[0]["dose"].ToString();
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["new_price"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _UserType = ds.Tables[0].Rows[0]["user_type"].ToString();
              


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public MedicineWishlist(string sessionid, int userid)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@userid", userid));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicine_wishlist WHERE sessionid=@sessionid or userid=@userid ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                _Dose = ds.Tables[0].Rows[0]["dose"].ToString();
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["new_price"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _UserType = ds.Tables[0].Rows[0]["user_type"].ToString();
              


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

        param.Add(new MySqlParameter("@productid", _ProductId));
        param.Add(new MySqlParameter("@dose", _Dose));
        param.Add(new MySqlParameter("@price", _Price));
        param.Add(new MySqlParameter("@newprice", _NewPrice));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@userid", _UserId));
        param.Add(new MySqlParameter("@usertype", _UserType));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO medicine_wishlist(product_id,dose,price,new_price,quantity,userid,user_type) VALUES(@productid,@dose,@price,@newprice,@quantity,@userid,@usertype)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@quantity", _Quantity));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE medicine_wishlist SET quantity=@quantity WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }


    public DataSet getWishList(String query)
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


    public int ProductId
    {
        get { return _ProductId; }
        set { _ProductId = value; }
    }
    public string Dose
    {
        get { return _Dose; }
        set { _Dose = value; }
    }
    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
    }
    public double NewPrice
    {
        get { return _NewPrice; }
        set { _NewPrice = value; }
    }
  

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
   
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
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