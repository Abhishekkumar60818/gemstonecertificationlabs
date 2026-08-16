using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NewsData
/// </summary>
public class QualityData 
{

    private int _Id;
    private string _productName;
    private string _productDetail;
    public QualityData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public QualityData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from quality where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                image = ds.Tables[0].Rows[0]["image"].ToString();
                productName = ds.Tables[0].Rows[0]["productName"].ToString();
                productDetail = ds.Tables[0].Rows[0]["productDetail"].ToString();
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
        param.Add(new MySqlParameter("@image", image));
        param.Add(new MySqlParameter("@productName", productName));
        param.Add(new MySqlParameter("@productDetail", productDetail));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO quality(image,productName,productDetail) VALUES(@image,@productName,@productDetail)", param);
        connect.Dispose();
        connect = null;
    }

    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@image", image));
        param.Add(new MySqlParameter("@productName", productName));
        param.Add(new MySqlParameter("@productDetail", productDetail));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE quality SET image=@image,productName=@productName,productDetail=@productDetail where id=@id", param);
        connect.Dispose();
        connect = null;
    }


    public DataSet getQualityDetail(string query)
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
    public string image { get; set; }
    public string productName { get; set; }
    public string productDetail { get; set; }
    public bool HasValue { get; set; }

}