using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace DatabaseService
{
	/// <summary>
	/// Summary description for dbService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class dbService : System.Web.Services.WebService
	{
		SqlConnection Con=new SqlConnection("Data Source =.; Initial Catalog = StudentInformation; Integrated Security = True");

		[WebMethod]
		public string HelloWorld()
		{
			return "Hello World";
		}
		[WebMethod]
		public int InsertData(int Id, string Title, string FirstName, string LastName, string Email, string MobileNo,string Course)
		{
            Con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblStudent VALUES(" + Id + ",'" + Title + "','" + FirstName + "','" + LastName + "','" + Email + "','" + MobileNo + "','"+Course+"')", Con);
			int i = cmd.ExecuteNonQuery();
			Con.Close();
			return i;
		}
		[WebMethod]
		public int UpdateData(int Id, string Title, string FirstName, string LastName, string Email, string MobileNo, string Course)
		{
            Con.Open();
            SqlCommand cmd = new SqlCommand("Update tblStudent set Tittle='"+Title+"',FirstName='"+FirstName+"',LastName='"+LastName+"',Email='"+Email+"',MobileNo='"+MobileNo+"',CourseName='"+Course+"' where Id="+Id+"", Con);
			int i = cmd.ExecuteNonQuery();
			Con.Close();
			return i;
		}
		[WebMethod]
		public int DeleteData(int Id)
		{
            Con.Open();
            SqlCommand cmd = new SqlCommand("Delete from tblStudent where Id=" + Id + "", Con);
			int i = cmd.ExecuteNonQuery();
			Con.Close();
			return i;
		}
	}
}
