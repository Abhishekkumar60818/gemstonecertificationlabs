using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for couch
/// </summary>
public class couch
{
    private int _Id;
    private string _name;
    private string _Mothername;
    private string _fathername;
    private string _MobilNo;
    private string _dob;
    private string _address;
    private string _club_name;
    private string _club_Address;
    private string _Experience;
    private string _Activity;
    private string _Strength;
    private string _GirlLength;
    private string _Email;
    private string _Aadhar;
    private string _Image;

    public couch()
    {
        //
        // TODO: Add constructor logic here
        //
    }



   
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();

        param.Add(new MySqlParameter("@Name", Name));
        param.Add(new MySqlParameter("@Number", Number));
        param.Add(new MySqlParameter("@Zone", Zone ));
        param.Add(new MySqlParameter("@Vehicle", Vehicle));
        param.Add(new MySqlParameter("@Timing", Timing));
        param.Add(new MySqlParameter("@Calendra", Calendra));
        param.Add(new MySqlParameter("@Address", Address)); 
        param.Add(new MySqlParameter("@member", member));
        param.Add(new MySqlParameter("@vehiclid", vehicid));



        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO fill_form2(Name,Number,Zone,Vehicle,Timing,Calendra,Address,member,vehiclid)VALUES(@Name,@Number,@Zone,@Vehicle,@Timing,@Calendra,@Address,@member,@vehiclid)", param);
        //connect.ExecStatement("INSERT INTO coach_registration(Name,Mothername,fathername,MobilNo,dob,address,club_name,club_Address,Experience,Activity,Strength,Email,Aadhar,Image)VALUES(@name,@Mothername,@fathername,@MobilNo,@dob,@address,@club_name,@club_Address,@Experience,@Activity,@Strength,@Email,@Aadhar,@Image)", param);



        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@nNameame", Name));
        param.Add(new MySqlParameter("@Number", Number));
        param.Add(new MySqlParameter("@Zone", Zone));
        param.Add(new MySqlParameter("@Vehicle", Vehicle));
        param.Add(new MySqlParameter("@Timing", Timing));
        param.Add(new MySqlParameter("@Calendra", Calendra));
        param.Add(new MySqlParameter("@Address", Address));
        param.Add(new MySqlParameter("@member", member));
        param.Add(new MySqlParameter("@vehiclid", vehicid));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE fill_form2 SET Name=@Name,Number=@Number,Zone=@Zone,Vehicle=@Vehicle,Timing=@Timing,Calendra=@Calendra,Address=@Address,member=@member,vehiclid=@vehiclid WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getDetails(String query)
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
    public int id { get; set; }

    public int vehicid { get; set; }
    
    public string Name { get; set; }
    public string Number { get; set; }
    public string Zone { get; set; }
    public string Vehicle { get; set; }
    public string Timing { get; set; }
    public string Calendra { get; set; }
    public string Address { get; set; }
    public string member { get; set; }
    public object Tables { get; set; }
    
}