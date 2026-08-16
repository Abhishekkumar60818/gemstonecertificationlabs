using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for  
/// </summary>
public class AddCategoryData
{
    private int _Id;
    private string _Category;
 

    public AddCategoryData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
  

    public void Save()
    {
        List<MySqlParameter> parms = new List<MySqlParameter>();
        parms.Add(new MySqlParameter("@category", _Category));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO  category(category) VALUES(@category)", parms);
        connect.Dispose();
        connect = null;
    }



    public AddCategoryData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM category WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Category = ds.Tables[0].Rows[0]["categoryName"].ToString();
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
        param.Add(new MySqlParameter("@categoryName", _Category));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE category SET categoryName=@categoryName  where id=" + Id, param);
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

   

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }


    public bool HasValue
    {
        get;
        set;
    }
}