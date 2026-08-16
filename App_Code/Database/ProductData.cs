using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Summary description for ProductData
/// </summary>
public class ProductData
{
    private int _Id;
    private int _CatId;
    private int _SubCatId;
    private string _Product;
    private string _Image;
    private double _Price;
    private string _Discount;
    private double _NewPrice;
    private int _Quantity;
    private string _Description;
    private string _Code;
    private int _Color;
    private string _Size;
    private int _ProductType;
    private string _ScientificName;
    private string _KnownAs;
    private string _Standard;
    private string _Booktype;
    private string _Subject;

    private string _Language;
    private string _Publisher;
    private string _Authorwriter;

    private double _Tax;

    private int _Variants;

    public ProductData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ProductData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM product WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _SubCatId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                _Product = ds.Tables[0].Rows[0]["productName"].ToString();
                _Code = ds.Tables[0].Rows[0]["code"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _Discount = ds.Tables[0].Rows[0]["discount"].ToString();
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["newprice"].ToString());
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                _ScientificName = ds.Tables[0].Rows[0]["scientificname"].ToString();
                _KnownAs = ds.Tables[0].Rows[0]["knownas"].ToString();
                // _Color =int.Parse( ds.Tables[0].Rows[0]["color"].ToString());
                _Size = ds.Tables[0].Rows[0]["size"].ToString();
                _ProductType = int.Parse(ds.Tables[0].Rows[0]["prodtype"].ToString());
                //_Standard = ds.Tables[0].Rows[0]["standard"].ToString();
                //_Subject = ds.Tables[0].Rows[0]["subject"].ToString();
                //_Booktype = ds.Tables[0].Rows[0]["booktype"].ToString();
                //_Language = ds.Tables[0].Rows[0]["language"].ToString();
                _Variants = int.Parse(ds.Tables[0].Rows[0]["variants"].ToString());
                _Tax = double.Parse(ds.Tables[0].Rows[0]["tax"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public ProductData(string image)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM product WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _SubCatId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                _Product = ds.Tables[0].Rows[0]["productName"].ToString();
                _Code = ds.Tables[0].Rows[0]["code"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _Discount = ds.Tables[0].Rows[0]["discount"].ToString();
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["newprice"].ToString());
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                _ScientificName = ds.Tables[0].Rows[0]["scientificname"].ToString();
                _KnownAs = ds.Tables[0].Rows[0]["knownas"].ToString();
                // _Color =int.Parse( ds.Tables[0].Rows[0]["color"].ToString());
                _Size = ds.Tables[0].Rows[0]["size"].ToString();
                _ProductType = int.Parse(ds.Tables[0].Rows[0]["prodtype"].ToString());
                //_Standard = ds.Tables[0].Rows[0]["standard"].ToString();
                //_Subject = ds.Tables[0].Rows[0]["subject"].ToString();
                //_Booktype = ds.Tables[0].Rows[0]["booktype"].ToString();
                //_Language = ds.Tables[0].Rows[0]["language"].ToString();
                //_Publisher = ds.Tables[0].Rows[0]["publisher"].ToString();
                //_Authorwriter = ds.Tables[0].Rows[0]["authorwriter"].ToString();
                _Variants = int.Parse(ds.Tables[0].Rows[0]["variants"].ToString());
                _Tax = double.Parse(ds.Tables[0].Rows[0]["tax"].ToString());
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
        param.Add(new MySqlParameter("@catid", _CatId));
        param.Add(new MySqlParameter("@subcatid", _SubCatId));
        param.Add(new MySqlParameter("@product", _Product));
        param.Add(new MySqlParameter("@code", _Code));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@price", _Price));
        param.Add(new MySqlParameter("@discount", _Discount));
        param.Add(new MySqlParameter("@newprice", _NewPrice));
        param.Add(new MySqlParameter("@description", _Description));
        param.Add(new MySqlParameter("@scientificname", _ScientificName));
        param.Add(new MySqlParameter("@knownas", _KnownAs));
        param.Add(new MySqlParameter("@size", _Size));
        param.Add(new MySqlParameter("@prodtype", _ProductType));
        //param.Add(new MySqlParameter("@standard", _Standard));
        //param.Add(new MySqlParameter("@booktype", _Booktype));
        //param.Add(new MySqlParameter("@subject", _Subject));
        //param.Add(new MySqlParameter("@language", _Language));
        //param.Add(new MySqlParameter("@publisher", _Publisher));
        //param.Add(new MySqlParameter("@authorwriter", _Authorwriter));
        param.Add(new MySqlParameter("@variants", _Variants));


        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO product(categoryid,subcategoryid,productName,image,code,quantity,price,discount,newprice,description,scientificname,knownas,size,prodtype,variants)  VALUES(@catid,@subcatid,@product,@image,@code,@quantity,@price,@discount,@newprice,@description,@scientificname,@knownas,@size,@prodtype,@variants)", param);
        connect.Dispose();
        connect = null;
    }
    public void SaveImage()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@productid", _Id));
        /* param.Add(new MySqlParameter("@subcatid", _SubCatId));
         param.Add(new MySqlParameter("@product", _Product));
         param.Add(new MySqlParameter("@code", _Code));
         // param.Add(new MySqlParameter("@date", _Date));*/
        param.Add(new MySqlParameter("@image", _Image));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO productImage(productid,image) VALUES(@productid,@image)", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@catid", _CatId));
        param.Add(new MySqlParameter("@subcatid", _SubCatId));
        param.Add(new MySqlParameter("@product", _Product));
        param.Add(new MySqlParameter("@code", _Code));
        // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@price", _Price));
        param.Add(new MySqlParameter("@discount", _Discount));
        param.Add(new MySqlParameter("@newprice", _NewPrice));
        param.Add(new MySqlParameter("@description", _Description));
        param.Add(new MySqlParameter("@scientificname", _ScientificName));
        param.Add(new MySqlParameter("@knownas", _KnownAs));
        param.Add(new MySqlParameter("@size", _Size));
        param.Add(new MySqlParameter("@prodtype", _ProductType));
        param.Add(new MySqlParameter("@variants", _Variants));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE product SET categoryid=@catid,subcategoryid=@subcatid,productName=@product,image=@image,code=@code,quantity=@quantity,price=@price,discount=@discount,newprice=@newprice,description=@description,scientificname=@scientificname,knownas=@knownas,size=@size,prodtype=@prodtype,variants=@variants WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public void UpdateStock(int id)
    {
        try
        {
            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("@id", id));
            param.Add(new MySqlParameter("@quantity", _Quantity));
            Connection connect = new Connection();
            connect.ExecStatement("UPDATE product SET quantity=@quantity WHERE id=@id", param);
            connect.Dispose();
            connect = null;
        }
        catch (Exception ex) { }
    }

    public DataSet getProduct(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }

    public DataSet getFullProduct(int subid)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["mySQLconn"].ConnectionString;
        MySqlConnection cnn = new MySqlConnection(conn);
        MySqlDataAdapter cmd1 = new MySqlDataAdapter("select * from product where subcategoryid=" + subid, cnn);

        //Create and fill the DataSet.
        DataSet ds = new DataSet();
        cmd1.Fill(ds, "product");

        //Create a second DataAdapter for the Titles table.
        MySqlDataAdapter cmd2 = new MySqlDataAdapter("select * from productdetail where subcategoryid=" + subid, cnn);
        cmd2.Fill(ds, "productdetail");

        //Create the relation bewtween the Product and productdetail tables.
        ds.Relations.Add("prorelation",
        ds.Tables["product"].Columns["id"],
        ds.Tables["productdetail"].Columns["productid"]);

        return ds;
        cnn.Close();
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

    public int SubCatId
    {
        get { return _SubCatId; }
        set { _SubCatId = value; }
    }
    public string Product
    {
        get { return _Product; }
        set { _Product = value; }
    }
    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }
    public string ScientificName
    {
        get { return _ScientificName; }
        set { _ScientificName = value; }
    }

    public string KnownAs
    {
        get { return _KnownAs; }
        set { _KnownAs = value; }
    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
    }
    public string Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }
    public double NewPrice
    {
        get { return _NewPrice; }
        set { _NewPrice = value; }
    }
    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public int Color
    {
        get { return _Color; }
        set { _Color = value; }
    }

    public string Size
    {
        get { return _Size; }
        set { _Size = value; }
    }
    public int ProductType
    {
        get { return _ProductType; }
        set { _ProductType = value; }
    }

    public string Standard
    {
        get { return _Standard; }
        set { _Standard = value; }
    }
    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }
    public string Booktype
    {
        get { return _Booktype; }
        set { _Booktype = value; }
    }

    public string Language
    {
        get { return _Language; }
        set { _Language = value; }
    }
    public string Publisher
    {
        get { return _Publisher; }
        set { _Publisher = value; }
    }
    public string Authorwriter
    {
        get { return _Authorwriter; }
        set { _Authorwriter = value; }
    }

    public int Variants
    {
        get { return _Variants; }
        set { _Variants = value; }
    }
    public double Tax
    {
        get { return _Tax; }
        set { _Tax = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}