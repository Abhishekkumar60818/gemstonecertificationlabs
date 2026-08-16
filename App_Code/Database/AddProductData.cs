using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddProductData
/// </summary>
public class AddProductData
{
    private int _Id;
    private int _CatId;
    private int _SubCategoryId;
    private string _ProductName;
    //private string _MRPPrice;
    private string _Quantity;
    private string _ProductDiscription;
    private string _Image1;
    private string _Image2;

    public AddProductData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AddProductData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from product where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Catid = int.Parse(ds.Tables[0].Rows[0]["catid"].ToString());
                SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["subcategoryId"].ToString());
                ProductName = ds.Tables[0].Rows[0]["productName"].ToString();
                Quantity = ds.Tables[0].Rows[0]["quantity"].ToString();
                ProductDiscription = ds.Tables[0].Rows[0]["productDiscription"].ToString();
                Image1 = ds.Tables[0].Rows[0]["image1"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    //public SubCData(int Id)
    //{
    //    Connection connect = new Connection();
    //    List<MySqlParameter> param = new List<MySqlParameter>();
    //    param.Add(new MySqlParameter("@int_Id", Id));
    //    using (DataSet ds = connect.GetDataset("SELECT * FROM subcategory WHERE id=@int_Id", param))
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HasValue = true;
    //            _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
    //            _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
    //            _SubCategory = ds.Tables[0].Rows[0]["subCategoryName"].ToString();
    //            _Description = ds.Tables[0].Rows[0]["description"].ToString();
    //            _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
    //            _Image = ds.Tables[0].Rows[0]["image"].ToString();
    //            _PageTitle = ds.Tables[0].Rows[0]["pagetitle"].ToString();
    //            _MetaKey = ds.Tables[0].Rows[0]["metakey"].ToString();
    //            _MetaDescription = ds.Tables[0].Rows[0]["metadescription"].ToString();

    //        }
    //        else
    //        {
    //            HasValue = false;
    //        }
    //    }
    //    connect.Dispose();
    //    connect = null;
    //}
    public AddProductData(string category)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@category", category));
        using (DataSet ds = connect.GetDataset("SELECT * FROM category WHERE category=@category ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public void SubcategoryId(string subcategory)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@subcategoryId", subcategory));
        using (DataSet ds = connect.GetDataset("SELECT * FROM product WHERE subcategoryId=@subcategoryId ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["subcategoryId"].ToString());
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
        param.Add(new MySqlParameter("@catid", _CatId));
        param.Add(new MySqlParameter("@subcategoryId", _SubCategoryId));
        param.Add(new MySqlParameter("@productName", _ProductName));
        //param.Add(new MySqlParameter("@mrpPrice", _MRPPrice));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@productDiscription", _ProductDiscription));
        param.Add(new MySqlParameter("@image1", _Image1));
        //param.Add(new MySqlParameter("@image2", _Image2));
        Connection connect = new Connection();
        //connect.ExecStatement("INSERT INTO subcategory(categoryid,subCategoryName,description,image,pagetitle,metakey,metadescription) VALUES(@catid,@subcategory,@description,@image,@pagetitle,@metakey,@metadescription)", param);
        connect.ExecStatement("INSERT INTO product(catid,subcategoryId,productName,quantity,productDiscription,image1) VALUES(@catid,@subcategoryId,@productName,@quantity,@productDiscription,@image1)", param);
        connect.Dispose();
        connect = null;

    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@catid", _CatId));
        param.Add(new MySqlParameter("@subcategoryId", _SubCategoryId));
        param.Add(new MySqlParameter("@productName", _ProductName));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@productDiscription", _ProductDiscription));
        param.Add(new MySqlParameter("@image1", _Image1));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE product SET catid=@catid,subcategoryId=@subcategoryId,productName=@productName,quantity=@quantity,productDiscription=@productDiscription,image1=@image1 WHERE id=" + id, param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getProductDetail(String query)
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
    public int Catid
    {
        get { return _CatId; }
        set { _CatId = value; }
    }

    public int SubCategoryId
    {
        get { return _SubCategoryId; }
        set { _SubCategoryId = value; }
    }


    public string ProductName
    {
        get { return _ProductName; }
        set { _ProductName = value; }
    }
    //public string MRPPrice
    //{
    //    get { return _MRPPrice; }
    //    set { _MRPPrice = value; }
    //}

    public string Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string ProductDiscription
    {
        get { return _ProductDiscription; }
        set { _ProductDiscription = value; }
    }
    public string Image1
    {
        get { return _Image1; }
        set { _Image1 = value; }
    }
    public string Image2
    {
        get { return _Image2; }
        set { _Image2 = value; }
    }


    public bool HasValue
    {
        get;
        set;
    }
}