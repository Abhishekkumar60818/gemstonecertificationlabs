using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string checkCart(string sessionid)
    {
        DataSet ds = null;
        string res = "";
        try
        {
            MyCartData cdatach = new MyCartData();

            ds = cdatach.getCart("select * from cartdata where sessionid='" + sessionid + "'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                res = "no";
            }
            else
            {
                res = "yes";
            }

        }
        catch (Exception ex)
        {

        }
        return res;
    }




    [WebMethod]
    public string forgetPassword(string email)
    {
        string responce = "";
        try
        {
            UserData cdata = new UserData(email);
            if (cdata.HasValue)
            {
                responce = "ok";
                MailManager mail = new MailManager();
                mail.SendForgetPassMail(cdata);
            }
            else
            {
                responce = "no";
            }
        }
        catch (Exception ex)
        {

        }
        return responce;
    }






    [WebMethod]
    public string checkMedicineCart(string sessionid)
    {
        DataSet ds = null;
        string res = "";
        try
        {
            MyCartData cdatach = new MyCartData();

            ds = cdatach.getCart("select * from medicine_cart where sessionid='" + sessionid + "'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                res = "no";
            }
            else
            {
                res = "yes";
            }

        }
        catch (Exception ex)
        {

        }
        return res;
    }


    [WebMethod]
    public string byNowItems(string dataid, string oldprice, string newprice, string sessionid, string size, string email, string quantity)
    {
        string reponse = "";
        try
        {
            UserData usrdata = new UserData(email);
            DirectProductData dpdatach = new DirectProductData(int.Parse(dataid), sessionid, size, email, "nouse");
            ProductData pdata = new ProductData(int.Parse(dataid));
            int avalQty = pdata.Quantity;
            if (int.Parse(quantity) <= avalQty)
            {

                if (!dpdatach.HasValue)
                {
                    UserData udate = new UserData(email);
                    int status = 1;
                    DirectProductData dpdata = new DirectProductData();
                    dpdata.ProductId = int.Parse(dataid);
                    dpdata.Size = size;
                    dpdata.Quantity = int.Parse(quantity.ToString());
                    dpdata.IsCheckout = true;
                    //cdata.Price = double.Parse(oldprice);
                    dpdata.NewPrice = double.Parse(newprice);
                    dpdata.UserId = udate.Id;
                    dpdata.SessionId = sessionid;
                    dpdata.DiscountId = 0;
                    dpdata.Save();
                    reponse = "Manoj";
                }
                else
                {
                    int preqty = dpdatach.Quantity;
                    int updateqty = preqty + int.Parse(quantity);
                    dpdatach.Quantity = updateqty;
                    dpdatach.Update(int.Parse(dataid), usrdata.Id, sessionid, size);
                    reponse = "Manoj";
                }
            }
            else
            {
                reponse = avalQty.ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return reponse;
    }



    [WebMethod]

    public string saveDataQuantity(string dataid, string oldprice, string newprice, string sessionid, string email, string quantity)
    {

        string reponse = "";
        try
        {
            UserData usrdata = new UserData(email);
            MyCartData cdatach = new MyCartData(int.Parse(dataid), sessionid, email, "nouse");
            ProductData pdata = new ProductData(int.Parse(dataid));
            int avalQty = pdata.Quantity;
            if (int.Parse(quantity) <= avalQty)
            {

                if (!cdatach.HasValue)
                {
                    UserData udate = new UserData(email);

                    int status = 1;
                    MyCartData cdata = new MyCartData();

                    cdata.ProductId = int.Parse(dataid);

                    cdata.Quantity = int.Parse(quantity.ToString());
                    cdata.IsCheckout = true;
                    cdata.Price = double.Parse(oldprice);
                    cdata.NewPrice = double.Parse(newprice);
                    cdata.UserId = udate.Id;
                    cdata.SessionId = sessionid;
                    cdata.DiscountId = 0;
                    cdata.Save();
                    reponse = "Manoj";
                }
                else
                {
                    int preqty = cdatach.Quantity;
                    int updateqty = preqty + int.Parse(quantity);
                    cdatach.Quantity = updateqty;
                    cdatach.Update(int.Parse(dataid), usrdata.Id, sessionid);
                    reponse = "Manoj";
                }
            }
            else
            {
                reponse = avalQty.ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return reponse;
    }

    [WebMethod]
    public string saveDataFromShopingCart(string dataid, string oldprice, string newprice, string size, string sessionid, string email)
    {
        string reponse = "";
        try
        {
            MyCartData cdatach = new MyCartData(int.Parse(dataid), sessionid, email, "nouse");
            UserData udate = new UserData(email);
            if (!cdatach.HasValue)
            {
                int status = 1;
                MyCartData cdata = new MyCartData();
                cdata.ProductId = int.Parse(dataid);

                cdata.Quantity = 1;
                cdata.IsCheckout = true;
                //cdata.Price = double.Parse(oldprice);
                cdata.NewPrice = double.Parse(newprice);
                cdata.UserId = udate.Id;
                cdata.SessionId = sessionid;
                cdata.DiscountId = 0;
                cdata.Size = size;
                cdata.Save();
                reponse = "Manoj";
            }
            else
            {
                int preqty = cdatach.Quantity;
                int updateqty = preqty + 1;
                cdatach.Quantity = updateqty;
                cdatach.Update(int.Parse(dataid), udate.Id, sessionid);
                reponse = "Manoj";
            }



        }
        catch (Exception ex)
        {

        }
        return reponse;
    }


    [WebMethod]
    public void saveData(string dataid, string oldprice, string newprice, string size, int quantity, string sessionid, string email)
    {
        try
        {
            MyCartData cdatach = new MyCartData(int.Parse(dataid), sessionid, email);
            UserData udate = new UserData(email);
            if (!cdatach.HasValue)
            {
                int status = 1;
                MyCartData cdata = new MyCartData();
                cdata.ProductId = int.Parse(dataid);
                //cdata.Price = double.Parse(oldprice);
                cdata.NewPrice = double.Parse(newprice);
                cdata.Size = size;
                cdata.Quantity = quantity;
                cdata.SessionId = sessionid;
                cdata.IsCheckout = true;
                cdata.UserId = udate.Id;
                cdata.DiscountId = 0;
                cdata.Save();
            }
            else {  }
        }
        catch  {   }
    }

    [WebMethod]
    public void saveDataNew(string dataid, string oldprice, string newprice, string sessionid, string size, string email, int qty)
    {
        try
        {

            MyCartData cdatach = new MyCartData(int.Parse(dataid), sessionid, email);
            UserData udate = new UserData(email);
            if (!cdatach.HasValue)
            {
                int status = 1;
                MyCartData cdata = new MyCartData();
                cdata.ProductId = int.Parse(dataid);
                cdata.Size = size;
                cdata.Quantity = qty;
                cdata.IsCheckout = true;
                //cdata.Price = double.Parse(oldprice);
                cdata.NewPrice = double.Parse(newprice);
                cdata.UserId = udate.Id;
                cdata.SessionId = sessionid;
                cdata.DiscountId = 0;
                cdata.Save();
            }
            else
            {

            }
        }
        catch
        {

        }
    }

    [WebMethod]

    public string byNowMedicineProduct(string dataid, string oldprice, string newprice, string sessionid, string dose, string email, string quantity)
    {
        string reponse = "";

        try
        {

            UserData usdata = new UserData(email);
            DirectProductDataMed dmcdatach = new DirectProductDataMed(int.Parse(dataid), sessionid, dose, email, "nouse");
            MedicineData mdata = new MedicineData(int.Parse(dataid));
            int avalQuantity = mdata.Quantity;
            if (int.Parse(quantity) <= avalQuantity)
            {

                if (!dmcdatach.HasValue)
                {
                    UserData udate = new UserData(email);
                    int status = 1;
                    DirectProductDataMed dmcdata = new DirectProductDataMed();
                    dmcdata.ProductId = int.Parse(dataid);
                    dmcdata.Dose = dose;
                    dmcdata.Quantity = int.Parse(quantity.ToString());
                    dmcdata.Price = double.Parse(oldprice);
                    dmcdata.NewPrice = double.Parse(newprice);
                    dmcdata.UserId = udate.Id;
                    dmcdata.SessionId = sessionid;
                    dmcdata.UserType = "Normal";
                    dmcdata.Save();
                    reponse = "Manoj";
                }
                else
                {
                    int preqty = dmcdatach.Quantity;
                    int updateQty = preqty + int.Parse(quantity.ToString());
                    dmcdatach.Quantity = updateQty;
                    dmcdatach.Update(int.Parse(dataid), sessionid, usdata.Id);
                    reponse = "Manoj";
                }
            }
            else
            {
                reponse = avalQuantity.ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return reponse;
    }

    [WebMethod]
    public string saveMedicineCartQuantity(string dataid, string oldprice, string newprice, string sessionid, string dose, string email, string quantity)
    {
        string reponse = "";

        try
        {

            UserData usdata = new UserData(email);
            MedicineCart mcdatach = new MedicineCart(int.Parse(dataid), sessionid, dose, email, "nouse");
            MedicineData mdata = new MedicineData(int.Parse(dataid));
            int avalQuantity = mdata.Quantity;
            if (int.Parse(quantity) <= avalQuantity)
            {

                if (!mcdatach.HasValue)
                {
                    UserData udate = new UserData(email);
                    int status = 1;
                    MedicineCart mcdata = new MedicineCart();
                    mcdata.ProductId = int.Parse(dataid);
                    mcdata.Dose = dose;
                    mcdata.Quantity = int.Parse(quantity.ToString());
                    mcdata.Price = double.Parse(oldprice);
                    mcdata.NewPrice = double.Parse(newprice);
                    mcdata.UserId = udate.Id;
                    mcdata.SessionId = sessionid;
                    mcdata.UserType = "Normal";
                    mcdata.Save();
                    reponse = "Manoj";
                }
                else
                {
                    int preqty = mcdatach.Quantity;
                    int updateQty = preqty + int.Parse(quantity.ToString());
                    mcdatach.Quantity = updateQty;
                    mcdatach.Update(int.Parse(dataid), sessionid, usdata.Id);
                    reponse = "Manoj";
                }
            }
            else
            {
                reponse = avalQuantity.ToString();
            }
        }
        catch (Exception ex)
        {

        }
        return reponse;
    }

    [WebMethod]
    public string saveMedicineCart(string dataid, string oldprice, string newprice, string sessionid, string dose, string email, string from, string orderType)
    {
        string reponse = "";

        try
        {
            if (from == "cart" && orderType == "med")
            {
                MedicineCart mcdatach = new MedicineCart(int.Parse(dataid), sessionid, dose, email);
                UserData udate = new UserData(email);
                if (!mcdatach.HasValue)
                {

                    int status = 1;
                    MedicineCart mcdata = new MedicineCart();
                    mcdata.ProductId = int.Parse(dataid);
                    mcdata.Dose = dose;
                    mcdata.Quantity = 1;
                    mcdata.Price = double.Parse(oldprice);
                    mcdata.NewPrice = double.Parse(newprice);
                    mcdata.UserId = udate.Id;
                    mcdata.SessionId = sessionid;
                    mcdata.UserType = "Normal";
                    mcdata.Save();
                    reponse = "Manoj";
                }
                else
                {
                    int preqty = mcdatach.Quantity;
                    int updateQty = preqty + 1;
                    mcdatach.Quantity = updateQty;
                    mcdatach.Update(int.Parse(dataid), sessionid, udate.Id);
                    reponse = "Manoj";
                }
            }

            else
            {
                DirectProductDataMed mdcdatach = new DirectProductDataMed(int.Parse(dataid), sessionid, dose, email);
                UserData udate = new UserData(email);
                if (!mdcdatach.HasValue)
                {

                    int status = 1;
                    DirectProductDataMed mdcdata = new DirectProductDataMed();
                    mdcdata.ProductId = int.Parse(dataid);
                    mdcdata.Dose = dose;
                    mdcdata.Quantity = 1;
                    mdcdata.Price = double.Parse(oldprice);
                    mdcdata.NewPrice = double.Parse(newprice);
                    mdcdata.UserId = udate.Id;
                    mdcdata.SessionId = sessionid;
                    mdcdata.UserType = "Normal";
                    mdcdata.Save();
                    reponse = "Manoj";
                }
                else
                {
                    int preqty = mdcdatach.Quantity;
                    int updateQty = preqty + 1;
                    mdcdatach.Quantity = updateQty;
                    mdcdatach.Update(int.Parse(dataid), sessionid, udate.Id);
                    reponse = "Manoj";
                }
            }
        }
        catch (Exception ex)
        {

        }
        return "Manoj";
    }

    [WebMethod]

    public void removeDataFromShopingCart(int dataid, float price, string sessionid, string email)
    {
        DataSet ds = null;

        try
        {


            MyCartData cdatach = new MyCartData(dataid, sessionid, email);
            if (cdatach.HasValue && cdatach.Quantity == 2)
            {
                cdatach.Delete("delete from cartdata where id=" + cdatach.Id);
            }
            if (cdatach.HasValue && cdatach.Quantity > 2)
            {
                int status = 1;

                cdatach.ProductId = dataid;
                cdatach.Quantity = cdatach.Quantity - 2;
                cdatach.Update(cdatach.Id);


            }

        }
        catch (Exception ex)
        {

        }
    }

    [WebMethod]
    public void removeData(int dataid, float price, string sessionid, string size, string email)
    {
        DataSet ds = null;

        try
        {

            MyCartData cdatach = new MyCartData(dataid, sessionid, email);
            if (cdatach.HasValue && cdatach.Quantity == 2)
            {
                cdatach.Delete("delete from cartdata where id=" + cdatach.Id);
            }
            if (cdatach.HasValue && cdatach.Quantity > 2)
            {
                int status = 1;

                cdatach.ProductId = dataid;
                cdatach.Quantity = cdatach.Quantity - 2;
                cdatach.Update(cdatach.Id);

            }
        }

        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void removeMedicineData(int dataid, float price, string sessionid, string dose, string email, string from, string orderType)
    {
        DataSet ds = null;

        try
        {
            if (from == "cart" && orderType == "med")
            {
                MedicineCart mcdatach = new MedicineCart(dataid, sessionid, dose, email);
                if (mcdatach.HasValue && mcdatach.Quantity == 1)
                {
                    mcdatach.Delete("delete from medicine_cart where id=" + mcdatach.Id);
                }
                if (mcdatach.HasValue && mcdatach.Quantity > 1)
                {
                    int status = 1;
                    mcdatach.ProductId = dataid;
                    mcdatach.Quantity = mcdatach.Quantity - 1;
                    mcdatach.Update(mcdatach.Id);

                }
            }
            else
            {
                DirectProductDataMed mdcdatach = new DirectProductDataMed(dataid, sessionid, dose, email);
                if (mdcdatach.HasValue && mdcdatach.Quantity == 1)
                {
                    mdcdatach.Delete("delete from direct_product_med where id=" + mdcdatach.Id);
                }
                if (mdcdatach.HasValue && mdcdatach.Quantity > 1)
                {
                    int status = 1;
                    mdcdatach.ProductId = dataid;
                    mdcdatach.Quantity = mdcdatach.Quantity - 1;
                    mdcdatach.Update(mdcdatach.Id);

                }
            }

        }
        catch (Exception ex)
        {

        }
    }

    [WebMethod]
    public void deleteWishListItem(int id)
    {
        DataSet ds = null;

        try
        {
            WishListData wdata = new WishListData();
            wdata.Delete("delete from wishlist where id=" + id);

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void moveToCart(int id, string sessionid, string email)
    {
        DataSet ds = null;

        try
        {
            WishListData wdata = new WishListData(id);
            MyCartData cdatach = new MyCartData(wdata.ProductId, sessionid, email);

            if (!cdatach.HasValue)
            {
                int status = 1;
                MyCartData cdata = new MyCartData();
                cdata.ProductId = wdata.ProductId;
                cdata.Size = wdata.Size;
                cdata.Quantity = wdata.Quantity;
                cdata.IsCheckout = true;
                cdata.Price = wdata.Price;
                cdata.NewPrice = wdata.NewPrice; ;
                cdata.UserId = wdata.UserId;
                cdata.SessionId = sessionid;
                cdata.DiscountId = 0;
                cdata.Save();

                wdata.Delete("delete from wishlist where id=" + id);
            }
            if (cdatach.HasValue)
            {
                wdata.Delete("delete from wishlist where id=" + id);
            }




        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void moveToMedicineCart(int id, string sessionid, string email)
    {
        DataSet ds = null;

        try
        {
            MedicineWishlist wdata = new MedicineWishlist(id);
            MedicineCart cdatach = new MedicineCart(wdata.ProductId, sessionid, wdata.Dose, email);

            if (!cdatach.HasValue)
            {
                int status = 1;
                MedicineCart cdata = new MedicineCart();
                cdata.ProductId = wdata.ProductId;
                cdata.Dose = wdata.Dose;
                cdata.Quantity = wdata.Quantity;
                cdata.Price = wdata.Price;
                cdata.NewPrice = wdata.NewPrice; ;
                cdata.UserId = wdata.UserId;
                cdata.SessionId = sessionid;
                cdata.Save();
                wdata.Delete("delete from medicine_wishlist where id=" + id);
            }
            if (cdatach.HasValue)
            {
                wdata.Delete("delete from medicine_wishlist where id=" + id);
            }

        }
        catch (Exception ex)
        {

        }

    }

    [WebMethod]

    public void deleteItemsFromCart(int id, string sessionid, string email)
    {
        DataSet ds = null;

        try
        {

            MyCartData cdatach = new MyCartData(id, sessionid, email);
            if (cdatach.HasValue)
            {
                cdatach.Delete("delete from cartdata where id=" + cdatach.Id);
            }




        }
        catch (Exception ex)
        {

        }
    }

    [WebMethod]
    public void deleteItem(int id, string sessionid, string size, string email)
    {
        DataSet ds = null;

        try
        {
            MyCartData cdatach = new MyCartData(id, sessionid, email);
            if (cdatach.HasValue)
            {
                cdatach.Delete("delete from cartdata where id=" + cdatach.Id);
            }

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void deleteMedicine(int id, string sessionid, string dose, string email, string from, string orderType)
    {
        DataSet ds = null;

        try
        {
            if (from == "cart" && orderType == "med")
            {
                MedicineCart mcdatach = new MedicineCart(id, sessionid, dose, email);
                if (mcdatach.HasValue)
                {
                    mcdatach.Delete("delete from medicine_cart where id=" + mcdatach.Id);
                }
            }

            else
            {
                DirectProductDataMed mdcdatach = new DirectProductDataMed(id, sessionid, dose, email);
                if (mdcdatach.HasValue)
                {
                    mdcdatach.Delete("delete from direct_product_med where id=" + mdcdatach.Id);
                }
            }
        }
        catch (Exception ex)
        {

        }

    }

    [WebMethod]
    public void deleteCartMedicine(int id, string sessionid, string dose, string email)
    {
        DataSet ds = null;

        try
        {
            MedicineCart mcdatach = new MedicineCart(id, sessionid, dose, email);
            if (mcdatach.HasValue)
            {
                mcdatach.Delete("delete from medicine_cart where id=" + mcdatach.Id);
            }

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public string moveToWishList(int cid, int userid)
    {
        try
        {
            MyCartData mcdata = new MyCartData(cid);

            WishListData wdatach = new WishListData(mcdata.ProductId, userid, mcdata.Size);

            if (!wdatach.HasValue)
            {
                int status = 1;
                WishListData wdata = new WishListData();
                wdata.ProductId = mcdata.ProductId;
                wdata.Size = mcdata.Size;
                wdata.Quantity = mcdata.Quantity;
                wdata.Price = mcdata.Price;
                wdata.NewPrice = mcdata.NewPrice;
                wdata.UserId = userid;
                wdata.DiscountId = 0;
                wdata.Save();


                wdata.Delete("delete from cartdata where id=" + cid);
            }
            if (wdatach.HasValue)
            {
                wdatach.Delete("delete from cartdata where id=" + cid);
            }
        }
        catch (Exception ex)
        {

        }
        return "Manoj";
    }
    [WebMethod]
    public string moveToMedicineWishList(int cid, int userid)
    {


        try
        {
            MedicineCart mcdata = new MedicineCart(cid);

            MedicineWishlist wdatach = new MedicineWishlist(mcdata.ProductId, userid, mcdata.Dose);

            if (!wdatach.HasValue)
            {
                int status = 1;
                MedicineWishlist wdata = new MedicineWishlist();
                wdata.ProductId = mcdata.ProductId;
                wdata.Dose = mcdata.Dose;
                wdata.Quantity = mcdata.Quantity;
                wdata.Price = mcdata.Price;
                wdata.NewPrice = mcdata.NewPrice;
                wdata.UserId = userid;
                wdata.Save();
                mcdata.Delete("delete from medicine_cart where id=" + cid);
            }
            if (wdatach.HasValue)
            {
                mcdata.Delete("delete from medicine_cart where id=" + cid);
            }

        }
        catch (Exception ex)
        {

        }
        return "Manoj";
    }
    [WebMethod]
    public string saveWishList(string dataid, string oldprice, string newprice, string userid, string size)
    {


        try
        {
            WishListData wdatach = new WishListData(int.Parse(dataid), int.Parse(userid), size);

            if (!wdatach.HasValue)
            {
                int status = 1;
                WishListData wdata = new WishListData();
                wdata.ProductId = int.Parse(dataid);
                wdata.Size = size;
                wdata.Quantity = 1;
                wdata.Price = double.Parse(oldprice);
                wdata.NewPrice = double.Parse(newprice);
                wdata.UserId = int.Parse(userid);
                wdata.DiscountId = 0;
                wdata.Save();
            }
        }
        catch (Exception ex)
        {

        }
        return "Manoj";
    }
    [WebMethod]
    public string saveMedicineWishList(string dataid, string oldprice, string newprice, string userid, string dose)
    {


        try
        {
            MedicineWishlist mwdatach = new MedicineWishlist(int.Parse(dataid), int.Parse(userid), dose);

            if (!mwdatach.HasValue)
            {
                int status = 1;
                MedicineWishlist wdata = new MedicineWishlist();
                wdata.ProductId = int.Parse(dataid);
                wdata.Dose = dose;
                wdata.Quantity = 1;
                wdata.Price = double.Parse(oldprice);
                wdata.NewPrice = double.Parse(newprice);
                wdata.UserId = int.Parse(userid);
                wdata.UserType = "Normal";
                wdata.Save();

            }
        }
        catch (Exception ex)
        {

        }
        return "Manoj";
    }
    [WebMethod]
    public void removeMedicineWishlistData(int dataid)
    {
        DataSet ds = null;

        try
        {
            MedicineWishlist mcdatach = new MedicineWishlist(dataid);
            if (mcdatach.HasValue && mcdatach.Quantity == 1)
            {
                mcdatach.Delete("delete from medicine_wishlist where id=" + mcdatach.Id);
            }
            if (mcdatach.HasValue && mcdatach.Quantity >= 2)
            {
                int status = 1;

                mcdatach.ProductId = dataid;
                mcdatach.Quantity = mcdatach.Quantity - 1;
                mcdatach.Update(mcdatach.Id);

            }
        }
        catch (Exception ex)
        {

        }

    }



    [WebMethod]
    public void removeWishlistData(int dataid)
    {
        DataSet ds = null;

        try
        {
            WishListData mcdatach = new WishListData(dataid);
            if (mcdatach.HasValue && mcdatach.Quantity == 1)
            {
                mcdatach.Delete("delete from wishlist where id=" + dataid);
            }
            if (mcdatach.HasValue && mcdatach.Quantity >= 2)
            {
                int status = 1;

                mcdatach.ProductId = dataid;
                mcdatach.Quantity = mcdatach.Quantity - 1;
                mcdatach.Update(dataid);

            }




        }
        catch (Exception ex)
        {

        }

    }







    [WebMethod]
    public void deleteMedicineWishlistData(int dataid)
    {
        DataSet ds = null;

        try
        {
            MedicineWishlist mcdatach = new MedicineWishlist(dataid);
            if (mcdatach.HasValue)
            {
                mcdatach.Delete("delete from medicine_wishlist where id=" + mcdatach.Id);
            }

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public string[] GetArea(string area, string city)
    {

        SubCData adata = new SubCData();
        DataSet ds = adata.getSubCategory("select * from area where city='" + city + "' and areapincode LIKE '%" + area + "%'");
        string[] arr = new string[ds.Tables[0].Rows.Count];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr[i] = ds.Tables[0].Rows[i]["areapincode"].ToString();
            }

        }

        //  jstring = JsonConvert.SerializeObject(ds, Formatting.Indented);


        return arr;
    }
    [WebMethod]
    public void saveAddressP(string email, string state, string city, string area, string address1, string address2, string landmark)
    {
        try
        {
            UserData cdata = new UserData(email);

            cdata.Update(cdata.Id);
            AreaData ardata = new AreaData(area);
            AddressData adata = new AddressData();
            adata.CustomerId = cdata.Id;
            adata.State = state;
            adata.City = city;
            adata.CityZone = ardata.CityZone;
            adata.Area = area;
            //adata.Pincode = pincode;
            adata.Address1 = address1;
            adata.Address2 = address2;
            adata.FlatNo = "";
            adata.Landmark = landmark;
            adata.IsPrimary = true;
            adata.Save();
        }
        catch (Exception ex)
        {

        }
    }
    [WebMethod]
    public AddressData getAddress(string id)
    {
        int adid = int.Parse(id);

        AddressData adata = new AddressData(adid, "for adderss");

        return adata;
    }

    [WebMethod]
    public AreaData getExtera(string area)
    {


        AreaData adata = new AreaData(area);

        return adata;
    }
    [WebMethod]
    public void saveAddress(string email, string city, string area, string address1, string address2, string landmark)
    {
        try
        {
            UserData cdata = new UserData(email);
            AreaData ardata = new AreaData(area);
            AddressData adata = new AddressData();

            adata.CustomerId = cdata.Id;
            adata.City = city;
            adata.CityZone = ardata.CityZone;
            adata.Area = area;
            adata.Pincode = "";
            adata.Address1 = address1;
            adata.Address2 = address2;
            adata.FlatNo = "";
            adata.Landmark = landmark;
            adata.IsPrimary = false;
            adata.Save();

        }
        catch (Exception ex)
        {

        }

    }

    [WebMethod]
    public void updateAddress(int id, string email, string city, string area, string address1, string address2, string landmark)
    {
        try
        {
            UserData cdata = new UserData(email);
            AreaData ardata = new AreaData(area);
            AddressData adata = new AddressData();

            adata.CustomerId = cdata.Id;
            adata.City = city;
            adata.CityZone = ardata.CityZone;
            adata.Area = area;
            adata.Pincode = "";
            adata.Address1 = address1;
            adata.Address2 = address2;
            adata.FlatNo = "";
            adata.Landmark = landmark;
            adata.IsPrimary = false;
            adata.Update(id);

        }
        catch (Exception ex)
        {

        }

    }

    [WebMethod]
    public string confirm(string adid, string payoption, string email, string instruction, string from, string ordertype)
    {
        string orderno = "";
        string url = "";
        string msg = "";
        string adminMsg = "";
        DataSet ds = null;
        try
        {
            DateTime nextDate = DateTime.Now.AddDays(4);
            DateTime now = DateTime.Now;
            string items = "";
            string day = now.Day.ToString();
            // month = now.ToString("MMM");
            string month = now.Month.ToString();
            string year = now.Year.ToString();
            String days = now.DayOfWeek.ToString();
            UserData cdata = new UserData(email);
            if (from == "cart" && ordertype == "site")
            {
                ds = CartItems(cdata.Id);

                AddressData adata = new AddressData(int.Parse(adid), "myaddress");
                AreaData arData = new AreaData(adata.Area);

                OrderHeaderData ohdata = new OrderHeaderData();
                string address = adata.City + " " + adata.Area + "<br/>" + adata.Address1 + "," + adata.Address2 + "<br/>" + adata.Pincode + "<br/>" + adata.FlatNo + "-" + adata.Landmark;
                string invodate = days + "-" + day + "-" + month + "-" + year;
                string invoice = ohdata.Id.ToString();

                ohdata.UserId = cdata.Id;
                ohdata.Address = int.Parse(adid);
                ohdata.OrderTotal = totalAmount.ToString();
                ohdata.DeliveryCharge = arData.Extera.ToString();
                ohdata.PlacedDate = year + "-" + month + "-" + day;
                ohdata.OrderDate = nextDate.Year.ToString() + "-" + nextDate.Month.ToString() + "-" + nextDate.Day.ToString();
                ohdata.Instruction = instruction;
                ohdata.PaymentOption = payoption;
                ohdata.Status = "Pending";
                ohdata.Save();


                OrderHeaderData ohdata1 = new OrderHeaderData(cdata.Id);

                // lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    OrderLineData olData = new OrderLineData();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        olData.OrderId = ohdata1.Id;
                        olData.ItemNo = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                        olData.ItemName = ds.Tables[0].Rows[i]["productName"].ToString();
                        olData.Size = ds.Tables[0].Rows[i]["size"].ToString();
                        olData.Quantity = int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
                        olData.Price = float.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                        olData.NewPrice = float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString());
                        olData.TotalAmount = ((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * (float.Parse(ds.Tables[0].Rows[i]["quantity"].ToString())));
                        olData.Save();
                        ohdata1.Update(ohdata1.Id);
                        ProductData pdata = new ProductData(int.Parse(ds.Tables[0].Rows[i]["id"].ToString()));
                        pdata.Quantity = (pdata.Quantity - (int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString())));
                        pdata.UpdateStock(pdata.Id);
                        items += "<tr><td>" + olData.ItemName + "</td><td>" + olData.Quantity + "</td><td>" + olData.Size + "</td><td>" + olData.Price + "</td><td>" + olData.NewPrice + "</td><td>" + olData.TotalAmount + "</td>";

                    }
                    if (payoption == "COD")
                    {



                        MailManager mail = new MailManager();

                        //mail.SendBillingMail(cdata, invoice, invodate, address, olData.TotalAmount.ToString(), items, payoption);




                        clearCart(cdata.Id);
                        orderno = ohdata1.Id.ToString();
                    }
                    else
                    {
                        //url = "PayOnline.aspx?orderid=" + ohdata1.Id + "&totalamount=" + totalAmount + "&name=" + cdata.FirstName + "&area=" + adata.Area + "&pincode=" + adata.Pincode + "&city=" + adata.City + "&mobile=" + cdata.Mobile + "&email=" + cdata.Email;
                        //postData(ohdata1.Id, totalAmount, cdata.FirstName, adata.Area, adata.Pincode, adata.City, cdata.Mobile, cdata.Email);
                        //MailManager mail = new MailManager();
                        //mail.SendBillingMail(cdata, invoice, invodate, address, total, ardata.Extera, items);
                        //ohdata1.Update(ohdata1.Id);
                        //clearCart(cdata.Id);

                    }



                }
                else
                {
                    //lblTotalItems.Text = "No item In Cart";
                }
            }


            else if (from == "bynow" && ordertype == "site")
            {
                ds = byNowProduct(cdata.Id);
                AddressData adata = new AddressData(int.Parse(adid), "myaddress");
                AreaData arData = new AreaData(adata.Area);
                OrderHeaderData ohdata = new OrderHeaderData();
                string address = adata.City + " " + adata.Area + "<br/>" + adata.Address1 + "," + adata.Address2 + "<br/>" + adata.Pincode + "<br/>" + adata.FlatNo + "-" + adata.Landmark;
                string invodate = days + "-" + day + "-" + month + "-" + year;
                string invoice = ohdata.Id.ToString();

                ohdata.UserId = cdata.Id;
                ohdata.Address = int.Parse(adid);
                ohdata.OrderTotal = totalAmount.ToString();
                ohdata.DeliveryCharge = arData.Extera.ToString();
                ohdata.PlacedDate = year + "-" + month + "-" + day;
                ohdata.OrderDate = nextDate.Year.ToString() + "-" + nextDate.Month.ToString() + "-" + nextDate.Day.ToString();
                ohdata.Instruction = instruction;
                ohdata.PaymentOption = payoption;
                ohdata.Status = "Pending";
                ohdata.Save();


                OrderHeaderData ohdata1 = new OrderHeaderData(cdata.Id);

                // lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    OrderLineData olData = new OrderLineData();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        olData.OrderId = ohdata1.Id;
                        olData.ItemNo = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                        olData.ItemName = ds.Tables[0].Rows[i]["productName"].ToString();
                        olData.Size = ds.Tables[0].Rows[i]["size"].ToString();
                        olData.Quantity = int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
                        olData.Price = float.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                        olData.NewPrice = float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString());
                        olData.TotalAmount = ((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * (float.Parse(ds.Tables[0].Rows[i]["quantity"].ToString())));
                        olData.Save();
                        ohdata1.Update(ohdata1.Id);

                        ProductData pdata = new ProductData(int.Parse(ds.Tables[0].Rows[i]["id"].ToString()));
                        pdata.Quantity = (pdata.Quantity - (int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString())));
                        pdata.UpdateStock(pdata.Id);

                        items += "<tr><td>" + olData.ItemName + "</td><td>" + olData.Quantity + "</td><td>" + olData.Size + "</td><td>" + olData.Price + "</td><td>" + olData.NewPrice + "</td><td>" + olData.TotalAmount + "</td>";


                    }


                    if (payoption == "COD")
                    {
                        MailManager mail = new MailManager();

                        // mail.SendBillingMail(cdata, invoice, invodate, address, olData.TotalAmount.ToString(), items, payoption);



                        clearByNow(cdata.Id);
                        orderno = ohdata1.Id.ToString();
                    }
                    else
                    {
                        // url = "PayOnline.aspx?orderid=" + ohdata1.Id + "&totalamount=" + totalAmount + "&name=" + cdata.FirstName + "&area=" + adata.Area + "&pincode=" + adata.Pincode + "&city=" + adata.City + "&mobile=" + cdata.Mobile + "&email=" + cdata.Email;
                        //postData(ohdata1.Id, totalAmount, cdata.FirstName, adata.Area, adata.Pincode, adata.City, cdata.Mobile, cdata.Email);
                        //MailManager mail = new MailManager();
                        //mail.SendBillingMail(cdata, invoice, invodate, address, total, ardata.Extera, items);
                        //ohdata1.Update(ohdata1.Id);
                        //clearCart(cdata.Id);
                    }



                }
                else
                {
                    //lblTotalItems.Text = "No item In Cart";
                }
            }

        }
        catch (Exception ex)
        {

        }
        return orderno;

    }

    public DataSet byNowProduct(int Id)
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.image,direct_product_site.id as cid,direct_product_site.product_id,direct_product_site.product_size as size,direct_product_site.price,direct_product_site.newPrice,direct_product_site.quantity,direct_product_site.session_id,direct_product_site.user_id from product inner join direct_product_site on product.id=direct_product_site.product_id where direct_product_site.user_id=" + Id);

        if (ds.Tables[0].Rows.Count > 0)
        {

            calculateTotal(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

        return ds;
    }
    public DataSet CartItems(int Id)
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.image,cartdata.id as cid,cartdata.productid,cartdata.size,cartdata.price,cartdata.newPrice,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where cartdata.userid=" + Id);

        if (ds.Tables[0].Rows.Count > 0)
        {

            calculateTotal(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

        return ds;
    }

    protected void calculateTotal(DataSet ds)
    {
        totalItems = 0;
        totalAmount = 0.0;
        totaldiscount = 0.0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            totalItems += int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
            totalAmount += (double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString()) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
            totaldiscount += ((double.Parse(ds.Tables[0].Rows[i]["price"].ToString()) - double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
        }

    }
    public void clearCart(int id)
    {

        MyCartData mcadat = new MyCartData();
        mcadat.Delete("delete from cartdata where userid=" + id);
    }

    public void clearByNow(int id)
    {
        DirectProductData dpdata = new DirectProductData();
        dpdata.Delete("delete from direct_product_site where user_id=" + id);
    }

    [WebMethod]
    public string GetProduct(string product)
    {
        SubCData adata = new SubCData();
        List<ProductSearch> plist = new List<ProductSearch>();
        DataSet ds = adata.getSubCategory("select id,productName,subcategoryid,image,newprice,price,size,discount from product where status='1' AND (productName LIKE '%" + product + "%')");
        //DataSet ds = adata.getSubCategory("SELECT * FROM product WHERE MATCH (productName) AGAINST ('" + product + "' IN NATURAL LANGUAGE MODE)");
        string[] arr = new string[ds.Tables[0].Rows.Count];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ProductSearch pdata = new ProductSearch();
                pdata.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                pdata.SubCatId = Convert.ToInt32(ds.Tables[0].Rows[i]["subcategoryid"].ToString());
                pdata.Product = ds.Tables[0].Rows[i]["productName"].ToString();
                pdata.Image = ds.Tables[0].Rows[i]["image"].ToString();
                pdata.NewPrice = Convert.ToDouble(ds.Tables[0].Rows[i]["newprice"].ToString());
                pdata.OldPrice = Convert.ToDouble(ds.Tables[0].Rows[i]["price"].ToString());
                pdata.Size = ds.Tables[0].Rows[i]["size"].ToString();
                pdata.Discount = ds.Tables[0].Rows[i]["discount"].ToString();
                plist.Add(pdata);
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(plist);

        // Context.Response.Write(str);
        return str;
    }


    [WebMethod]
    public MoreSizeData getSizeData(string id)
    {
        int adid = int.Parse(id);
        MoreSizeData msdata = new MoreSizeData(adid);
        return msdata;
    }


    [WebMethod]
    public string GetMyMedicine(string product, int medi_type)
    {

        MedicineData mdata = new MedicineData();
        List<MedicineSearch> plist = new List<MedicineSearch>();

        DataSet ds;

        if (medi_type == 0)
        {
            ds = mdata.getMedicine("select id,name,image,mrp_price,ptp_price,ptr_price,dose,ptp_discount,ptr_discount,scheme from medicine where approved=1 and name LIKE '%" + product + "%'");
        }
        else
        {
            ds = mdata.getMedicine("select id,name,image,mrp_price,ptp_price,ptr_price,dose,ptp_discount,ptr_discount,scheme from medicine where status='1' medicine_type=" + medi_type + " and approved=1 and name LIKE '%" + product + "%'");
        }

        //DataSet ds = mdata.getMedicine("SELECT * FROM medicine WHERE MATCH (name) AGAINST ('"+product+"' IN NATURAL LANGUAGE MODE)");

        string[] arr = new string[ds.Tables[0].Rows.Count];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MedicineSearch pdata = new MedicineSearch();
                pdata.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                pdata.Product = ds.Tables[0].Rows[i]["name"].ToString();
                pdata.Image = ds.Tables[0].Rows[i]["image"].ToString();
                pdata.MRP_Price = Convert.ToDouble(ds.Tables[0].Rows[i]["mrp_price"].ToString());
                pdata.PTP_Price = Convert.ToDouble(ds.Tables[0].Rows[i]["ptp_price"].ToString());
                pdata.PTR_Price = Convert.ToDouble(ds.Tables[0].Rows[i]["ptr_price"].ToString());
                pdata.Scheme = ds.Tables[0].Rows[i]["scheme"].ToString();
                pdata.Dose = ds.Tables[0].Rows[i]["dose"].ToString();
                pdata.PTP_Discount = ds.Tables[0].Rows[i]["ptp_discount"].ToString();
                pdata.PTR_Discount = ds.Tables[0].Rows[i]["ptr_discount"].ToString();
                plist.Add(pdata);
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(plist);

        // Context.Response.Write(str);
        return str;


    }
}



