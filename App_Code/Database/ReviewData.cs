using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReviewData
/// </summary>
public class ReviewData
{
   
    private int _Id;
    private string _image;
    private string _Customer_review;
    private string _CustomerName;
    public ReviewData()
    {
    }


    public ReviewData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM review_table WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _image = ds.Tables[0].Rows[0]["image"].ToString();
                _CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                _Customer_review = ds.Tables[0].Rows[0]["Customer_review"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public ReviewData(string Customer_review)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cate", Customer_review));
        using (DataSet ds = connect.GetDataset("SELECT * FROM review_table WHERE image=@cate", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _image = ds.Tables[0].Rows[0]["image "].ToString();
                _CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                _Customer_review = ds.Tables[0].Rows[0]["Customer_review"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
               
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public ReviewData(string image, string nouse)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM review_table WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _image = ds.Tables[0].Rows[0]["image "].ToString();
                _CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                _Customer_review = ds.Tables[0].Rows[0]["Customer_review"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
               
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

        param.Add(new MySqlParameter("@image", _image));
        param.Add(new MySqlParameter("@CustomerName", _CustomerName));
        param.Add(new MySqlParameter("@Customer_review", _Customer_review));
        // param.Add(new MySqlParameter("@date", _Date));
       // param.Add(new MySqlParameter("@image", _Image));
      

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO review_table(image,CustomerName,Customer_review) VALUES(@image,@CustomerName,@Customer_review)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@image", _image));
        param.Add(new MySqlParameter("@Customer_review", _Customer_review));
        // param.Add(new MySqlParameter("@date", _Date));
     

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE review_table SET image=@image,Customer_review=@Customer_review WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getreview(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;

    }
    //public DataSet getFullCategory()
    //{
    //    string conn = System.Configuration.ConfigurationManager.ConnectionStrings["mySQLconn"].ConnectionString;
    //    MySqlConnection cnn = new MySqlConnection(conn);
    //    MySqlDataAdapter cmd1 = new MySqlDataAdapter("select * from review", cnn);

    //    //Create and fill the DataSet.
    //    DataSet ds = new DataSet();
    //    cmd1.Fill(ds, "review");

    //    //Create a second DataAdapter for the Titles table.
    //    MySqlDataAdapter cmd2 = new MySqlDataAdapter("select * from review", cnn);
    //    cmd2.Fill(ds, "review");

    //    //Create the relation bewtween the Category and Sub-Category tables.
    //    ds.Relations.Add("myrelation",
    //    ds.Tables["review"].Columns["id"],
    //   // ds.Tables["review"].Columns["categoryid"]);

    //    return ds;
    //    cnn.Close();
    //}
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


    public string image
    {
        get { return _image; }
        set { _image = value; }
    }
    public string Customer_review
    {
        get { return _Customer_review; }
        set { _Customer_review = value; }
    }
    public string CustomerName
    {
        get { return _CustomerName; }
        set { _CustomerName = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}



