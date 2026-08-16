using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FindDealerData
/// </summary>
public class FindDealerData
{
    public FindDealerData()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public FindDealerData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        using (DataSet ds = connect.GetDataset("select * from finddealer where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                FirmName = ds.Tables[0].Rows[0]["firmName"].ToString();
                FirmCity = ds.Tables[0].Rows[0]["firmCity"].ToString();
                FirmState = ds.Tables[0].Rows[0]["firmState"].ToString();
                PinCode = ds.Tables[0].Rows[0]["pinCode"].ToString();
                PersonName = ds.Tables[0].Rows[0]["personName"].ToString();
                ContactNo = ds.Tables[0].Rows[0]["contactNumber"].ToString();
                FirmAddress = ds.Tables[0].Rows[0]["firmAddress"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }


    public FindDealerData(string pin)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", pin));
        using (DataSet ds = connect.GetDataset("select * from finddealer where id=@id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                pin = ds.Tables[0].Rows[0]["id"].ToString();
                FirmName = ds.Tables[0].Rows[0]["firmName"].ToString();
                FirmCity = ds.Tables[0].Rows[0]["firmCity"].ToString();
                FirmState = ds.Tables[0].Rows[0]["firmState"].ToString();
                PinCode = ds.Tables[0].Rows[0]["pinCode"].ToString();
                PersonName = ds.Tables[0].Rows[0]["personName"].ToString();
                ContactNo = ds.Tables[0].Rows[0]["contactNumber"].ToString();
                FirmAddress = ds.Tables[0].Rows[0]["firmAddress"].ToString();
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
        param.Add(new MySqlParameter("@firmName", FirmName));
        param.Add(new MySqlParameter("@firmCity", FirmCity));
        param.Add(new MySqlParameter("@firmState", FirmState));
        param.Add(new MySqlParameter("@pinCode", PinCode));
        param.Add(new MySqlParameter("@personName", PersonName));
        param.Add(new MySqlParameter("@contactNumber", ContactNo));
        param.Add(new MySqlParameter("@firmAddress", FirmAddress));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO finddealer(firmName,firmCity,firmState,pinCode,personName,contactNumber,firmAddress) VALUES(@firmName,@firmCity,@firmState,@pinCode,@personName,@contactNumber,@firmAddress)", param);
        connect.Dispose();
        connect = null;
    }

    public void update(int ids)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", ids));
        param.Add(new MySqlParameter("@firmName", FirmName));
        param.Add(new MySqlParameter("@firmCity", FirmCity));
        param.Add(new MySqlParameter("@firmState", FirmState));
        param.Add(new MySqlParameter("@pinCode", PinCode));
        param.Add(new MySqlParameter("@personName", PersonName));
        param.Add(new MySqlParameter("@contactNumber", ContactNo));
        param.Add(new MySqlParameter("@firmAddress", FirmAddress));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE finddealer SET firmName=@firmName,firmCity=@firmCity,firmState=@firmState,pinCode=@pinCode,personName=@personName,contactNumber=@contactNumber,firmAddress=@firmAddress  where id=@id", param);
        connect.Dispose();
        connect = null;
    }


    public DataSet getClassDetail(string query)
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

    public int Id { get; set; }

    public string FirmName { get; set; }
    public string FirmCity { get; set; }
    public string FirmState { get; set; }
    public string PinCode { get; set; }
    public string PersonName { get; set; }
    public string ContactNo { get; set; }
    public string FirmAddress { get; set; }

    public bool HasValue { get; set; }
}