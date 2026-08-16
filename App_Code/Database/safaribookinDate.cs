using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for safaribookinDate
/// </summary>
public class safaribookinDate
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

    public safaribookinDate()
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
        param.Add(new MySqlParameter("@Zone", Zone));
        param.Add(new MySqlParameter("@Vehicle", Vehicle));
        param.Add(new MySqlParameter("@Timing", Timing));
        param.Add(new MySqlParameter("@Calendra", Calendra));
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@Member", Member));



        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO fill_form3(Name,Number,Zone,Vehicle,Timing,Calendra,email,Member)VALUES(@Name,@Number,@Zone,@Vehicle,@Timing,@Calendra,@email,@Member)", param);
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
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@Member", Member));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE fill_form3 SET Name=@Name,Number=@Number,Zone=@Zone,Vehicle=@Vehicle,Timing=@Timing,Calendra=@Calendra,email=@email,Member=@Member WHERE id=@id", param);
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
    public string Name { get; set; }
    public string Number { get; set; }
    public string Zone { get; set; }
    public string Vehicle { get; set; }
    public string Timing { get; set; }
    public string Calendra { get; set; }
    public string email { get; set; }
    public string Member { get; set; }


}