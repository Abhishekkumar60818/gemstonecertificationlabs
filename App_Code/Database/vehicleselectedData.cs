using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for vehicleselectedData
/// </summary>
public class vehicleselectedData
{
    

    

    public vehicleselectedData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public vehicleselectedData(int Id,int idvehicle)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        param.Add(new MySqlParameter("@idvehicle", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM vehicaleselecteddetails WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                catid = int.Parse(ds.Tables[0].Rows[0]["catId"].ToString());
                subcatid = int.Parse(ds.Tables[0].Rows[0]["SubcatId"].ToString());
                productid = int.Parse(ds.Tables[0].Rows[0]["productId"].ToString());
                product = ds.Tables[0].Rows[0]["product"].ToString();
              
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public vehicleselectedData(string image)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM vehicaleselecteddetails WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                catid = int.Parse(ds.Tables[0].Rows[0]["catId"].ToString());
                subcatid = int.Parse(ds.Tables[0].Rows[0]["SubcatId"].ToString());
                productid = int.Parse(ds.Tables[0].Rows[0]["productId"].ToString());
                product = ds.Tables[0].Rows[0]["product"].ToString();
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
        param.Add(new MySqlParameter("@catId", catid));
        param.Add(new MySqlParameter("@SubcatId", subcatid));
        param.Add(new MySqlParameter("@productId", productid));
        param.Add(new MySqlParameter("@product", product)); 
            param.Add(new MySqlParameter("@seat", seat)); 
            param.Add(new MySqlParameter("@rent", Rent));



        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO vehicaleselecteddetails(catId,SubcatId,productId,product,seat,rent)  VALUES(@catId,@SubcatId,@productId,@product,@seat,@rent)", param);
        connect.Dispose();
        connect = null;
    }
   
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@catId", catid));
        param.Add(new MySqlParameter("@SubcatId", subcatid));
        param.Add(new MySqlParameter("@productId", productid));
        param.Add(new MySqlParameter("@product", product));
        param.Add(new MySqlParameter("@seat", seat));
        param.Add(new MySqlParameter("@rent", Rent));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE vehicaleselecteddetails SET catId=@catId,SubcatId=@SubcatId,productId=@productId,product=@product,seat=@seat,rent=@rent WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    

    public DataSet getProduct(String query)
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
    public int catid { get; set; }
    public int subcatid { get; set; }
    public int productid { get; set; }
    public string product { get; set; }
    public string seat { get; set; }
    public string Rent { get; set; }

    public bool HasValue
    {
        get;
        set;
    }
}