using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for SliderData
/// </summary>
public class SliderData
{
    private int _Id;
    private string _Offer;
    private string _AboutOffer;
    private string _ImageName;
    private string _Link;
    private string _ImgWidth;
    private string _ImgHeihgt;
    private bool _IsVisible;
    private int _Section;
	public SliderData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SliderData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM slider WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ImageName = ds.Tables[0].Rows[0]["imagename"].ToString();
                _Offer = ds.Tables[0].Rows[0]["offer"].ToString();
                _AboutOffer = ds.Tables[0].Rows[0]["aboutoffer"].ToString();
                _Link = ds.Tables[0].Rows[0]["link"].ToString();
                _ImgWidth = ds.Tables[0].Rows[0]["imgwidth"].ToString();
                _ImgHeihgt = ds.Tables[0].Rows[0]["imgheight"].ToString();
                _IsVisible = ParseBool(ds.Tables[0].Rows[0]["isvisible"]);
                _Section = ParseInt(ds.Tables[0].Rows[0]["section"]);
               
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public void SaveQR()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@imagename", _ImageName));
        param.Add(new MySqlParameter("@offer", _Offer));
        param.Add(new MySqlParameter("@aboutoffer", _AboutOffer));
        param.Add(new MySqlParameter("@link", _ImageName));
        param.Add(new MySqlParameter("@imgwidth", _ImgWidth));
        param.Add(new MySqlParameter("@imgheight", _ImgHeihgt));
        param.Add(new MySqlParameter("@isvisible", _IsVisible));
        param.Add(new MySqlParameter("@section", _Section));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO slider(imagename,link,imgwidth,imgheight,isvisible,offer,aboutoffer,section) VALUES(@imagename,@link,@imgwidth,@imgheight,@isvisible,@offer,@aboutoffer,@section)", param);
        connect.Dispose();
        connect = null;
    }


    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@imagename", _ImageName));
        param.Add(new MySqlParameter("@offer", _Offer));
        param.Add(new MySqlParameter("@aboutoffer", _AboutOffer));       
        param.Add(new MySqlParameter("@link", _Link));
        param.Add(new MySqlParameter("@imgwidth", _ImgWidth));
        param.Add(new MySqlParameter("@imgheight", _ImgHeihgt));
        param.Add(new MySqlParameter("@isvisible", _IsVisible));
        param.Add(new MySqlParameter("@section", _Section));    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO slider(imagename,link,imgwidth,imgheight,isvisible,offer,aboutoffer,section) VALUES(@imagename,@link,@imgwidth,@imgheight,@isvisible,@offer,@aboutoffer,@section)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@imagename", _ImageName));
        param.Add(new MySqlParameter("@offer", _Offer));
        param.Add(new MySqlParameter("@aboutoffer", _AboutOffer));
        param.Add(new MySqlParameter("@link", _Link));
        param.Add(new MySqlParameter("@imgwidth", _ImgWidth));
        param.Add(new MySqlParameter("@imgheight", _ImgHeihgt));
        param.Add(new MySqlParameter("@isvisible", _IsVisible));
        param.Add(new MySqlParameter("@section", _Section));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE slider SET imagename=@imagename,link=@link,imgwidth=@imgwidth,imgheight=@imgheight,isvisible=@isvisible,offer=@offer,aboutoffer=@aboutoffer,section=@section WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public bool RowExists(string imageName)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@imagename", imageName));
        Connection connect = new Connection();
        DataSet ds = connect.GetDataset("SELECT id FROM slider WHERE imagename=@imagename", param);
        connect.Dispose();
        connect = null;
        return ds.Tables[0].Rows.Count > 0;
    }

    public void UpsertByImageName()
    {
        if (RowExists(_ImageName))
        {
            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("@imagename", _ImageName));
            Connection connect = new Connection();
            connect.ExecStatement("UPDATE slider SET link=@imagename WHERE imagename=@imagename", param);
            connect.Dispose();
            connect = null;
        }
        else
        {
            SaveQR();
        }
    }

    public DataSet GetSliderByImageName(string imageName)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@imagename", imageName));
        Connection connect = new Connection();
        DataSet ds = connect.GetDataset("SELECT * FROM slider WHERE imagename=@imagename", param);
        connect.Dispose();
        connect = null;
        return ds;
    }

    public void DeleteById(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        Connection connect = new Connection();
        connect.ExecStatement("DELETE FROM slider WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getSlider(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }

    public DataSet getSlider(String query, List<MySqlParameter> parameters)
    {
        Connection connect = new Connection();
        DataSet ds = connect.GetDataset(query, parameters);
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
    public int Section
    {
        get { return _Section; }
        set { _Section = value; }
    }


    public string ImageName
    {
        get { return _ImageName; }
        set { _ImageName = value; }
    }
    public string Offer
    {
        get { return _Offer; }
        set { _Offer = value; }
    }
    public string AboutOffer
    {
        get { return _AboutOffer; }
        set { _AboutOffer = value; }
    }
    public string Link
    {
        get { return _Link; }
        set { _Link = value; }
    }
    public string ImageWidth
    {
        get { return _ImgWidth; }
        set { _ImgWidth = value; }
    }

    public string ImageHeight
    {
        get { return _ImgHeihgt; }
        set { _ImgHeihgt = value; }
    }
    public bool IsVisible
    {
        get { return _IsVisible; }
        set { _IsVisible = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }

    private static bool ParseBool(object value)
    {
        if (value == null || value == DBNull.Value) return false;
        string s = value.ToString().Trim();
        if (s == "1") return true;
        if (s == "0") return false;
        bool result;
        return bool.TryParse(s, out result) && result;
    }

    private static int ParseInt(object value)
    {
        if (value == null || value == DBNull.Value) return 0;
        int result;
        return int.TryParse(value.ToString().Trim(), out result) ? result : 0;
    }

    
}