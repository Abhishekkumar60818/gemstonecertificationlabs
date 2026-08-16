using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RankingData
/// </summary>
public class RankingData
{
    public RankingData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public RankingData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from ranking where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Reg_Id = int.Parse(ds.Tables[0].Rows[0]["Reg_Id"].ToString());
                Types = ds.Tables[0].Rows[0]["Types"].ToString();
                gold = ds.Tables[0].Rows[0]["gold"].ToString();
                silver = ds.Tables[0].Rows[0]["silver"].ToString();
                brouch = ds.Tables[0].Rows[0]["brouch"].ToString();
                img_g = ds.Tables[0].Rows[0]["img_g"].ToString();
                img_s = ds.Tables[0].Rows[0]["img_s"].ToString();
                img_b = ds.Tables[0].Rows[0]["img_b"].ToString();
                
            }
            else
            {
                
            }
        }
        connect.Dispose();
        connect = null;
    }

    public void update()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@Reg_Id", Reg_Id));
        param.Add(new MySqlParameter("@Types", Types));
        param.Add(new MySqlParameter("@gold", gold));
        param.Add(new MySqlParameter("@silver", silver));
        param.Add(new MySqlParameter("@brouch", brouch));
        param.Add(new MySqlParameter("@img_g", img_g));
        param.Add(new MySqlParameter("@img_s", img_s));
        param.Add(new MySqlParameter("@img_b", img_b));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE ranking SET Reg_Id=@Reg_Id,Types=@Types,gold=@gold,silver=@silver,brouch=@brouch,img_g=@img_g,img_s=@img_s,img_b=@img_b", param);
        connect.Dispose();
        connect = null;

    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@Reg_Id", Reg_Id));
        param.Add(new MySqlParameter("@Types", Types)); 
        param.Add(new MySqlParameter("@gold", gold));
        param.Add(new MySqlParameter("@silver", silver));
        param.Add(new MySqlParameter("@brouch", brouch));
        param.Add(new MySqlParameter("@img_g", img_g));
        param.Add(new MySqlParameter("@img_s", img_s));
        param.Add(new MySqlParameter("@img_b", img_b));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO ranking(Reg_Id,Types,gold,silver,brouch,img_g,img_s,img_b) VALUES(@Reg_Id,@Types,@gold,@silver,@brouch,@img_g,@img_s,@img_b)", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getdetails(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public int id { get; set; }
    public int Reg_Id { get; set; }
    public string Types { get; set; }
    public string gold { get; set; }
    public string silver { get; set; }
    public string brouch { get; set; }
    public string img_g { get; set; }
    public string img_s { get; set; }
    public string img_b { get; set; }
    
}