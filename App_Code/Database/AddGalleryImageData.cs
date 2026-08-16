using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddGalleryImageData
/// </summary>
public class AddGalleryImageData
{
    private int _Id;
    private int _CatId;
    private int _SubCategoryId;
    private int _SubCategorySubId;
    private string _Name;
    private string _Image;
    private string _AlbumName;

    public AddGalleryImageData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AddGalleryImageData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from gallery where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Catid = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                SubCategorySubId = int.Parse(ds.Tables[0].Rows[0]["subcategorysubid"].ToString());
                Image = ds.Tables[0].Rows[0]["image"].ToString();
                Name = ds.Tables[0].Rows[0]["name"].ToString();
                AlbumName = ds.Tables[0].Rows[0]["albumname"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public AddGalleryImageData(string albumname ,int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@albumname", albumname));
        using (DataSet ds = connect.GetDataset("select * from gallery where albumname=@albumname", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Catid = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                SubCategoryId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                Image = ds.Tables[0].Rows[0]["image"].ToString();
                Name = ds.Tables[0].Rows[0]["name"].ToString();
                AlbumName = ds.Tables[0].Rows[0]["albumname"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public AddGalleryImageData(string category)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@category", category));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerycategory WHERE category=@category ", param))
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
        param.Add(new MySqlParameter("@subcategoryid", subcategory));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallery WHERE subcategoryid=@subcategoryid ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
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
        param.Add(new MySqlParameter("@categoryid", _CatId));
        param.Add(new MySqlParameter("@subcategoryid", _SubCategoryId));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@subcategorysubid", _AlbumName));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO gallery(categoryid,subcategoryid,image,name,subcategorysubid) VALUES(@categoryid,@subcategoryid,@image,@name,@subcategorysubid)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@categoryid", _CatId));
        param.Add(new MySqlParameter("@subcategoryid", _SubCategoryId));
        param.Add(new MySqlParameter("@subcategorysubid", _AlbumName));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@image", _Image));
      
       
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE gallery SET categoryid=@categoryid,subcategoryid=@subcategoryid,subcategorysubid=@subcategorysubid,name=@name,image=@image WHERE id=" + id, param);
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

    public int SubCategorySubId
    {
        get { return _SubCategorySubId; }
        set { _SubCategorySubId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string AlbumName
    {
        get { return _AlbumName; }
        set { _AlbumName = value; }
    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }



    public bool HasValue
    {
        get;
        set;
    }
}