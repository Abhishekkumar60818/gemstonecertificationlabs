using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GallerySubCategoryData
/// </summary>
public class GallerySubCategoryData
{
    private int _Id;
    private int _CatId;
    private string _SubCategory;
    private string _AlbumName;
    private string _AlbumImage;
    public GallerySubCategoryData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public GallerySubCategoryData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategory WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _SubCategory = ds.Tables[0].Rows[0]["subcategory"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    //public GallerySubCategoryData(string subcate)
    //{
    //    Connection connect = new Connection();
    //    List<MySqlParameter> param = new List<MySqlParameter>();
    //    param.Add(new MySqlParameter("@subcategory", subcate));
    //    using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategory WHERE subcategory=@subcategory", param))
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HasValue = true;
    //            _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
    //            _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
    //            _SubCategory = ds.Tables[0].Rows[0]["subcategory"].ToString();
    //        }
    //        else
    //        {
    //            HasValue = false;
    //        }
    //    }
    //    connect.Dispose();
    //    connect = null;
    //}
    //public GallerySubCategoryData(string image, string nousse)
    //{
    //    Connection connect = new Connection();
    //    List<MySqlParameter> param = new List<MySqlParameter>();
    //    param.Add(new MySqlParameter("@image", image));
    //    using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategory WHERE image=@image", param))
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HasValue = true;
    //            _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
    //            _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
    //            _SubCategory = ds.Tables[0].Rows[0]["subcategory"].ToString();
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
        param.Add(new MySqlParameter("@categoryid", _CatId));
        param.Add(new MySqlParameter("@subcategory", _SubCategory));
        param.Add(new MySqlParameter("@albumname", _AlbumName));
        param.Add(new MySqlParameter("@albumimage", _AlbumImage));
        Connection connect = new Connection();    
        connect.ExecStatement("INSERT INTO gallerysubcategory(categoryid,subcategory) VALUES(@categoryid,@subcategory)", param);
        connect.Dispose();
        connect = null;

    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@categoryid", _CatId));
        param.Add(new MySqlParameter("@subcategory", _SubCategory));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE gallerysubcategory SET categoryid=@categoryid,subcategory=@subcategory  WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getSubCategory(String query)
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

    public string SubCategory
    {
        get { return _SubCategory; }
        set { _SubCategory = value; }
    }
  
    public bool HasValue
    {
        get;
        set;
    }
}