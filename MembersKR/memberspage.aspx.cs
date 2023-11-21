using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.MembersKR
{
    public partial class memberspage : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bdcar\\Downloads\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(connString);
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor" ||
                    HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }

                Member myUser = (from x in dbcon.Members
                                 where x.Member_UserID == Convert.ToInt32(HttpContext.Current.Session["userID"])
                                 select x).First();

                if (myUser != null)
                {
                    string firstName = myUser.MemberFirstName;
                    string lastName = myUser.MemberLastName;
                    Label1.Text = firstName + " " + lastName;

                    var records =
                        from section in dbcon.Sections
                        join member in dbcon.Members on section.Member_ID equals HttpContext.Current.Session["userID"]
                        join instructor in dbcon.Instructors on section.Instructor_ID equals instructor.InstructorID
                        select new
                        {
                            SectionName = section.SectionName,
                            InstructorFirstName = instructor.InstructorFirstName,
                            InstructorLastName = instructor.InstructorLastName,
                            SectionStartDate = section.SectionStartDate,
                            SectionFee = section.SectionFee
                        };

                    GridView1.DataSource = records;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
            }
        }
    }
}
