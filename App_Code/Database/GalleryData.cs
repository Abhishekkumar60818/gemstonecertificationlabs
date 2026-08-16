using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GalleryData
/// </summary>
public class GalleryData
{
    public GalleryData()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public GalleryData(int id)
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
                image = ds.Tables[0].Rows[0]["image"].ToString();
                name = ds.Tables[0].Rows[0]["name"].ToString();
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
        param.Add(new MySqlParameter("@name", name));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO gallery(image,name) VALUES(@image,@name)", param);
        connect.Dispose();
        connect = null;
    }

    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@image", image));
        param.Add(new MySqlParameter("@name", name));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE gallery SET image=@image,name=@name where id=@id", param);
        connect.Dispose();
        connect = null;

    }
    public DataSet getGalleryDetail(string query)
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
    public string name { get; set; }
    public string image { get; set; }
    public bool HasValue { get; set; }
}
