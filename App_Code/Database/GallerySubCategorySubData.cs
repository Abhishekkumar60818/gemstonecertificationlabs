using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GallerySubCategorySubData
/// </summary>
public class GallerySubCategorySubData
{
    private int _Id;
    private int _SubCategoryId;
    private string _Subcatname;
    private string _AlbumName;
    private string _AlbumImage;
    public GallerySubCategorySubData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public GallerySubCategorySubData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategorysub WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                _AlbumName = ds.Tables[0].Rows[0]["albumname"].ToString();
                _AlbumImage = ds.Tables[0].Rows[0]["albumimage"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public GallerySubCategorySubData(int Id,string name)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategorysub WHERE subcategoryid=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                _AlbumName = ds.Tables[0].Rows[0]["albumname"].ToString();
                _AlbumImage = ds.Tables[0].Rows[0]["albumimage"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public GallerySubCategorySubData(string subcatename)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@subcatname", subcatename));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategorysub WHERE subcatname=@subcatname", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                _Subcatname = ds.Tables[0].Rows[0]["subcatname"].ToString();
                _AlbumName = ds.Tables[0].Rows[0]["albumname"].ToString();
                _AlbumImage = ds.Tables[0].Rows[0]["albumimage"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public GallerySubCategorySubData(string image, string nousse)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerysubcategorysub WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _Subcatname = ds.Tables[0].Rows[0]["subcategory"].ToString();
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
        param.Add(new MySqlParameter("@subcategoryid", _SubCategoryId));
        param.Add(new MySqlParameter("@albumname", _AlbumName));
        param.Add(new MySqlParameter("@albumimage", _AlbumImage));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO gallerysubcategorysub(subcategoryid,albumname,albumimage) VALUES(@subcategoryid,@albumname,@albumimage)", param);
        connect.Dispose();
        connect = null;

    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@subcategoryid", _SubCategoryId));
        param.Add(new MySqlParameter("@albumname", _AlbumName));
        param.Add(new MySqlParameter("@albumimage", _AlbumImage));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE gallerysubcategorysub SET subcategoryid=@subcategoryid,albumname=@albumname,albumimage=@albumimage  WHERE id=@id", param);
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
    public int SubCategoryId
    {
        get { return _SubCategoryId; }
        set { _SubCategoryId = value; }
    }

    public string Subcatname
    {
        get { return _Subcatname; }
        set { _Subcatname = value; }
    }
    public string AlbumName
    {
        get { return _AlbumName; }
        set { _AlbumName = value; }
    }

    public string AlbumImage
    {
        get { return _AlbumImage; }
        set { _AlbumImage = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}