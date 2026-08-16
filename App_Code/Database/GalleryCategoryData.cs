using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GalleryCategoryData
/// </summary>
public class GalleryCategoryData
{
    public GalleryCategoryData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Save()
    {
        List<MySqlParameter> parms = new List<MySqlParameter>();
        parms.Add(new MySqlParameter("@category", gallerycategory));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO  gallerycategory(category) VALUES(@category)", parms);
        connect.Dispose();
        connect = null;
    }



    public GalleryCategoryData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM gallerycategory WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                gallerycategory = ds.Tables[0].Rows[0]["category"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }


    public void Update(int Id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@category", gallerycategory));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE gallerycategory SET category=@category  where id=" + Id, param);
        connect.Dispose();
        connect = null;
    }



    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement(query);
        connect.Dispose();
        connect = null;
    }


    public DataSet getCategoryDetail(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        DataSet ds = connect.GetDataset(query);
        return ds;
    }



    

    public int id { get; set; }
    public string gallerycategory { get; set; }
    public bool HasValue
    {
        get;
        set;
    }
}