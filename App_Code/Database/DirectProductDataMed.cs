using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DirectProductDataMed
/// </summary>
public class DirectProductDataMed
{
    private int _Id;
    private int _ProductId;
    private double _Price;
    private double _NewPrice;
    private int _Quantity;
    private string _SessionId;
    private string _Dose;
    private int _UserId;
    private string _UserType;
	public DirectProductDataMed()
	{
		//
		// TODO: Add constructor logic here
		//
	}

         public DirectProductDataMed(int id, string sessionid,string dose,string email)
    {
        string query = "";
          if(email!="")
          {
              UserData udata=new UserData(email);
              query = "SELECT * FROM direct_product_med WHERE product_id=@int_Id and sessionid=@sessionid and dose=@dose and userid=" + udata.Id;
          }
          else{
              query = "SELECT * FROM direct_product_med WHERE product_id=@int_Id and sessionid=@sessionid and dose=@dose and userid=0";
          }
         
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", id));
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@dose", dose));
        using (DataSet ds = connect.GetDataset(query, param))
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
                _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                //_Quantity = _Quantity + 1;
               // Update(_Id);

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

      public DirectProductDataMed(int id, string sessionid, string dose, string email, string noUse)
      {
          string query = "";
          if (email != "")
          {
              UserData udata = new UserData(email);
              query = "SELECT * FROM direct_product_med WHERE product_id=@int_Id and sessionid=@sessionid and dose=@dose and userid=" + udata.Id;
          }
          else
          {
              query = "SELECT * FROM direct_product_med WHERE product_id=@int_Id and sessionid=@sessionid and dose=@dose and userid=0";
          }

          Connection connect = new Connection();
          List<MySqlParameter> param = new List<MySqlParameter>();
          param.Add(new MySqlParameter("@int_Id", id));
          param.Add(new MySqlParameter("@sessionid", sessionid));
          param.Add(new MySqlParameter("@dose", dose));
          using (DataSet ds = connect.GetDataset(query, param))
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
                  _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                  _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                 // _Quantity = _Quantity + 1;
                 // Update(_Id);

              }
              else
              {
                  HasValue = false;
              }
          }
          connect.Dispose();
          connect = null;
      }
    public DirectProductDataMed(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM direct_product_med WHERE id=@int_Id", param))
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
                _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
              


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public DirectProductDataMed(string sessionid, int userid)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@userid", userid));
        using (DataSet ds = connect.GetDataset("SELECT * FROM direct_product_med WHERE sessionid=@sessionid or userid=@userid ", param))
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
                _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
              


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
        param.Add(new MySqlParameter("@sessionid", _SessionId));
        param.Add(new MySqlParameter("@userid", _UserId));
        param.Add(new MySqlParameter("@usertype", _UserType));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO direct_product_med(product_id,dose,price,new_price,quantity,sessionid,userid,user_type) VALUES(@productid,@dose,@price,@newprice,@quantity,@sessionid,@userid,@usertype)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@quantity", _Quantity));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE direct_product_med SET quantity=@quantity WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int pid,string sessionid,int uid)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@pid", pid));
        param.Add(new MySqlParameter("@uid", uid));
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@quantity", _Quantity));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE direct_product_med SET quantity=@quantity WHERE product_id=@pid and sessionid=@sessionid and userid=@uid", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(string sessionid)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@userid", _UserId));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE direct_product_med SET userid=@userid WHERE sessionid=@sessionid and userid=0", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateOldSession(string oldSessionid)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@oldsessionid", oldSessionid));
        param.Add(new MySqlParameter("@newSessionId", _SessionId));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE direct_product_med SET sessionid=@newSessionId WHERE sessionid=@oldsessionid and userid=0", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateByUser(int userid)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", _SessionId));
        param.Add(new MySqlParameter("@userid", userid));
        param.Add(new MySqlParameter("@user_type", _UserType));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE direct_product_med SET sessionid=@sessionid,user_type=@user_type WHERE userid=@userid", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateUserPrice(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@new_price", _NewPrice));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE direct_product_med SET new_price=@new_price WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCart(String query)
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
    public string SessionId
    {
        get { return _SessionId; }
        set { _SessionId = value; }
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