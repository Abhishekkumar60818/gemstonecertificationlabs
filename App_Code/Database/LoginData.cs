using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginData
/// </summary>
public class LoginData
{
    private int _Id;
    private string _FName;
	public LoginData()
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
    public string FirstName
    {
        get { return _FName; }
        set { _FName = value; }
    }
}