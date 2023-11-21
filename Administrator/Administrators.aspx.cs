using Assignment4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.Administrator
{
    public partial class Administrators : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bdcar\\Downloads\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);

            if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor" ||
                    HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("Logon.aspx", true);
            }

            ShowAllRecords();
        }

        public void ShowAllRecords()
        {
            var members =
                    from member in dbcon.Members
                    select new
                    {
                        FirstName = member.MemberFirstName,
                        LastName = member.MemberLastName,
                        PhoneNumber = member.MemberPhoneNumber,
                        DateJoined = member.MemberDateJoined
                    };

            var instructors =
                from instructor in dbcon.Instructors
                select new
                {
                    FirstName = instructor.InstructorFirstName,
                    LastName = instructor.InstructorLastName
                };
            
            GridView1.DataSource = members;
            GridView1.DataBind();
            GridView1.Visible = true;

            GridView2.DataSource = instructors;
            GridView2.DataBind();
            GridView2.Visible = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            NetUser mymember = new NetUser();
            mymember.UserName = TextBox1.Text;
            mymember.UserPassword = TextBox2.Text;
            mymember.UserType = "Member";
            */

        }
    }
}