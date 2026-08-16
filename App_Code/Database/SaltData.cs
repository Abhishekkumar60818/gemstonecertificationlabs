using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SaltData
/// </summary>
public class SaltData
{
    private static int _Id;
    private static string _Name;
    private string _Uses;
    private string _How_it_work;
    private string _Common_side_effect;
    private string _Expert_advice;
	public SaltData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      public SaltData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM saltinfo WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Uses = ds.Tables[0].Rows[0]["uses"].ToString();
                _How_it_work = ds.Tables[0].Rows[0]["how_it_work"].ToString();
                _Common_side_effect = ds.Tables[0].Rows[0]["common_side_effect"].ToString();
                _Expert_advice = ds.Tables[0].Rows[0]["expert_advice"].ToString();
               
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
      public SaltData(string name)
      {
          Connection connect = new Connection();
          List<MySqlParameter> param = new List<MySqlParameter>();
          param.Add(new MySqlParameter("@name", name));
          using (DataSet ds = connect.GetDataset("SELECT * FROM saltinfo WHERE name=@name", param))
          {
              if (ds.Tables[0].Rows.Count > 0)
              {

                  HasValue = true;
                  _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                  _Name = ds.Tables[0].Rows[0]["name"].ToString();
                  _Uses = ds.Tables[0].Rows[0]["uses"].ToString();
                  _How_it_work = ds.Tables[0].Rows[0]["how_it_work"].ToString();
                  _Common_side_effect = ds.Tables[0].Rows[0]["common_side_effect"].ToString();
                  _Expert_advice = ds.Tables[0].Rows[0]["expert_advice"].ToString();

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
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@uses", _Uses));
        param.Add(new MySqlParameter("@how_it_work", _How_it_work));
        param.Add(new MySqlParameter("@common_side_effect", _Common_side_effect));
        param.Add(new MySqlParameter("@expert_advice", _Expert_advice));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO saltinfo(name,uses,how_it_work,common_side_effect,expert_advice)  VALUES(@name,@uses,@how_it_work,@common_side_effect,@expert_advice)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@name", _Name));       
        param.Add(new MySqlParameter("@uses", _Uses));
        param.Add(new MySqlParameter("@how_it_work", _How_it_work));
        param.Add(new MySqlParameter("@common_side_effect", _Common_side_effect));
        param.Add(new MySqlParameter("@expert_advice", _Expert_advice));      
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE saltinfo SET name=@name,uses=@uses,how_it_work=@how_it_work,common_side_effect=@common_side_effect,expert_advice=@expert_advice WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getSalts(String query)
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
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

 
    public string Uses
    {
        get { return _Uses; }
        set { _Uses = value; }
    }

    public string How_it_work
    {
        get { return _How_it_work; }
        set { _How_it_work = value; }
    }
    public string Common_side_effect
    {
        get { return _Common_side_effect; }
        set { _Common_side_effect = value; }
    }
     public string Expert_advice
    {
        get { return _Expert_advice; }
        set { _Expert_advice = value; }
    }   
    public bool HasValue
    {
        get;
        set;
    }
}