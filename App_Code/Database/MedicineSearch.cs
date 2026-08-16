using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicineSearch
/// </summary>
public class MedicineSearch
{
    private int _Id;
    private string _Product;
    private string _Image;
    private double _PTR_Price;
    private double _MRP_Price;
    private double _PTP_Price;
    private string _Dose;  
    private string _PTR_Discount;
    private string _PTP_Discount;
    private string _Scheme;
	public MedicineSearch()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }

    public string Product
    {
        get { return _Product; }
        set { _Product = value; }
    }

    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public string Dose
    {
        get { return _Dose; }
        set { _Dose = value; }
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
    public double PTP_Price
    {
        get { return _PTP_Price; }
        set { _PTP_Price = value; }
    }
    public string PTR_Discount
    {
        get { return _PTR_Discount; }
        set { _PTR_Discount = value; }
    }
    public string PTP_Discount
    {
        get { return _PTP_Discount; }
        set { _PTP_Discount = value; }
    }
      public string Scheme
    {
        get { return _Scheme; }
        set { _Scheme = value; }
    }

}