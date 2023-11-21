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
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bdcar\\Downloads\\KarateSchool(1)\\KarateSchool(5).mdf;Integrated Security=True;Connect Timeout=30";
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
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            NetUser myuser = new NetUser();
            myuser.UserName = TextBox1.Text;
            myuser.UserPassword = TextBox2.Text;
            myuser.UserType = "Member";

            dbcon.NetUsers.InsertOnSubmit(myuser);
            dbcon.SubmitChanges();

            NetUser newUser = (from x in dbcon.NetUsers
                               where x.UserName == TextBox1.Text
                               select x).First();

            Member mymember = new Member();
            mymember.Member_UserID = newUser.UserID;
            mymember.MemberFirstName = TextBox3.Text;
            mymember.MemberLastName = TextBox4.Text;
            mymember.MemberPhoneNumber = TextBox5.Text;
            mymember.MemberEmail = TextBox6.Text;
            mymember.MemberDateJoined = System.DateTime.Now;

            dbcon.Members.InsertOnSubmit(mymember);
            dbcon.SubmitChanges();

            Section mysection = new Section();
            mysection.SectionName = DropDownList1.SelectedItem.Text;
            mysection.Member_ID = mymember.Member_UserID;
            mysection.Instructor_ID = Convert.ToInt32(TextBox7.Text);
            mysection.SectionStartDate = System.DateTime.Now;
            mysection.SectionFee = Convert.ToDecimal(DropDownList1.SelectedValue);

            dbcon.Sections.InsertOnSubmit(mysection);
            dbcon.SubmitChanges();

            ShowAllRecords();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            NetUser myuser = new NetUser();
            myuser.UserName = TextBox8.Text;
            myuser.UserPassword = TextBox9.Text;
            myuser.UserType = "Instructor";

            dbcon.NetUsers.InsertOnSubmit(myuser);
            dbcon.SubmitChanges();

            NetUser newUser = (from x in dbcon.NetUsers
                               where x.UserName == TextBox8.Text
                               select x).First();

            Instructor myinstructor = new Instructor();
            myinstructor.InstructorID = newUser.UserID;
            myinstructor.InstructorFirstName = TextBox10.Text;
            myinstructor.InstructorLastName = TextBox11.Text;
            myinstructor.InstructorPhoneNumber = TextBox12.Text;

            dbcon.Instructors.InsertOnSubmit(myinstructor);
            dbcon.SubmitChanges();

            ShowAllRecords();
        }
    }
}