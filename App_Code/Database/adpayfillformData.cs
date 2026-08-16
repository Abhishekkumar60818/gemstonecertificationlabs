using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adpayfillformData
/// </summary>
public class adpayfillformData
{
   
    public adpayfillformData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public adpayfillformData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM adpayfillform WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Name = ds.Tables[0].Rows[0]["Fullname"].ToString();
                gender = ds.Tables[0].Rows[0]["gender"].ToString();
                nationality = ds.Tables[0].Rows[0]["nationality"].ToString();
                idproof = ds.Tables[0].Rows[0]["idproof"].ToString();
                idnumber = ds.Tables[0].Rows[0]["idnumber"].ToString();
                nationalcost = int.Parse(ds.Tables[0].Rows[0]["nationalitycost"].ToString());

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public adpayfillformData(string name)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        
        using (DataSet ds = connect.GetDataset("SELECT * FROM adpayfillform ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                Name = ds.Tables[0].Rows[0]["Fullname"].ToString();
                gender = ds.Tables[0].Rows[0]["gender"].ToString();
                nationality = ds.Tables[0].Rows[0]["nationality"].ToString();
                idproof = ds.Tables[0].Rows[0]["idproof"].ToString();
                idnumber = ds.Tables[0].Rows[0]["idnumber"].ToString();
                nationalcost = int.Parse(ds.Tables[0].Rows[0]["nationalitycost"].ToString());

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

        param.Add(new MySqlParameter("@Fullname", Name));
        param.Add(new MySqlParameter("@gender", gender));
        param.Add(new MySqlParameter("@nationality", nationality));
        param.Add(new MySqlParameter("@idproof", idproof));
        param.Add(new MySqlParameter("@idnumber", idnumber)); 
        param.Add(new MySqlParameter("@Reg_Id", Reg_Id));
        param.Add(new MySqlParameter("@nationalitycost", nationalcost));


        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO adpayfillform(Fullname,gender,nationality,idproof,idnumber,Reg_Id,nationalitycost) VALUES(@Fullname,@gender,@nationality,@idproof,@idnumber,@Reg_Id,@nationalitycost)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", Id));
        param.Add(new MySqlParameter("@Fullname", Name));
        param.Add(new MySqlParameter("@gender", gender));
        param.Add(new MySqlParameter("@nationality", nationality));
        param.Add(new MySqlParameter("@idproof", idproof));
        param.Add(new MySqlParameter("@idnumber", idnumber));
        param.Add(new MySqlParameter("@Reg_Id", Reg_Id));
        param.Add(new MySqlParameter("@nationalitycost", nationalcost));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE adpayfillform SET Fullname=@Fullname,gender=@gender,nationality=@nationality,idproof=@idproof,idnumber=@idnumber,Reg_Id=@Reg_Id,nationalitycost=@nationalitycost WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getMedicineType(String query)
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
    public int Id{get;set;}
   public string Name { get; set; }
    public string gender { get; set; }
    public string nationality { get; set; }
    public string idproof { get; set; }
    public string idnumber { get; set; }
    public int Reg_Id { get; set; }
    public int nationalcost { get; set; }
    public bool HasValue
    {
        get;
        set;
    }
}