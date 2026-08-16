using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicineData
/// </summary>
public class MedicineData
{
    private int _Id;
    private int _Salt_Id;
    private string _Name;
    private string _Code;
    private string _Dose;
    private int _Medicine_Type;
    private string _Company;
    private double _MRP_Price;
    private double _PTR_Price;
    private double _PTP_Price;
    private string _PTR_Discount;
    private string _PTP_Discount;
    private double _Price_Per_Pic;
    private int _Quantity_Per_Strip;
    private int _Quantity;
    private string _Scheme;
    private string _Image;
    private int _User_Id;
    private string _Uses;
    private string _How_it_work;
    private string _Common_side_effect;
    private string _Expert_advice;
    private string _Page_Title;
    private string _Meta_key;
    private string _Meta_Description;
    private double _Tax;
    private int _Approved;

    public MedicineData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public MedicineData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicine WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Salt_Id = int.Parse(ds.Tables[0].Rows[0]["saltid"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Code = ds.Tables[0].Rows[0]["code"].ToString();
                _Dose = ds.Tables[0].Rows[0]["dose"].ToString();
                _Medicine_Type =int.Parse( ds.Tables[0].Rows[0]["medicine_type"].ToString());
                _Company = ds.Tables[0].Rows[0]["company"].ToString();
                _MRP_Price = double.Parse(ds.Tables[0].Rows[0]["mrp_price"].ToString());
                _PTR_Price = double.Parse(ds.Tables[0].Rows[0]["ptr_price"].ToString());
                _PTP_Price = double.Parse(ds.Tables[0].Rows[0]["ptp_price"].ToString());
                _PTR_Discount = ds.Tables[0].Rows[0]["ptr_discount"].ToString();
                _PTP_Discount = ds.Tables[0].Rows[0]["ptp_discount"].ToString();    
                _Price_Per_Pic = double.Parse(ds.Tables[0].Rows[0]["price_per_pic"].ToString());
                _Quantity_Per_Strip = int.Parse(ds.Tables[0].Rows[0]["qualtity_per_strip"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _Scheme = ds.Tables[0].Rows[0]["scheme"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _User_Id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                _Uses = ds.Tables[0].Rows[0]["uses"].ToString();
                _How_it_work = ds.Tables[0].Rows[0]["how_it_work"].ToString();
                _Common_side_effect = ds.Tables[0].Rows[0]["common_side_effect"].ToString();
                _Expert_advice = ds.Tables[0].Rows[0]["expert_advice"].ToString();
                _Page_Title = ds.Tables[0].Rows[0]["page_title"].ToString();
                _Meta_key = ds.Tables[0].Rows[0]["meta_key"].ToString();
                _Meta_Description = ds.Tables[0].Rows[0]["meta_description"].ToString();
                _Tax = double.Parse(ds.Tables[0].Rows[0]["tax"].ToString());
                _Approved = int.Parse(ds.Tables[0].Rows[0]["approved"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public MedicineData(string image)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM medicine WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Salt_Id = int.Parse(ds.Tables[0].Rows[0]["saltid"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Code = ds.Tables[0].Rows[0]["code"].ToString();
                _Dose = ds.Tables[0].Rows[0]["dose"].ToString();
                _Medicine_Type = int.Parse(ds.Tables[0].Rows[0]["medicine_type"].ToString());
                _Company = ds.Tables[0].Rows[0]["company"].ToString();
                _MRP_Price = double.Parse(ds.Tables[0].Rows[0]["mrp_price"].ToString());
                _PTR_Price = double.Parse(ds.Tables[0].Rows[0]["ptr_price"].ToString());
                _PTP_Price = double.Parse(ds.Tables[0].Rows[0]["ptp_price"].ToString());
                _PTR_Discount = ds.Tables[0].Rows[0]["ptr_discount"].ToString();
                _PTP_Discount = ds.Tables[0].Rows[0]["ptp_discount"].ToString(); 
                _Price_Per_Pic = double.Parse(ds.Tables[0].Rows[0]["price_per_pic"].ToString());
                _Quantity_Per_Strip = int.Parse(ds.Tables[0].Rows[0]["qualtity_per_strip"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _Scheme = ds.Tables[0].Rows[0]["scheme"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _User_Id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                _Uses = ds.Tables[0].Rows[0]["uses"].ToString();
                _How_it_work = ds.Tables[0].Rows[0]["how_it_work"].ToString();
                _Common_side_effect = ds.Tables[0].Rows[0]["common_side_effect"].ToString();
                _Expert_advice = ds.Tables[0].Rows[0]["expert_advice"].ToString();
                _Page_Title = ds.Tables[0].Rows[0]["page_title"].ToString();
                _Meta_key = ds.Tables[0].Rows[0]["meta_key"].ToString();
                _Meta_Description = ds.Tables[0].Rows[0]["meta_description"].ToString();
                _Tax = double.Parse(ds.Tables[0].Rows[0]["tax"].ToString());
                _Approved = int.Parse(ds.Tables[0].Rows[0]["approved"].ToString());
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
        param.Add(new MySqlParameter("@saltid", _Salt_Id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@code", _Code));
        param.Add(new MySqlParameter("@dose", _Dose));
        param.Add(new MySqlParameter("@medicine_type", _Medicine_Type));
        param.Add(new MySqlParameter("@company", _Company));
        param.Add(new MySqlParameter("@mrp_price", _MRP_Price));
        param.Add(new MySqlParameter("@ptr_discount", _PTR_Discount));
        param.Add(new MySqlParameter("@ptr_price", _PTR_Price));
        param.Add(new MySqlParameter("@price_per_pic", _Price_Per_Pic));
        param.Add(new MySqlParameter("@qualtity_per_strip", _Quantity_Per_Strip));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@scheme", _Scheme));
        param.Add(new MySqlParameter("@tax", _Tax));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@user_id", _User_Id));
        param.Add(new MySqlParameter("@uses", _Uses));
        param.Add(new MySqlParameter("@how_it_work", _How_it_work));
        param.Add(new MySqlParameter("@common_side_effect", _Common_side_effect));
        param.Add(new MySqlParameter("@expert_advice", _Expert_advice));
        param.Add(new MySqlParameter("@page_title", _Page_Title));
        param.Add(new MySqlParameter("@meta_key", _Meta_key));
        param.Add(new MySqlParameter("@meta_description", _Meta_Description));


        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO medicine(saltid,name,code,dose,medicine_type,company,mrp_price,ptr_discount,ptr_price,price_per_pic,qualtity_per_strip,quantity,scheme,tax,image,user_id,uses,how_it_work,common_side_effect,expert_advice,page_title,meta_key,meta_description)  VALUES(@saltid,@name,@code,@dose,@medicine_type,@company,@mrp_price,@ptr_discount,@ptr_price,@price_per_pic,@qualtity_per_strip,@quantity,@scheme,@tax,@image,@user_id,@uses,@how_it_work,@common_side_effect,@expert_advice,@page_title,@meta_key,@meta_description)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@saltid", _Salt_Id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@code", _Code));
        param.Add(new MySqlParameter("@dose", _Dose));
        param.Add(new MySqlParameter("@medicine_type", _Medicine_Type));
        param.Add(new MySqlParameter("@company", _Company));
        param.Add(new MySqlParameter("@mrp_price", _MRP_Price));
        param.Add(new MySqlParameter("@ptr_discount", _PTR_Discount));
        param.Add(new MySqlParameter("@ptr_price", _PTR_Price));
        param.Add(new MySqlParameter("@price_per_pic", _Price_Per_Pic));
        param.Add(new MySqlParameter("@qualtity_per_strip", _Quantity_Per_Strip));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@scheme", _Scheme));
        param.Add(new MySqlParameter("@tax", _Tax));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@user_id", _User_Id));
        param.Add(new MySqlParameter("@uses", _Uses));
        param.Add(new MySqlParameter("@how_it_work", _How_it_work));
        param.Add(new MySqlParameter("@common_side_effect", _Common_side_effect));
        param.Add(new MySqlParameter("@expert_advice", _Expert_advice));
        param.Add(new MySqlParameter("@page_title", _Page_Title));
        param.Add(new MySqlParameter("@meta_key", _Meta_key)); 
        param.Add(new MySqlParameter("@meta_description", _Meta_Description));
        param.Add(new MySqlParameter("@approved", _Approved));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE medicine SET saltid=@saltid,name=@name,code=@code,dose=@dose,medicine_type=@medicine_type,company=@company,mrp_price=@mrp_price,ptr_discount=@ptr_discount,ptr_price=@ptr_price,price_per_pic=@price_per_pic,qualtity_per_strip=@qualtity_per_strip,quantity=@quantity,scheme=@scheme,tax=@tax,image=@image,user_id=@user_id,uses=@uses,how_it_work=@how_it_work,common_side_effect=@common_side_effect,expert_advice=@expert_advice,page_title=@page_title,meta_key=@meta_key,meta_description=@meta_description,approved=@approved WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateApprovel(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@saltid", _Salt_Id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@code", _Code));
        param.Add(new MySqlParameter("@dose", _Dose));
        param.Add(new MySqlParameter("@medicine_type", _Medicine_Type));
        param.Add(new MySqlParameter("@company", _Company));
        param.Add(new MySqlParameter("@mrp_price", _MRP_Price));
        param.Add(new MySqlParameter("@ptr_discount", _PTR_Discount));
        param.Add(new MySqlParameter("@ptr_price", _PTR_Price));
        param.Add(new MySqlParameter("@price_per_pic", _Price_Per_Pic));
        param.Add(new MySqlParameter("@qualtity_per_strip", _Quantity_Per_Strip));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@scheme", _Scheme));
        param.Add(new MySqlParameter("@tax", _Tax));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@user_id", _User_Id));
        param.Add(new MySqlParameter("@uses", _Uses));
        param.Add(new MySqlParameter("@how_it_work", _How_it_work));
        param.Add(new MySqlParameter("@common_side_effect", _Common_side_effect));
        param.Add(new MySqlParameter("@expert_advice", _Expert_advice));
        param.Add(new MySqlParameter("@page_title", _Page_Title));
        param.Add(new MySqlParameter("@meta_key", _Meta_key));
        param.Add(new MySqlParameter("@meta_description", _Meta_Description));
        param.Add(new MySqlParameter("@ptp_price", _PTP_Price));
        param.Add(new MySqlParameter("@ptp_discount", _PTP_Discount));
        param.Add(new MySqlParameter("@approved", _Approved));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE medicine SET saltid=@saltid,name=@name,code=@code,dose=@dose,medicine_type=@medicine_type,company=@company,mrp_price=@mrp_price,ptr_discount=@ptr_discount,ptr_price=@ptr_price,ptp_price=@ptp_price,ptp_discount=@ptp_discount,price_per_pic=@price_per_pic,qualtity_per_strip=@qualtity_per_strip,quantity=@quantity,scheme=@scheme,tax=@tax,image=@image,user_id=@user_id,uses=@uses,how_it_work=@how_it_work,common_side_effect=@common_side_effect,expert_advice=@expert_advice,page_title=@page_title,meta_key=@meta_key,meta_description=@meta_description,approved=@approved WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getMedicine(String query)
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
    public int Salt_Id
    {
        get { return _Salt_Id; }
        set { _Salt_Id = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }

    public string Dose
    {
        get { return _Dose; }
        set { _Dose = value; }
    }
    public int Medicine_Type
    {
        get { return _Medicine_Type; }
        set { _Medicine_Type = value; }
    } 

    public string Company
    {
        get { return _Company; }
        set { _Company = value; }
    }
    public double MRP_Price
    {
        get { return _MRP_Price; }
        set { _MRP_Price = value; }
    }
    public double PTR_Price
    {
        get { return _PTR_Price; }
        set { _PTR_Price = value; }
    }
    public string PTR_Discount
    {
        get { return _PTR_Discount; }
        set { _PTR_Discount = value; }
    }
    public double PTP_Price
    {
        get { return _PTP_Price; }
        set { _PTP_Price = value; }
    }
    public string PTP_Discount
    {
        get { return _PTP_Discount; }
        set { _PTP_Discount = value; }
    }
     public double Price_Per_Pic
    {
        get { return _Price_Per_Pic; }
        set { _Price_Per_Pic = value; }
    }
     public double Tax
     {
         get { return _Tax; }
         set { _Tax = value; }
     }
      public int Quantity_Per_Strip
    {
        get { return _Quantity_Per_Strip; }
        set { _Quantity_Per_Strip = value; }
    }
    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string Scheme
    {
        get { return _Scheme; }
        set { _Scheme = value; }
    }
      public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public int User_ID
    {
        get { return _User_Id; }
        set { _User_Id = value; }
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
    public string PageTitle
    {
        get { return _Page_Title; }
        set { _Page_Title = value; }
    }
    public string MetaKeyes
    {
        get { return _Meta_key; }
        set { _Meta_key = value; }
    }
    public string MetaDescription
    {
        get { return _Meta_Description; }
        set { _Meta_Description = value; }
    }
    public int Approved
    {
        get { return _Approved; }
        set { _Approved = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}